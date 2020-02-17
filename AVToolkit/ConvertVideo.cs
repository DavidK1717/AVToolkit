using System;
using System.Diagnostics;

namespace AVToolkit
{
    public class ConvertVideo : Operation
    {
        public ConvertVideo(string inputFilePath) : base(inputFilePath)
        {
        }

        public override void AssignParameterString()
        {
            if (OutputFile.AudioCodec.Ffmpeg_library == "Copy")
                ParameterString = "-hide_banner -i " + "\"" + InputFile.Path + "\"" + " -acodec copy -vcodec copy "
                                  + "\"" + OutputFile.Path + "\"";
            else
                ParameterString = "something";
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