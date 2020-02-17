﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VD
{

    public class WEBM
    {
        public Stream[] streams { get; set; }
        public Format format { get; set; }
    }

    public class Format
    {
        public string filename { get; set; }
        public int nb_streams { get; set; }
        public int nb_programs { get; set; }
        public string format_name { get; set; }
        public string format_long_name { get; set; }
        public string start_time { get; set; }
        public string duration { get; set; }
        public string size { get; set; }
        public string bit_rate { get; set; }
        public int probe_score { get; set; }
        public Tags tags { get; set; }
    }

    public class Tags
    {
        public string encoder { get; set; }
    }

    public class Stream
    {
        public int index { get; set; }
        public string codec_name { get; set; }
        public string codec_long_name { get; set; }
        public string profile { get; set; }
        public string codec_type { get; set; }
        public string codec_time_base { get; set; }
        public string codec_tag_string { get; set; }
        public string codec_tag { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int coded_width { get; set; }
        public int coded_height { get; set; }
        public int has_b_frames { get; set; }
        public string sample_aspect_ratio { get; set; }
        public string display_aspect_ratio { get; set; }
        public string pix_fmt { get; set; }
        public int level { get; set; }
        public string color_range { get; set; }
        public string color_transfer { get; set; }
        public string color_primaries { get; set; }
        public string chroma_location { get; set; }
        public int refs { get; set; }
        public string r_frame_rate { get; set; }
        public string avg_frame_rate { get; set; }
        public string time_base { get; set; }
        public int start_pts { get; set; }
        public string start_time { get; set; }
        public Disposition disposition { get; set; }
        public Tags1 tags { get; set; }
        public Side_Data_List[] side_data_list { get; set; }
    }

    public class Disposition
    {
        public int _default { get; set; }
        public int dub { get; set; }
        public int original { get; set; }
        public int comment { get; set; }
        public int lyrics { get; set; }
        public int karaoke { get; set; }
        public int forced { get; set; }
        public int hearing_impaired { get; set; }
        public int visual_impaired { get; set; }
        public int clean_effects { get; set; }
        public int attached_pic { get; set; }
        public int timed_thumbnails { get; set; }
    }

    public class Tags1
    {
        public string language { get; set; }
    }

    public class Side_Data_List
    {
        public string side_data_type { get; set; }
    }

}
