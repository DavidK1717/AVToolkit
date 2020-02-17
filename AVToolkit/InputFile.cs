using System;
using System.Collections.Generic;
using System.Linq;
using Util;
using Newtonsoft.Json;

namespace AVToolkit
{
    public class InputFile
    {
        private readonly FfInfo _ffInfo;

        public InputFile(string path)
        {
            Path = path;

            // get file details in JSON format using ffprobe
            var ffProbe = new FfProbe("\"" + path + "\"");
            var json = ffProbe.GetJSON();

            _ffInfo = JsonConvert.DeserializeObject<FfInfo>(json);
            Format_long_name = _ffInfo.format.format_long_name;
            Formats = _ffInfo.format.format_name;
            Duration = double.Parse(_ffInfo.format.duration);

            // bitrate is given in bits/s, we want it in kbits/s
            Bitrate = int.Parse(_ffInfo.format.bit_rate) / 1000;
            Size = long.Parse(_ffInfo.format.size);
            NumberOfStreams = _ffInfo.format.nb_streams;

            var time = TimeSpan.FromSeconds(Duration);
            Formatted_duration = time.ToString(@"hh\:mm\:ss");
            Formatted_bitrate = $"{Bitrate:.##}" + " Kbits/s";
            Formatted_size = Helper.SizeSuffix(Size, 2);

            // not all file types have this field
            Encoder = _ffInfo.format.tags != null ? _ffInfo.format.tags.encoder : "";

            Formatted_streams = new List<string>();
            for (var i = 0; i < NumberOfStreams; i++)
            {
                var item = i + 1 + ". "
                           + _ffInfo.streams[i].codec_type + " " + _ffInfo.streams[i].codec_name;
                Formatted_streams.Add(item);
            }
        }

        //public FfInfo FfInfo { get{return _ffInfo;} set{ _ffInfo = value;} }
        public string Path { get; set; }

        public string Format_long_name { get; set; }

        public string Formats { get; set; }

        public double Duration { get; set; }

        public long Bitrate { get; set; }

        public long Size { get; set; }

        public int NumberOfStreams { get; set; }

        public string Formatted_duration { get; set; }

        public string Formatted_bitrate { get; set; }

        public string Formatted_size { get; set; }

        public string Encoder { get; set; }

        public List<string> Formatted_streams { get; set; }

        public string Resolution { get; set; }

        public string Aspect_ratio { get; set; }

        public string Pixel_format { get; set; }

        public string Level { get; set; }

        public string Nb_frames { get; set; }

        public string Sample_format { get; set; }

        public string Sample_rate { get; set; }

        public string Channels { get; set; }

        public string Layout { get; set; }

        public string Stream_encoder { get; set; }

        public string Stream_codec { get; set; }

        public long Stream_bitrate { get; set; }

        public string Formatted_stream_bitrate { get; set; }

        public string Stream_codec_type { get; set; }

        public int Width { get; set; }

        public void UpdateStreamFields(int streamIndex)
        {
            var stream = _ffInfo.streams.First(s => s.index == streamIndex);

            Stream_codec = stream.codec_long_name;
            Stream_codec_type = stream.codec_type;

            if (stream.bit_rate != null)
            {
                Stream_bitrate = int.Parse(stream.bit_rate) / 1000;
                Formatted_stream_bitrate = $"{Stream_bitrate:.##}" + " Kbits/s";
            }
            else
            {
                Stream_bitrate = -1;
                Formatted_stream_bitrate = "";
            }

            if (stream.codec_type == "video")
            {
                Width = stream.width;
                Resolution = stream.width + "x" + stream.height;

                Aspect_ratio = stream.display_aspect_ratio;

                Pixel_format = stream.pix_fmt;
                Level = stream.level.ToString();

                Nb_frames = stream.nb_frames;
            }
            else if (stream.codec_type == "audio")
            {
                Sample_format = stream.sample_fmt;

                Sample_rate = stream.sample_rate;

                Channels = stream.channels.ToString();
                Layout = stream.channel_layout;

                Stream_encoder = stream.tags != null ? stream.tags.encoder : "";
            }
        }

        public bool IsVideo()
        {
            return _ffInfo.streams.Any(s => s.codec_type == "video");
        }

        public bool IsAudio()
        {
            return !IsVideo() && _ffInfo.streams.Any(s => s.codec_type == "audio");
        }

        public bool IsSubtitle()
        {
            if (IsVideo() == false && !IsAudio())
                return _ffInfo.streams.Any(s => s.codec_type == "subtitle");
            return false;
        }
    }
}