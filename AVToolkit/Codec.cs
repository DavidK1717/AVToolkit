namespace AVToolkit
{
    public abstract class Codec
    {
        protected readonly string NO_BANNER = "-hide_banner ";
        protected int _bitrate;

        protected string _outputFilePath;

        public int[] AudioBitratesCBR { get; set; }

        public int[] AudioBitratesVBR { get; set; }

        public string Ffmpeg_library { get; set; }

        public string[] AudioBitrateRangeVBR { get; set; }

        public string[] AudioBitratesCBR_fmtd { get; set; }

        public string[] AudioBitratesVBR_fmtd { get; set; }

        public string Param_CBR { get; set; }

        public string Param_VBR { get; set; }

        public string Param_ABR { get; set; }

        public string Extension { get; set; }

        public virtual string OutputFilePath
        {
            get => _outputFilePath;
            set => _outputFilePath = value;
        }

        public virtual int Bitrate
        {
            get => _bitrate;
            set => _bitrate = value;
        }

        public string Param { get; set; }

        public string[] ImageWidths { get; set; }

        public string[] ImageFrequency { get; set; }

        public string[] Fps { get; set; }

        public string[] AudioBitratesVBR_fmtd_short { get; set; }

        public virtual void SetParameterStrings(string inputFilePath, string outputFilePath)
        {
        }

        public virtual string GetParameterString(string inputFilePath, string outputFilePath, int encodingMode)
        {
            return "";
        }

        public virtual string GetParameterString(string inputFilePath, string outputFilePath)
        {
            return "";
        }

        public virtual string GetParameterString(string inputFilePath, string audioInputFilePath, OutputFile outputFile)
        {
            return "";
        }

        public virtual string GetParameterString(string inputFilePath, string outputFilePath, string imageTime,
            string scale)
        {
            return "";
        }

        public virtual string GetParameterString(string inputFilePath, string outputFilePath, string imageTime,
            string fps, string duration, bool toEnd)
        {
            return "";
        }

        public virtual string GetParameterString(string inputFilePath, string imageTime, string fps, string scale,
            string duration)
        {
            return "";
        }

        public virtual string GetParameterString(string inputFilePath, string outputFilePath, string imageTime,
            string fps, string scale, string duration)
        {
            return "";
        }

        public virtual string GetParameterString(string inputFilePath, string outputFilePath, string imageTime,
            string duration, bool toEnd, string codec_type)
        {
            return "";
        }

        public virtual string GetParameterString(string inputFilePath, string outputFilePath, Codec audioCodec)
        {
            return "";
        }
    }
}