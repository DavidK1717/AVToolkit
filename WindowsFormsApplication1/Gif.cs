namespace AVToolkit
{
    internal class Gif : Codec
    {
        private string filters;
        private string palette;

        public Gif()
        {
            Ffmpeg_library = "gif";
            Extension = ".gif";
        }

        // From http://blog.pkh.me/p/21-high-quality-gif-with-ffmpeg.html#usage

        public override string GetParameterString(string inputFilePath, string startTime, string fps, string scale,
            string duration)
        {
            palette = "palette.png";
            filters = "fps=" + fps + ",scale=" + scale + ":-1:flags=lanczos";

            return NO_BANNER + "-ss " + startTime + " -t " + duration + " -i " + "\"" + inputFilePath + "\""
                   + " -vf " + "\"" + filters + ",palettegen" + "\"" + " -y " + palette;
        }

        public override string GetParameterString(string inputFilePath, string outputFilePath, string startTime,
            string fps, string scale, string duration)
        {
            return NO_BANNER + "-ss " + startTime + " -t " + duration + " -i " + "\"" + inputFilePath + "\"" + " -i " +
                   "\"" + palette + "\""
                   + " -lavfi " + "\"" + filters + " [x]; [x][1:v] paletteuse" + "\"" + " -y " + "\"" + outputFilePath +
                   "\"";
        }
    }
}