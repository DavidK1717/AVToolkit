using System.Windows.Forms;
using DK.Util;

namespace VD
{
    public partial class frmBrowser : Form
    {
        private readonly frmDownload _form3;
        private string _uri_temp = "";

        // would like to do this using a delegate or Action or func and leave method as private in Form3
        //private Action<string> _addUrlToDownloadList;
        // got code from here http://www.homeandlearn.co.uk/csharp/csharp_s13p3.html
        public frmBrowser()
        {
            InitializeComponent();
        }

        public frmBrowser(frmDownload form3)
        {
            InitializeComponent();

            _form3 = form3;
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            //MessageBox.Show("Navigated");
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //MessageBox.Show("Completed");
            // for some reason DocumentCompleted event fires multiple times so only use it once for each url
            if (_uri_temp != webBrowser1.Url.ToString())
                if (webBrowser1.Url.ToString().Contains("https://www.youtube.com/watch?v="))
                    if (Dialogs.YesNo("Add " + webBrowser1.Url + " to download list?", "Badger speaks!"))
                    {
                        _form3.AddUrlToDownloadList(webBrowser1.Url.ToString());
                        _uri_temp = webBrowser1.Url.ToString();
                    }
        }
    }
}