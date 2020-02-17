namespace AVToolkit
{
    internal class Libmp3lame : Codec
    {
        public Libmp3lame()
        {
            Ffmpeg_library = "libmp3lame";

            AudioBitratesCBR = new[] {320, 256, 160, 128, 64, 32};
            AudioBitratesVBR = new[] {245, 225, 190, 175, 165, 130, 115, 100, 85, 65};
            AudioBitrateRangeVBR =
                new[]
                {
                    "220-260", "190-250", "170-210", "150-195", "140-185", "120-150", "100-130", "80-120", "70-105",
                    "45-85"
                };

            AudioBitratesCBR_fmtd = new string[6];
            for (var i = 0; i < AudioBitratesCBR_fmtd.Length; i++)
                AudioBitratesCBR_fmtd[i] = AudioBitratesCBR[i] + " kbits/s";

            AudioBitratesVBR_fmtd = new string[10];
            for (var i = 0; i < AudioBitratesVBR_fmtd.Length; i++)
                AudioBitratesVBR_fmtd[i] = AudioBitrateRangeVBR[i] + " kbits/s"
                                           + " (" + AudioBitratesVBR[i] + " Avg)";

            Extension = ".mp3";
        }

        public override string OutputFilePath
        {
            set => _outputFilePath = value;
            //get {  return this.}
        }

        // for VBR the bitrate field actually contains a quality value
        public override void SetParameterStrings(string inputFilePath, string outputFilePath)
        {
            Param_CBR = NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a libmp3lame -b:a "
                        + _bitrate
                        + "k -vn " + "\"" + outputFilePath + "\"";

            Param_VBR = NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a libmp3lame -q:a "
                        + _bitrate
                        + " " + "\"" + outputFilePath + "\"";

            Param_ABR = NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a libmp3lame -abr 1 -b:a "
                        + _bitrate
                        + "k -vn " + "\"" + outputFilePath + "\"";
        }

        public override string GetParameterString(string inputFilePath, string outputFilePath, int encodingMode)
        {
            switch (encodingMode)
            {
                case (int) BitrateMode.CBR:
                {
                    return NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a libmp3lame -b:a "
                           + _bitrate + "k -vn " + "\"" + outputFilePath + "\"";
                }
                case (int) BitrateMode.VBR:
                {
                    return NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a libmp3lame -q:a "
                           + _bitrate + " " + "\"" + outputFilePath + "\"";
                }
                case (int) BitrateMode.ABR:
                {
                    return NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -codec:a libmp3lame -abr 1 -b:a "
                           + _bitrate + "k -vn " + "\"" + outputFilePath + "\"";
                }
                default:
                {
                    return "";
                }
            }
        }
    }
}