using System.Collections.Generic;

namespace VD
{
    public class DownloadSession
    {
        /// constructor
        public DownloadSession()
        {
            SessionVids = new List<YoutubeVid>();
        }

        public int CurrentRow { get; set; }

        public string DownloadFolder { get; set; }

        public List<YoutubeVid> SessionVids { get; set; }

        // get specific item from list
        public YoutubeVid GetVid(int pos)
        {
            //if (pos < AvailableVids.Count - 1)
            return SessionVids[pos];
            //else
            //    return null;
        }
    }
}