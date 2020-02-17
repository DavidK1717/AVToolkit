using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace AVToolkit
{
    internal class NormaliseAudio : Operation
    {
        private string fileName;

        public bool FirstPassParameterStringChanged { get; set; } = false;

        public JObject JObj { get; set; }

        public Action<int> ProgressFinishedNormaliseAudioCallback;

        public NormaliseAudio(string inputFilePath) : base(inputFilePath)
        {
            FileName = "loudnorm.json";
        }

        public string ParameterString2ndPass { get; set; }

        public int PassCount { get; set; } = 1;
        public string FileName { get => fileName; set => fileName = value; }

        public override void AssignParameterString()
        {
            AssignParameterStringFirstPass();

            ParameterString2ndPass = "-hide_banner -i " + "\"" + InputFile.Path + "\""
                                     + " -af loudnorm=I=-16:TP=-1.5:LRA=11:measured_I=" + (string)JObj["input_i"]
                                     + ":measured_TP=" + (string)JObj["input_tp"]
                                     + ":measured_LRA=" + (string)JObj["input_lra"]
                                     + ":measured_thresh=" + (string)JObj["input_thresh"]
                                     + ":offset=" + (string)JObj["target_offset"]
                                     + ":linear=true " + "\"" + OutputFile.Path + "\"";
        }

        public void CreateJObject()
        {
            JObj = JObject.Parse(File.ReadAllText(FileName));
        }

        public void AssignParameterStringFirstPass()
        {
            ParameterString = "-hide_banner -i " + "\"" + InputFile.Path + "\""
                                          + " -af loudnorm=I=-16:TP=-1.5:LRA=11:print_format=json -f null -";
        }

        public void AssignParameterStringThirdPass()
        {
            ParameterString = "-hide_banner -i " + "\"" + OutputFile.Path + "\""
                              + " -af loudnorm=I=-16:TP=-1.5:LRA=11:print_format=json -f null -";
        }

        protected override void ParseOutput(Process proc)
        {
            // TODO needs correcting for specific output of this operation
            const int ESTIMATED_LINE_COUNT = 32;
            var cancel = false;
            string line;

            bool writeJsonFlag = false;

            var reader = proc.StandardError;
            
            DeleteExistingFile();

            using (StreamWriter writer = new StreamWriter(FileName))
            {
                while (!cancel && (line = reader.ReadLine()) != null)
                {
                    Lines.Add(line);

                    if (line.Trim() == "{")
                        writeJsonFlag = true;

                    if (writeJsonFlag)
                        writer.WriteLine(line);

                    if (line.Trim() == "}")
                        writeJsonFlag = false;

                    //Console.WriteLine("Line number: " + Lines.Count + " " + line);

                    double percentage = Lines.Count / ESTIMATED_LINE_COUNT * 100;

                    var eventArgs = new ProgEventArgs(percentage);

                    OnFfmpegProgressChanged(eventArgs);

                    if (eventArgs.Cancel)
                        cancel = true;
                }
            }
        }

        public void DeleteExistingFile()
        {
            // if file already exists delete it.
            if (!File.Exists(FileName)) return;
            File.SetAttributes(FileName, FileAttributes.Normal);
            File.Delete(FileName);
        }

        public void PerformSecondPass()
        {
            ParameterString = ParameterString2ndPass;
            ExecuteAsync();
        }

        public void PerformThirdPass()
        {
            AssignParameterStringThirdPass();
            ExecuteAsync();
        }

        protected override void Ffmpeg_Finished(object sender, EventArgs e)
        {
            try
            {
                if (PassCount == 1)
                {
                   // does file exist?
                    if (SuccessTest())
                    {
                        ProgressFinishedNormaliseAudioCallback(PassCount);
                        // run second pass
                        PassCount = 2;
                        PerformSecondPass();
                    }
                    else
                    {
                        ProgressFinishedCallback("Failed");
                        var message = MessageOnFailure();
                        MessageBox.Show(message);
                    }
                }
                else if (PassCount == 2)
                {
                    ProgressFinishedNormaliseAudioCallback(PassCount);

                    // does file exist?
                    if (SuccessTest2())
                    {
                        //ProgressFinishedCallback("Done");
                        PassCount = 3;
                        PerformThirdPass();
                    }
                    else
                    {
                        ProgressFinishedCallback("Failed");
                        var message = MessageOnFailure2();
                        MessageBox.Show(message);
                    }
                }
                else
                {
                    ProgressFinishedNormaliseAudioCallback(PassCount);

                    if (SuccessTest())
                    {
                        ProgressFinishedCallback("Done");
                    }
                    else
                    {
                        ProgressFinishedCallback("Failed");
                        var message = MessageOnFailure3();
                        MessageBox.Show(message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        protected override bool SuccessTest()
        {
            return File.Exists(FileName);
        }

        protected override string MessageOnFailure()
        {
            //return base.MessageOnFailure();

            var message = "Something went wrong on first pass." + Environment.NewLine
                          + "FFMPEG reported: " + Environment.NewLine
                          + GetErrorLine();

            return message;
        }

        protected bool SuccessTest2()
        {
            return File.Exists(OutputFile.Path);
        }

        protected string MessageOnFailure2()
        {
            var message = "Something went wrong on second pass." + Environment.NewLine
                          + "FFMPEG reported: " + Environment.NewLine
                          + GetErrorLine();

            return message;
        }

        protected string MessageOnFailure3()
        {
            var message = "Something went wrong on third pass." + Environment.NewLine
                          + "FFMPEG reported: " + Environment.NewLine
                          + GetErrorLine();

            return message;
        }

        public override void Run()
        {
            FfmpegProgressChanged += Ffmpeg_ProgressChanged;
            FfmpegFinished += Ffmpeg_Finished;
            FfmpegStarted += Ffmpeg_Started;

            if (FirstPassParameterStringChanged)
                ExecuteAsync();
            else
            {
                OnFfmpegFinished(EventArgs.Empty);
            }
        }
    }
}
