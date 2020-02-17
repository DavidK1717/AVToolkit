using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using AVToolkit.Properties;

namespace AVToolkit
{
    public class Ffmpeg
    {
        protected readonly string ExeName = "Ffmpeg";

        protected readonly string FfmpegPath = Settings.Default["FfmpegFolder"].ToString() == ""
            ? System.IO.Path.GetDirectoryName(Application.ExecutablePath)
            : Settings.Default["FfmpegFolder"].ToString();

        protected string _param;
        protected string _path;
        protected string _result;
        protected List<string> lines; // used if an error occurs

        public Ffmpeg(string param, string filePath)
        {
            Param = param;
            Path = System.IO.Path.Combine(filePath, ExeName);
            Lines = new List<string>();
        }

        public Ffmpeg(string param)
        {
            Param = param;
            Path = System.IO.Path.Combine(FfmpegPath, ExeName);
            Lines = new List<string>();
        }

        public Ffmpeg()
        {
            Path = System.IO.Path.Combine(FfmpegPath, ExeName);
        }

        public string Param
        {
            get => _param;
            set => _param = value;
        }

        public List<string> Lines
        {
            get => lines;
            set => lines = value;
        }

        public string Path
        {
            get => _path;
            set => _path = value;
        }

        public void SetAlternativePath()
        {
            _path = Settings.Default["FfmpegFolder2"].ToString();
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

        public string GetErrorLine()
        {
            return Lines.Count > 0 ? Lines.Last() : "Empty";
        }

        public void Execute()
        {
            OnFfmpegStarted(EventArgs.Empty);

            var proc = new Process
            {
                StartInfo =
                {
                    FileName = Path,
                    Arguments = Param,
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            if (!proc.Start())
            {
                Console.WriteLine("Error starting");
                // throw error?
                return;
            }

            ParseOutput(proc);

            proc.WaitForExit();
            proc.Close();

            OnFfmpegFinished(EventArgs.Empty);
        }

        protected virtual void ParseOutput(Process proc)
        {
            //StreamReader reader = proc.StandardOutput;
            var reader = proc.StandardError;

            // we want all the output
            _result = reader.ReadToEnd();
        }

        public void Execute(bool all)
        {
            using (var proc = new Process
            {
                StartInfo =
                {
                    FileName = Path,
                    Arguments = _param,
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

                //StreamReader reader = proc.StandardOutput;
                var reader = proc.StandardError;

                if (all)
                {
                    // we want all the output
                    _result = reader.ReadToEnd();
                }
                else
                {
                    // we just want the last line of the output
                    string line;

                    while ((line = reader.ReadLine()) != null)
                        _result = line;
                }

                proc.WaitForExit();
            }
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
                    MessageBox.Show(args.Error.ToString());
                //ExceptionDispatchInfo.Capture(args.Error).Throw();
            };

            bw.RunWorkerAsync(); // starts the background worker 
        }

        /// <summary>
        ///     Check if a particular library is compiled in ffmpeg eg libfdk_aac
        /// </summary>
        /// <param name="library"></param>
        /// <returns>bool</returns>
        public bool IsEnabled(string library)
        {
            _param = "-buildconf";

            Execute(true);

            if (_result.Contains(library))
                return true;
            return false;
        }
    }
}