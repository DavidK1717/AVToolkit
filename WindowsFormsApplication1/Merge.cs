using System;
using System.Diagnostics;

namespace AVToolkit
{
    internal class Merge : Operation
    {
        public Merge(string inputVideoFilePath) : base(inputVideoFilePath)
        {
        }

        protected InputFile InputAudioFile
        {
            get => _audioInputFile;
            set => _audioInputFile = value;
        }

        public override void AssignParameterString()
        {
            ParameterString = "-hide_banner -i " + "\"" + InputFile.Path + "\"" + " -i " + "\"" + AudioInputFile.Path +
                              "\""
                              + " -c:v copy -c:a " + OutputFile.AudioCodec.Ffmpeg_library + " -b:a bitrate "
                              + OutputFile.AudioCodec.AudioBitratesVBR_fmtd_short[OutputFile.Bitrate]
                              + " " + "\"" + OutputFile.Path + "\"";
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