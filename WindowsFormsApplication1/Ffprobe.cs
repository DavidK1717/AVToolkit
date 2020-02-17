using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using AVToolkit.Properties;

namespace AVToolkit
{
    public class FfProbe
    {
        private readonly string _ffProbePath;
        private readonly string EXE_NAME = "Ffprobe";

        private readonly string FFPROBE_PATH = Settings.Default["FfProbeFolder"].ToString() == ""
            ? Path.GetDirectoryName(Application.ExecutablePath)
            : Settings.Default["FfProbeFolder"].ToString();

        //public FfProbe(string filePath, string ffprobe_path)
        //{
        //    _filePath = filePath;
        //    _ffProbePath = Path.Combine(ffprobe_path, ExeName);
        //}

        //public FfProbe(string ffprobe_path)
        //{            
        //    _ffProbePath = Path.Combine(ffprobe_path, ExeName);
        //}

        public FfProbe(string filePath)
        {
            FilePath = filePath;
            _ffProbePath = Path.Combine(FFPROBE_PATH, EXE_NAME);
        }

        public FfProbe()
        {
            _ffProbePath = Path.Combine(FFPROBE_PATH);
        }

        public string Result { get; set; }

        public string FilePath { get; set; }

        public string Param { get; set; }

        public void Execute(bool all)
        {
            using (var proc = new Process
            {
                StartInfo =
                {
                    FileName = _ffProbePath,
                    Arguments = Param,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            })
            {
                if (!proc.Start())
                {
                    Console.WriteLine("Error starting");
                    // throw error?
                    return;
                }

                var reader = proc.StandardOutput;

                if (all)
                {
                    // we want all the output
                    Result = reader.ReadToEnd();
                }
                else
                {
                    // we just want the last line of the output
                    string line;

                    while ((line = reader.ReadLine()) != null)
                        Result = line;
                }

                proc.WaitForExit();
            }
        }

        /// ffprobe -v quiet -print_format json -show_format -show_streams "lolwut.mp4" > "lolwut.mp4.json"
        /// or better
        /// ffprobe -v error -show_entries format=size -of default=noprint_wrappers=1:nokey=1 d:\vids\dog.m4a
        /// ffprobe -v error -show_entries format=duration -of default=noprint_wrappers=1:nokey=1 d:\vids\dog.m4a
        /// ffprobe -v error -show_entries format=bit_rate -of default=noprint_wrappers=1:nokey=1 d:\vids\dog.m4a
        /// ffprobe -v error -show_entries format=format_name -of default=noprint_wrappers=1:nokey=1 d:\vids\dog.m4a
        /// ffprobe -v error -show_entries format=format_long_name -of default=noprint_wrappers=1:nokey=1 d:\vids\dog.m4a
        /// ffprobe -v error -show_entries stream=codec_name  -of default=noprint_wrappers=1:nokey=1 d:\vids\dog.m4a
        /// ffprobe -v error -show_entries stream=index,codec_name,codec_type -of default=noprint_wrappers=1:nokey=1 d:\vids\patagonia.mp4
        public int GetBitrate()
        {
            Param =
                "-v error -show_entries format=bit_rate -of default=noprint_wrappers=1:nokey=1 "
                + FilePath;
            Execute(false);

            int retval;
            var parsed = int.TryParse(Result, out retval);

            if (!parsed)
                return 0;
            return retval;
        }

        public int GetNumberOfStreams()
        {
            Param =
                "-v error -show_entries format=nb_streams -of default=noprint_wrappers=1:nokey=1 "
                + FilePath;
            Execute(false);

            int retval;
            var parsed = int.TryParse(Result, out retval);

            if (!parsed)
                return 0;
            return retval;
        }

        public double GetDuration_s()
        {
            Param =
                "-v error -show_entries format=duration -of default=noprint_wrappers=1:nokey=1 "
                + FilePath;
            Execute(false);

            double retval;
            var parsed = double.TryParse(Result, out retval);

            if (!parsed)
                return 0;
            return retval;
        }

        public long GetSize_bytes()
        {
            Param =
                "-v error -show_entries format=size -of default=noprint_wrappers=1:nokey=1 "
                + FilePath;
            Execute(false);

            long retval;
            var parsed = long.TryParse(Result, out retval);

            if (!parsed)
                return 0;
            return retval;
        }

        public string GetFormat_long_name()
        {
            Param =
                "-v error -show_entries format=format_long_name -of default=noprint_wrappers=1:nokey=1 "
                + FilePath;
            Execute(false);

            return Result;
        }

        public string GetFormat_name()
        {
            Param =
                "-v error -show_entries format=format_name -of default=noprint_wrappers=1:nokey=1 "
                + FilePath;
            Execute(false);

            return Result;
        }

        // doesnt work see http://stackoverflow.com/questions/41115917/ffprobe-select-audio-and-video-streams
        public string GetStreamInfo(int stream)
        {
            Param =
                "-v error -show_entries -select_streams v:" + stream +
                " stream=index,codec_name,codec_type -of default=noprint_wrappers=1:nokey=1 "
                + FilePath;
            Execute(false);

            return Result;
        }

        public string GetJSON()
        {
            Param =
                "-v quiet -print_format json -show_format -show_streams "
                + FilePath;
            Execute(true);

            return Result;
        }

        /// <summary>
        ///     Check if a particular library is compiled in ffprobe eg libfdk_aac
        ///     a param of "" doesn't work presumably because ffprobe returns an error using standard error not standard output
        /// </summary>
        /// <param name="library"></param>
        /// <returns>bool</returns>
        public bool IsEnabled(string library)
        {
            Param = "-buildconf";

            Execute(true);

            if (Result.Contains(library))
                return true;
            return false;
        }
    }
}