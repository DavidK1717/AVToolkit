using System.IO;
using Util;

namespace AVToolkit
{
    internal class Mjpg : Codec
    {
        public Mjpg()
        {
            ImageWidths =
                new[] {"1600", "1280", "1152", "1024", "800", "640"};

            ImageFrequency =
                new[]
                {
                    "Every second", "Every 5 secs", "Every 10 secs", "Every 20 secs", "Every 30 secs", "Every minute"
                };

            Fps =
                new[] {"1", "12/60", "6/60", "3/60", "2/60", "1/60"};

            Ffmpeg_library = "jpg";
        }

        public override string GetParameterString(string inputFilePath, string outputFilePath, string startTime,
            string scale)
        {
            return NO_BANNER + "-ss " + startTime + " -i " + "\"" + inputFilePath + "\""
                   + " -vf scale=" + scale + ":-1 -vframes 1 -q:v 2 " + "\"" + outputFilePath + "\"";
        }

        // for some reason the scale option is not supported for multiple file extracts
        public override string GetParameterString(string inputFilePath, string outputFilePath, string startTime,
            string fps, string duration, bool toEnd)
        {
            var duration_string = " -t " + duration;

            if (toEnd)
                duration_string = " ";

            var outputFilePathPattern = Helper.GetFullPathWithoutExtension(outputFilePath) + "_%03d" +
                                        Path.GetExtension(outputFilePath);

            return NO_BANNER + "-ss " + startTime + " -i " + "\"" + inputFilePath + "\"" + duration_string
                   + " -vf fps=fps=" + fps + " -q:v 2 "
                   + "\"" + outputFilePathPattern + "\"";
        }
    }
}