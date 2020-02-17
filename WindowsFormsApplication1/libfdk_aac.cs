namespace AVToolkit
{
    internal class Libfdk_aac : Codec
    {
        public Libfdk_aac()
        {
            AudioBitratesCBR = new[] {320, 256, 160, 128, 64, 32};
            AudioBitratesVBR = new[] {1, 2, 3, 4, 5};
            AudioBitrateRangeVBR =
                new[] {"20-32", "32-40", "48-56", "64-73", "96-112"};

            AudioBitratesCBR_fmtd = new string[6];
            for (var i = 0; i < AudioBitratesCBR_fmtd.Length; i++)
                AudioBitratesCBR_fmtd[i] = AudioBitratesCBR[i] + " kbits/s";

            AudioBitratesVBR_fmtd = new string[5];
            for (var i = 0; i < AudioBitratesVBR_fmtd.Length; i++)
                AudioBitratesVBR_fmtd[i] = AudioBitrateRangeVBR[i] + " kbits/s";

            Ffmpeg_library = "libfdk_aac";
            Extension = ".aac";
        }

        // for VBR the bitrate field actually contains a quality value
        public override void SetParameterStrings(string inputFilePath, string outputFilePath)
        {
            Param_CBR = NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a libfdk_aac -b:a "
                        + _bitrate
                        + "k -vn " + "\"" + outputFilePath + "\"";

            Param_VBR = NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a libfdk_aac -vbr "
                        + (_bitrate + 1) // because quality values start at 1 for this codec
                        + " " + "\"" + outputFilePath + "\"";

            Param_ABR = NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a libfdk_aac -abr 1 -b:a "
                        + _bitrate
                        + "k -vn " + "\"" + outputFilePath + "\"";
        }

        public override string GetParameterString(string inputFilePath, string outputFilePath, int encodingMode)
        {
            switch (encodingMode)
            {
                case (int) BitrateMode.CBR:
                {
                    return NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a libfdk_aac -b:a "
                           + _bitrate
                           + "k -vn " + "\"" + outputFilePath + "\"";
                }
                case (int) BitrateMode.VBR:
                {
                    return NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a libfdk_aac -vbr "
                           + (_bitrate + 1) // because quality values start at 1 for this codec
                           + " " + "\"" + outputFilePath + "\"";
                }
                case (int) BitrateMode.ABR:
                {
                    return NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a libfdk_aac -abr 1 -b:a "
                           + _bitrate
                           + "k -vn " + "\"" + outputFilePath + "\"";
                }
                default:
                {
                    return "";
                }
            }
        }
    }
}