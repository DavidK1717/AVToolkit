using System;

namespace AVToolkit
{
    internal class ExtractSection : ExtractImage
    {
        public ExtractSection(string inputFilePath) : base(inputFilePath)
        {
        }

        public override void AssignParameterString()
        {
            var durationString = " -t " + OutputFile.Duration;

            if (OutputFile.ToEnd)
                durationString = "";

            string codecString;

            if (InputFile.IsAudio())
                codecString = " -acodec copy ";
            else if (InputFile.IsVideo())
                codecString = " -codec copy ";
            else
                throw new InvalidOperationException("Input file is not audio or video!");


            ParameterString = "-hide_banner -ss " + OutputFile.StartTime + durationString + " -i " + "\"" +
                              InputFile.Path + "\"" + codecString + "\"" + OutputFile.Path + "\"";
        }
    }
}