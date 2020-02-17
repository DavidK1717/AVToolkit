namespace AVToolkit
{
    internal class Aac : Codec
    {
        public Aac()
        {
            // using the same bit rates as mp3 for the moment
            AudioBitratesCBR = new[] {320, 256, 160, 128, 64, 32};
            AudioBitratesVBR = new[] {245, 225, 190, 175, 165, 130, 115, 100, 85, 65};
            AudioBitrateRangeVBR =
                new[]
                {
                    "220-260", "190-250", "170-210", "150-195", "140-185", "120-150", "100-130", "80-120", "70-105",
                    "45-85"
                };

            Ffmpeg_library = "aac  -strict experimental";

            AudioBitratesCBR_fmtd = new string[6];
            for (var i = 0; i < AudioBitratesCBR_fmtd.Length; i++)
                AudioBitratesCBR_fmtd[i] = AudioBitratesCBR[i] + " kbits/s";

            AudioBitratesVBR_fmtd = new string[10];
            for (var i = 0; i < AudioBitratesVBR_fmtd.Length; i++)
                AudioBitratesVBR_fmtd[i] = AudioBitrateRangeVBR[i] + " kbits/s"
                                           + " (" + AudioBitratesVBR[i] + " Avg)";

            AudioBitratesVBR_fmtd_short = new string[10];
            for (var i = 0; i < AudioBitratesVBR_fmtd.Length; i++)
                AudioBitratesVBR_fmtd_short[i] = AudioBitratesVBR[i] + "k";

            Extension = ".aac";
        }

        // for VBR the bitrate field actually contains a quality value
        public override void SetParameterStrings(string inputFilePath, string outputFilePath)
        {
            Param_CBR = NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a aac -b:a "
                        + _bitrate
                        + "k -vn " + "\"" + outputFilePath + "\"";

            Param_VBR = NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a aac -q:a "
                        + _bitrate
                        + " " + "\"" + outputFilePath + "\"";

            Param_ABR = NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a aac -abr 1 -b:a "
                        + _bitrate
                        + "k -vn " + "\"" + outputFilePath + "\"";
        }

        public override string GetParameterString(string inputFilePath, string outputFilePath, int encodingMode)
        {
            switch (encodingMode)
            {
                case (int) BitrateMode.CBR:
                {
                    return NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a aac -b:a "
                           + _bitrate
                           + "k -vn -strict -2 " + "\"" + outputFilePath + "\"";
                }
                case (int) BitrateMode.VBR:
                {
                    return NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a aac -q:a "
                           + _bitrate
                           + "-strict -2 " + "\"" + outputFilePath + "\"";
                }
                case (int) BitrateMode.ABR:
                {
                    return NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a aac -abr 1 -b:a "
                           + _bitrate
                           + "k -vn -strict -2 " + "\"" + outputFilePath + "\"";
                }
                default:
                {
                    return "";
                }
            }
        }
    }
}