namespace AVToolkit
{
    internal class Mp4 : Codec
    {
        public Mp4()
        {
            Extension = ".mp4";
        }

        public override string GetParameterString(string inputFilePath, string audioInputFilePath,
            OutputFile outputFile)
        {
            return "";
        }
    }
}