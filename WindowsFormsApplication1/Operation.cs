using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using AVToolkit.Properties;

namespace AVToolkit
{
    public abstract class Operation
    {
        // if no download folder has been set, use users documents folder
        private readonly string downloadFolder = Settings.Default["DownloadFolder"].ToString() == ""
            ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            : Settings.Default["DownloadFolder"].ToString();

        protected readonly string ExeName = "Ffmpeg";

        protected readonly string FfmpegPath = Settings.Default["FfmpegFolder"].ToString() == ""
            ? Path.GetDirectoryName(Application.ExecutablePath)
            : Settings.Default["FfmpegFolder"].ToString();

        

        protected string _exePath;

        // TODO can these be made private?
        protected InputFile _inputFile;
        protected InputFile _audioInputFile;
        protected OutputFile _outputFile;
        protected string _parameterString;

        protected List<string> lines; // used if an ffmpeg error occurs

        public Action<string> ProgressFinishedCallback;
        public Action ProgressStartedCallback;
        public Action<double> ProgressUpdateCallback;

        protected Operation(string inputFilePath)
        {
            InputFile = new InputFile(inputFilePath);

            ExePath = Path.Combine(FfmpegPath, ExeName);

            Lines = new List<string>();
        }

        public InputFile InputFile
        {
            get => _inputFile;
            set => _inputFile = value;
        }

        public OutputFile OutputFile
        {
            get => _outputFile;
            set => _outputFile = value;
        }

        public InputFile AudioInputFile
        {
            get => _audioInputFile;
            set => _audioInputFile = value;
        }

        public List<string> Lines
        {
            get => lines;
            set => lines = value;
        }

        public string ExePath
        {
            get => _exePath;
            set => _exePath = value;
        }

        public virtual string ParameterString
        {
            get => _parameterString;
            set => _parameterString = value;
        }

        public virtual void AssignCodec(string codecName)
        {
            OutputFile.Codec = GetCodec(codecName, StreamType.Video);
        }

        public virtual void AssignAudioCodec(string codecName)
        {
            OutputFile.AudioCodec = GetCodec(codecName, StreamType.Audio);
        }

        public Codec GetCodec(string codecName, StreamType streamType)
        {
            Codec codec = null;

            switch (codecName)
            {
                case "libmp3lame":
                    codec = new Libmp3lame();
                    break;
                case "libfdk_aac":
                {
                    codec = new Libfdk_aac();
                    break;
                }
                case "aac":
                    codec = new Aac();
                    break;
                case "jpg":
                case "png":
                case "ppm":
                {
                    codec = new Mjpg {Extension = "." + codecName};
                    break;
                }
                case "gif":
                {
                    codec = new Gif();
                    break;
                }
                case "Copy":
                case "copy":
                {
                    codec = new Copy();
                    break;
                }
                default:
                {
                    throw new InvalidOperationException("this file type or codec is not supported.");
                }
            }
            return codec;
        }

        public virtual void AssignOutputFilePath()
        {
            if (Path.GetExtension(InputFile.Path) == OutputFile.Codec.Extension)
                OutputFile.Path = Path.Combine(downloadFolder, Path.GetFileNameWithoutExtension(InputFile.Path)
                                                               + "_1" + OutputFile.Codec.Extension);
            else
                OutputFile.Path = Path.Combine(downloadFolder, Path.GetFileNameWithoutExtension(InputFile.Path)
                                                               + OutputFile.Codec.Extension);

            if (File.Exists(OutputFile.Path))
                OutputFile.Path = Path.Combine(downloadFolder, Path.GetFileNameWithoutExtension(InputFile.Path)
                                                               + "_" + Path.GetRandomFileName().Substring(0, 8)
                                                               + OutputFile.Codec.Extension);
        }

        public virtual void AssignParameterString()
        {
        }

        // Note that by using the generic EventHandler<T> event type
        // we do not need to declare a separate delegate type.
        public event EventHandler<ProgEventArgs> FfmpegProgressChanged;

        public event EventHandler FfmpegFinished;
        public event EventHandler FfmpegStarted;

        // The event-invoking methods that derived classes can override.
        // see https://docs.microsoft.com/en-us/dotnet/articles/csharp/programming-guide/events/how-to-raise-base-class-events-in-derived-classes

        protected virtual void OnFfmpegProgressChanged(ProgEventArgs e)
        {
            FfmpegProgressChanged?.Invoke(this, e);
        }

        protected virtual void OnFfmpegFinished(EventArgs e)
        {
            FfmpegFinished?.Invoke(this, e);
        }

        protected virtual void OnFfmpegStarted(EventArgs e)
        {
            FfmpegStarted?.Invoke(this, e);
        }

        protected virtual void Ffmpeg_ProgressChanged(object sender, ProgEventArgs e)
        {
            try
            {
                var progPercent = (int) e.ProgPercentage;
                if (progPercent <= 100)
                    ProgressUpdateCallback(e.ProgPercentage);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        protected virtual void Ffmpeg_Started(object sender, EventArgs e)
        {
            try
            {
                ProgressStartedCallback();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        protected virtual void Ffmpeg_Finished(object sender, EventArgs e)
        {
            try
            {
                if (SuccessTest())
                {
                    ProgressFinishedCallback("Done");
                }
                else
                {
                    ProgressFinishedCallback("Failed");
                    var message = MessageOnFailure();
                    MessageBox.Show(message);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        public string GetErrorLine()
        {
            return Lines.Count > 0 ? Lines.Last() : "Empty";
        }

        public void Execute()
        {
            OnFfmpegStarted(EventArgs.Empty);

            using (var proc = new Process
            {
                StartInfo =
                {
                    FileName = ExePath,
                    Arguments = ParameterString,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            })
            {
                if (!proc.Start())
                {
                    Console.WriteLine("Error starting");
                    // throw error?
                    return;
                }

                ParseOutput(proc);

                proc.WaitForExit();
            }

            OnFfmpegFinished(EventArgs.Empty);
        }

        protected virtual void ParseOutput(Process proc)
        {
        }

        public void ExecuteAsync()
        {
            var bw = new BackgroundWorker();

            // define the event handlers
            bw.DoWork += (sender1, args) =>
            {
                // this will happen in a separate thread
                Execute();
            };
            bw.RunWorkerCompleted += (sender1, args) =>
            {
                if (args.Error != null)
                {
                    MessageBox.Show(args.Error.ToString());
                }
                //ExceptionDispatchInfo.Capture(args.Error).Throw();
            };

            bw.RunWorkerAsync(); // starts the background worker 
        }

        public virtual void Run()
        {
            FfmpegProgressChanged += Ffmpeg_ProgressChanged;
            FfmpegFinished += Ffmpeg_Finished;
            FfmpegStarted += Ffmpeg_Started;

            ExecuteAsync();
        }

        protected virtual bool SuccessTest()
        {
            return File.Exists(OutputFile.Path);
        }

        protected virtual string MessageOnFailure()
        {
            var message = "Output file was not created." + Environment.NewLine
                          + "FFMPEG reported: " + Environment.NewLine
                          + GetErrorLine();

            return message;
        }
    }
}