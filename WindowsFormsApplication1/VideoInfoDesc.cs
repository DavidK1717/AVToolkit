using System.Collections.Generic;

namespace AVToolkit
{
    public class VideoInfoDesc
    {
        internal static IEnumerable<VideoInfoDesc> Defaults = new List<VideoInfoDesc>
        {
            new VideoInfoDesc(5, "FLV 240p - MP3 64K"),
            new VideoInfoDesc(6, "FLV 270p - MP3 64K"),
            new VideoInfoDesc(13, "13"),
            new VideoInfoDesc(17, "3GP 144p - AAC 24K"),
            new VideoInfoDesc(18, "MP4 360p - AAC 96K"),
            new VideoInfoDesc(22, "MP4 720p HD - AAC 192K"),
            new VideoInfoDesc(34, "FLV 360p - MP3 128K"),
            new VideoInfoDesc(35, "FLV 480p - MP3 128K"),
            new VideoInfoDesc(36, "3GP 240p - AAC 38K"),
            new VideoInfoDesc(37, "MP4 1080p HD - AAC 192K"),
            new VideoInfoDesc(38, "MP4 3072p 6K - AAC 192K"),
            new VideoInfoDesc(43, "WEBM 360p - OGG 128K"),
            new VideoInfoDesc(44, "WEBM 480p - OGG 128K"),
            new VideoInfoDesc(45, "WEBM 720p HD - OGG 192K"),
            new VideoInfoDesc(46, "WEBM 1080p HD - OGG 192K"),
            new VideoInfoDesc(82, "3D MP4 360p - AAC 96K"),
            new VideoInfoDesc(83, "3D MP4 240p - AAC 96K"),
            new VideoInfoDesc(84, "3D MP4 720p HD - AAC 96K"),
            new VideoInfoDesc(85, "3D MP4 520p - AAC 96K"),
            new VideoInfoDesc(100, "3D WEBM 360p - OGG 128K"),
            new VideoInfoDesc(101, "3D WEBM 360p - OGG 192K"),
            new VideoInfoDesc(102, "3D WEBM 720p HD - OGG 192K"),
            new VideoInfoDesc(133, "MP4 240p video-only"),
            new VideoInfoDesc(134, "MP4 360p video-only"),
            new VideoInfoDesc(135, "MP4 480p video-only"),
            new VideoInfoDesc(136, "MP4 720p HD video-only"),
            new VideoInfoDesc(137, "MP4 1080p HD video-only"),
            new VideoInfoDesc(138, "MP4 2160p 4K video-only Low bitrate"),
            new VideoInfoDesc(160, "MP4 144p video-only"),
            new VideoInfoDesc(242, "WEBM 240p video-only Low bitrate"),
            new VideoInfoDesc(243, "WEBM 360p video-only Low bitrate"),
            new VideoInfoDesc(244, "WEBM 480p video-only Low bitrate"),
            new VideoInfoDesc(247, "WEBM 720p HD video-only Low bitrate"),
            new VideoInfoDesc(248, "WEBM 1080p HD video-only Low bitrate"),
            new VideoInfoDesc(264, "MP4 1440p video-only"),
            new VideoInfoDesc(271, "WEBM 1440p video-only Low bitrate"),
            new VideoInfoDesc(272, "WEBM 4320p60 8K video-only"),
            new VideoInfoDesc(278, "WEBM 144p video-only Low bitrate"),
            new VideoInfoDesc(139, "M4A Audio-only - AAC 48K"),
            new VideoInfoDesc(140, "M4A Audio-only - AAC 128K"),
            new VideoInfoDesc(141, "M4A Audio-only - AAC 256K"),
            new VideoInfoDesc(171, "WEBM Audio-only - OGG 128K"),
            new VideoInfoDesc(172, "WEBM Audio-only - OGG 192K"),
            new VideoInfoDesc(251, "WEBM Audio-only - OPUS 160K"),
            new VideoInfoDesc(250, "WEBM Audio-only - OPUS 70K"),
            new VideoInfoDesc(249, "WEBM Audio-only - OPUS 50K"),
            new VideoInfoDesc(313, "WEBM 2160p30 6K video-only"),
            new VideoInfoDesc(315, "WEBM 2160p60 6K video-only High bitrate"),
            new VideoInfoDesc(303, "WEBM 1080p60 HD video-only High bitrate"),
            new VideoInfoDesc(308, "WEBM 1440p60 4K video-only High bitrate"),
            new VideoInfoDesc(302, "WEBM 720p60 HD video-only High bitrate"),
            new VideoInfoDesc(298, "MP4 720p60 HD video-only High bitrate"),
            new VideoInfoDesc(299, "MP4 1080p60 HD video-only"),
            new VideoInfoDesc(337, "WEBM 2160p60 6K video-only Medium bitrate"),
            new VideoInfoDesc(335, "WEBM 1080p60 HD video-only Medium bitrate"),
            new VideoInfoDesc(336, "WEBM 1440p60 4K video-only Medium bitrate"),
            new VideoInfoDesc(334, "WEBM 720p60 HD  video-only Medium bitrate"),
            new VideoInfoDesc(332, "WEBM 360p video-only Medium bitrate"),
            new VideoInfoDesc(333, "WEBM 480p video-only Medium bitrate"),
            new VideoInfoDesc(331, "WEBM 240p video-only Medium bitrate"),
            new VideoInfoDesc(330, "WEBM 144p video-only Medium bitrate")
        };

        private VideoInfoDesc(int formatCode, string desc)
        {
            FormatCode = formatCode;
            Desc = desc;
        }

        public int FormatCode { get; internal set; }
        public string Desc { get; internal set; }
    }
}