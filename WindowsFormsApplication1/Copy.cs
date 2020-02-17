namespace AVToolkit
{
    internal class Copy : Codec
    {
        public Copy()
        {
            Ffmpeg_library = "Copy";
        }

        public Copy(string ext)
        {
            Extension = ext;
        }

        public override string GetParameterString(string inputFilePath, string outputFilePath, string startTime,
            string duration, bool toEnd, string codec_type)
        {
            if (codec_type == "video")
                return NO_BANNER + "-ss " + startTime + " -t " + duration + " -i " + "\"" + inputFilePath + "\""
                       + " -codec copy " + "\"" + outputFilePath + "\"";
            if (codec_type == "audio")
                return NO_BANNER + "-ss " + startTime + " -t " + duration + " -i " + "\"" + inputFilePath + "\""
                       + " -acodec copy " + "\"" + outputFilePath + "\"";
            return "File must be video or audio!";
        }

        public override string GetParameterString(string inputFilePath, string audioInputFilePath,
            OutputFile outputFile)
        {
            return NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " - i " + "\"" + audioInputFilePath + "\""
                   + " -c:v copy -c:a" + outputFile.AudioCodec.Ffmpeg_library + " -b:a bitrate "
                   + outputFile.AudioCodec.AudioBitratesVBR_fmtd_short[Bitrate]
                   + " " + "\"" + outputFile.Path + "\"";
        }

        public override string GetParameterString(string inputFilePath, string outputFilePath, Codec audioCodec)
        {
            // both video and audio codecs are 'copy'
            if (audioCodec.Ffmpeg_library == "Copy")
                return NO_BANNER + "-i " + "\"" + inputFilePath + "\"" + " -acodec copy -vcodec copy "
                       + "\"" + outputFilePath + "\"";
            return "something";
        }
    }
}