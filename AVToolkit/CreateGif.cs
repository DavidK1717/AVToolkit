using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace AVToolkit
{
    internal class CreateGif : Operation
    {
        public Action<int> ProgressFinishedCreateGifCallback;

        public CreateGif(string inputFilePath) : base(inputFilePath)
        {
        }

        public string ParameterString2ndPass { get; set; }

        public int PassCount { get; set; } = 1;

        public override void AssignParameterString()
        {
            var palette = "palette.png";
            var filters = "fps=" + OutputFile.Fps + ",scale=" + OutputFile.Scale + ":-1:flags=lanczos";

            ParameterString = "-hide_banner -ss " + OutputFile.StartTime + " -t " + OutputFile.Duration + " -i " +
                              "\"" + InputFile.Path + "\""
                              + " -vf " + "\"" + filters + ",palettegen" + "\"" + " -y " + palette;

            ParameterString2ndPass = "-hide_banner -ss " + OutputFile.StartTime + " -t " + OutputFile.Duration +
                                     " -i " + "\"" + InputFile.Path + "\"" + " -i " + "\"" + palette + "\""
                                     + " -lavfi " + "\"" + filters + " [x]; [x][1:v] paletteuse" + "\"" + " -y " +
                                     "\"" + OutputFile.Path + "\"";
        }

        protected override void ParseOutput(Process proc)
        {
            // TODO needs correcting for specific output of this operation
            var ESTIMATED_LINE_COUNT = 32;
            var cancel = false;
            var reader = proc.StandardError;

            string line;

            while (!cancel && (line = reader.ReadLine()) != null)
            {
                Lines.Add(line);

#if (DEBUG)
                Console.WriteLine("Line number: " + Lines.Count + " " + line);
#endif


                double percentage = Lines.Count / ESTIMATED_LINE_COUNT * 100;

                var eventArgs = new ProgEventArgs(percentage);

                OnFfmpegProgressChanged(eventArgs);

                if (eventArgs.Cancel)
                    cancel = true;
            }
        }

        public void PerformSecondPass()
        {
            ParameterString = ParameterString2ndPass;
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
                        ProgressFinishedCreateGifCallback(PassCount);
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
                else
                {
                    ProgressFinishedCreateGifCallback(PassCount);

                    // does file exist?
                    if (SuccessTest2())
                    {
                        ProgressFinishedCallback("Done");
                    }
                    else
                    {
                        ProgressFinishedCallback("Failed");
                        var message = MessageOnFailure2();
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
            //return base.SuccessTest();

            // only test for existence of first file
            return File.Exists("palette.png");
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
            //return base.SuccessTest();


            return File.Exists(OutputFile.Path);
        }

        protected string MessageOnFailure2()
        {
            //return base.MessageOnFailure();

            var message = "Something went wrong on second pass." + Environment.NewLine
                          + "FFMPEG reported: " + Environment.NewLine
                          + GetErrorLine();

            return message;
        }
    }
}