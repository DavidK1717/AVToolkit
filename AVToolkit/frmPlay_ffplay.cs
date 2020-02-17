using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace AVToolkit
{
    public partial class frmPlay_ffplay : Form
    {
        public Process ffplay = new Process();


        public frmPlay_ffplay()
        {
            InitializeComponent();
            Application.EnableVisualStyles();
            DoubleBuffered = true;
        }

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32.dll")]
        private static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        private void xxxFFplay()
        {
            // start ffplay 
            /*var ffplay = new Process
            {
                StartInfo =
                {
                    FileName = "ffplay.exe",
                    Arguments = "Revenge.mp4",
                    // hides the command window
                    CreateNoWindow = true,
                    // redirect input, output, and error streams..
                    //RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    UseShellExecute = false
                }
            };
             * */
            //public Process ffplay = new Process();
            ffplay.StartInfo.FileName = "ffplay.exe";
            ffplay.StartInfo.Arguments = "Everest.mp4";
            ffplay.StartInfo.CreateNoWindow = true;
            ffplay.StartInfo.RedirectStandardOutput = true;
            ffplay.StartInfo.UseShellExecute = false;

            ffplay.EnableRaisingEvents = true;
            ffplay.OutputDataReceived += (o, e) => Debug.WriteLine(e.Data ?? "NULL", "ffplay");
            ffplay.ErrorDataReceived += (o, e) => Debug.WriteLine(e.Data ?? "NULL", "ffplay");
            ffplay.Exited += (o, e) => Debug.WriteLine("Exited", "ffplay");
            ffplay.Start();

            Thread.Sleep(1500); // you need to wait/check the process started, then...

            // child, new parent
            // make 'this' the parent of ffmpeg (presuming you are in scope of a Form or Control)
            SetParent(ffplay.MainWindowHandle, Handle);

            // window, x, y, width, height, repaint
            // move the ffplayer window to the top-left corner and set the size to 320x280
            MoveWindow(ffplay.MainWindowHandle, 0, 0, 320, 280, true);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            xxxFFplay();
        }

        private void frmPlay_ffplay_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                ffplay.Kill();
            }
            catch
            {
            }
        }
    }
}