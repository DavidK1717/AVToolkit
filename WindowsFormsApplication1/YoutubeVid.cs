using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using DK.Util;
using YoutubeExtractor;

namespace VD
{
    public class YoutubeVid
    {
        private readonly DownloadSession parentDls;
        private readonly IEnumerable<VideoInfo> videos;
        private VideoInfo video;

        /// constructor
        public YoutubeVid(string url, DownloadSession dls)
        {
            MainUrl = url;
            parentDls = dls;

            //if invalid url does error handling work?            
            videos =
                DownloadUrlResolver.GetDownloadUrls(MainUrl)
                    .OrderByDescending(p => p.Resolution);

            VideoTitle = videos.ElementAt(0).Title;

            VideoID = Youtube.GetVideoId(MainUrl);

            if (!File.Exists(VideoID + ".jpg"))
            {
                var webClient = new WebClient();
                webClient.DownloadFile("http://img.youtube.com/vi/" + VideoID + "/1.jpg", VideoID + ".jpg");
            }

            parentDls.SessionVids.Add(this);
            Row = parentDls.SessionVids.Count - 1;
        }

        public string MainUrl { get; set; }
        public string VideoID { get; set; }
        public string VideoTitle { get; set; }
        public string FilePath { get; set; }

        public VideoDownloader Downloader { get; private set; }

        public int Row { get; set; }

        public int Secs { get; set; }

        public void LoadComboBox(ComboBox box)
        {
            for (var i = 0; i < videos.Count(); i++)
            {
                var item = "";
                var vi = videos.ElementAt(i);

                var formatCode = vi.FormatCode;

                var videoInfoDesc = VideoInfoDesc.Defaults.SingleOrDefault(p => p.FormatCode == formatCode);

                item = videoInfoDesc == null ? "Unknown" : videoInfoDesc.Desc;

                DownloadUrlResolver.QueryStreamSize(vi);

                item += " " + Helper.SizeSuffix(vi.FileSize);

                box.Items.Add(new ComboBoxItem(item, formatCode));
            }
        }

        public void PrepareDownload(int formatCode)
        {
            string ext;

            video = videos.First(p => p.FormatCode == formatCode);

            if (formatCode == 140 || formatCode == 141 || formatCode == 171)
                ext = video.AudioExtension;
            else
                ext = video.VideoExtension;

            if (video.RequiresDecryption)
                DownloadUrlResolver.DecryptDownloadUrl(video);

            FilePath = Path.Combine(parentDls.DownloadFolder + "\\", GetSafeFilename(video.Title) + ext);

            // check if file already exists because another file may be being downloaded with the same name.
            if (File.Exists(FilePath))
                FilePath = Path.Combine(parentDls.DownloadFolder, GetSafeFilename(video.Title)
                                                                  + "_" + Path.GetRandomFileName().Substring(0, 8)
                                                                  + ext);

            Downloader = new VideoDownloader(video, FilePath);
        }


        public void DownloadFile()
        {
            //TODO rewrite to allow for cancellation. May need to rewrite Downloader.Execute as well
            // https://msdn.microsoft.com/en-us/library/system.componentmodel.backgroundworker.aspx
            try
            {
                var bw = new BackgroundWorker();

                // define the event handlers

                bw.DoWork += (sender1, args) =>
                {
                    // this will happen in a separate thread

                    Downloader.Execute();
                };
                bw.RunWorkerCompleted += (sender1, args) =>
                {
                    if (args.Error != null) // if an exception occurred during DoWork,
                    {
                        MessageBox.Show(args.Error.ToString()); // do your error handling here
                    }
                    //ExceptionDispatchInfo.Capture(args.Error).Throw();
                };

                bw.RunWorkerAsync(); // starts the background worker 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private string GetLength(string url)
        {
            return "";
        }


        private string GetSafeFilename(string filename)
        {
            return string.Join("_", filename.Split(Path.GetInvalidFileNameChars()));
        }
    }
}