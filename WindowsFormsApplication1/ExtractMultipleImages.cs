using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;
using Util;

namespace AVToolkit
{
    internal class ExtractMultipleImages : Operation
    {
        public ExtractMultipleImages(string inputFilePath) : base(inputFilePath)
        {
        }

        public override void AssignParameterString()
        {
            switch (OutputFile.Codec.Ffmpeg_library)
            {
                case "jpg":
                case "png":
                case "ppm":
                {
                    var durationString = " -t " + OutputFile.Duration;

                    if (OutputFile.ToEnd)
                        durationString = "";

                    var outputFilePathPattern = Helper.GetFullPathWithoutExtension(OutputFile.Path) + "_%03d" +
                                                Path.GetExtension(OutputFile.Path);

                    //ParameterString = "-hide_banner -ss " + OutputFile.StartTime + " -i " + "\"" + this.InputFile.Path + "\"" + durationString
                    //    + " -vf fps=fps=" + OutputFile.Fps + " -q:v 2 "
                    //    + "\"" + outputFilePathPattern + "\"";

                    ParameterString = "-hide_banner -ss " + OutputFile.StartTime + durationString + " -i " + "\"" +
                                      InputFile.Path + "\""
                                      + " -vf fps=fps=" + OutputFile.Fps + " -q:v 2 "
                                      + "\"" + outputFilePathPattern + "\"";

                    break;
                }
            }
        }

        protected override void ParseOutput(Process proc)
        {
            var cancel = false;
            var reader = proc.StandardError;

            string line;

            // estimate number of files for progress bar
            int duration;

            if (OutputFile.ToEnd)
                duration = (int) InputFile.Duration;
            else
                duration = int.Parse(OutputFile.Duration);

            var fileCountEstimate =
                Convert.ToInt32(Convert.ToDouble(duration) * Helper.FractionToDouble(OutputFile.Fps));

            while (!cancel && (line = reader.ReadLine()) != null)
            {
                Lines.Add(line);

#if (DEBUG)
                Console.WriteLine("Line number: " + Lines.Count + " " + line);
#endif
                if (line.Substring(0, 5).TrimStart() == "frame")
                {
                    var m = Regex.Match(line, @"\d+");
                    if (m.Success)
                    {
                        var filesSoFar = double.Parse(m.Value);

                        var percentage = filesSoFar / fileCountEstimate * 100;

                        var eventArgs = new ProgEventArgs(percentage);

                        OnFfmpegProgressChanged(eventArgs);

                        if (eventArgs.Cancel)
                            cancel = true;
                    }
                }
            }
        }

        protected override bool SuccessTest()
        {
            //return base.SuccessTest();

            // only test for existence of first file
            return File.Exists(Helper.GetFullPathWithoutExtension(OutputFile.Path) + "_001" +
                               Path.GetExtension(OutputFile.Path));
        }

        protected override string MessageOnFailure()
        {
            //return base.MessageOnFailure();

            var message = "Output files were not created." + Environment.NewLine
                          + "FFMPEG reported: " + Environment.NewLine
                          + GetErrorLine();

            return message;
        }
    }
}