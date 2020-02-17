using System;
using System.Windows.Forms;
using AxWMPLib;

namespace AVToolkit
{
    public partial class frmPlay : Form
    {
        public frmPlay()
        {
            InitializeComponent();
        }

        public frmPlay(string fileUrl)
        {
            InitializeComponent();
            axPlayer.URL = fileUrl;
        }

        public frmPlay(string fileUrl, double startPosition)
        {
            InitializeComponent();
            axPlayer.URL = fileUrl;
            axPlayer.Ctlcontrols.currentPosition = startPosition;
        }

        private void frmPlay_Load(object sender, EventArgs e)
        {
        }

        private void axPlayer_PlayStateChange(object sender, _WMPOCXEvents_PlayStateChangeEvent e)
        {
            const int PAUSED_STATE = 2;

            if (Modal)
                if (e.newState == PAUSED_STATE)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
        }

        public double GetPausedTime()
        {
            return axPlayer.Ctlcontrols.currentPosition;
        }

        public string GetPausedTimeString()
        {
            return axPlayer.Ctlcontrols.currentPositionString;
        }
    }
}