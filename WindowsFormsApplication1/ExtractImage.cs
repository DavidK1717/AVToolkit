using System;
using System.Diagnostics;

namespace AVToolkit
{
    internal class ExtractImage : Operation
    {
        public ExtractImage(string inputFilePath) : base(inputFilePath)
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
                    ParameterString = "-hide_banner -ss " + OutputFile.StartTime + " -i " + "\"" + InputFile.Path + "\""
                                      + " -vf scale=" + OutputFile.Scale + ":-1 -vframes 1 -q:v 2 " + "\"" +
                                      OutputFile.Path + "\"";
                    break;
                }
            }
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
    }
}