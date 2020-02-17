using System;
using System.IO;
using AVToolkit.Properties;

namespace AVToolkit
{
    public class OutputFile
    {
        //private int _encoding_mode;
        //private string _defaultPath;

        // if no download folder has been set, use users documents folder

        private readonly string DOWNLOAD_FOLDER = Settings.Default["DownloadFolder"].ToString() == ""
            ? Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            : Settings.Default["DownloadFolder"].ToString();

        //public string DefaultPath { get{return _defaultPath;} set{ _defaultPath = value;} }
        //public int Encoding_mode { get{return _encoding_mode;} set{ _encoding_mode = value;} }

        public OutputFile(string inputFilePath, string codecName)
        {
            AssignCodec(inputFilePath, codecName);

            if (System.IO.Path.GetExtension(inputFilePath) == Codec.Extension)
                Path = System.IO.Path.Combine(DOWNLOAD_FOLDER,
                    System.IO.Path.GetFileNameWithoutExtension(inputFilePath) + "_1" + Codec.Extension);
            else
                Path = System.IO.Path.Combine(DOWNLOAD_FOLDER,
                    System.IO.Path.GetFileNameWithoutExtension(inputFilePath) + Codec.Extension);

            if (File.Exists(Path))
                Path = System.IO.Path.Combine(DOWNLOAD_FOLDER,
                    System.IO.Path.GetFileNameWithoutExtension(inputFilePath) + "_" +
                    System.IO.Path.GetRandomFileName().Substring(0, 8) + Codec.Extension);
        }

        public OutputFile()
        {
        }


        public string Extension { get; set; }

        public string Path { get; set; }

        public Codec Codec { get; set; }

        public Codec AudioCodec { get; set; }

        public int Bitrate { get; set; }

        public string StartTime { get; set; }

        public string Scale { get; set; }

        public string Fps { get; set; }

        public string Duration { get; set; }

        public bool ToEnd { get; set; }

        public void AssignOutputFilePath(string inputFilePath)
        {
            if (System.IO.Path.GetExtension(inputFilePath) == Codec.Extension)
                Path = System.IO.Path.Combine(DOWNLOAD_FOLDER, 
                    System.IO.Path.GetFileNameWithoutExtension(inputFilePath)
                                                                + "_1" + Codec.Extension);
            else
                Path = System.IO.Path.Combine(DOWNLOAD_FOLDER, 
                    System.IO.Path.GetFileNameWithoutExtension(inputFilePath)
                                                               + Codec.Extension);

            if (File.Exists(Path))
                Path = System.IO.Path.Combine(DOWNLOAD_FOLDER, 
                    System.IO.Path.GetFileNameWithoutExtension(inputFilePath)
                    + "_" + System.IO.Path.GetRandomFileName().Substring(0, 8)
                                                               + Codec.Extension);
        }

        public void AssignCodec(string inputFilePath, string codecName)
        {
            Codec = GetCodec(inputFilePath, codecName);
        }

        public void AssignAudioCodec(string inputFilePath, string codecName)
        {
            AudioCodec = GetCodec(inputFilePath, codecName);
        }

        public Codec GetCodec(string inputFilePath, string codecName)
        {
            Codec _codec;

            switch (codecName)
            {
                case "libmp3lame":
                    _codec = new Libmp3lame();
                    break;
                case "libfdk_aac":
                {
                    //For some reason this throws an "Access is denied" exception at proc.Start() in Ffmpeg
                    //The idea was to check if the alternative ffmpeg path supported libfdk_aac.If so the
                    //ffmpeg path would be changed to the alternative path when the codec was libfdk_aac.

                    //Resolution: abandon having an alternative path and rely on the user to change the ffmpeg path in 
                    //settings if libfdk_aac is needed.

//                    if (LibraryCheck(codecName))
//                        _codec = new Libfdk_aac();
//                    else
//                        _codec = new Aac();
//                    break;    

                    _codec = new Libfdk_aac();
                    break;

                    //if (Properties.Settings.Default["FfmpegFolder2"].ToString() != "")
                    //    _codec = new Libfdk_aac();
                    //else
                    //    _codec = new Aac();
                    //break;
                }
                case "aac":
                    _codec = new Aac();
                    break;
                case "jpg":
                case "png":
                case "ppm":
                {
                    _codec = new Mjpg {Extension = "." + codecName};
                    break;
                }
                case "gif":
                {
                    _codec = new Gif();
                    break;
                }
                case "Copy":
                {
                    _codec = new Copy(System.IO.Path.GetExtension(inputFilePath));
                    break;
                }
                default:
                    throw new InvalidOperationException("this file type or codec is not supported.");
                //_codec = null;
                //break;
            }
            return _codec;
        }

        private bool LibraryCheck(string library)
        {
            var returnFlag = false;

            if (Settings.Default["FfmpegFolder2"].ToString() != "")
            {
                var ffm = new Ffmpeg {Path = Settings.Default["FfmpegFolder2"].ToString()};


                if (ffm.IsEnabled(library))
                    returnFlag = true;
            }
            return returnFlag;
        }
    }
}