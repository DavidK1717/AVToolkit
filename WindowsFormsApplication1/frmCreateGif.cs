using System.Windows.Forms;
using Util;

namespace AVToolkit
{
    public partial class frmCreateGif : frmExtractMultipleImages
    {
        //protected int passCount;


        public frmCreateGif()
        {
            InitializeComponent();

            //passCount = 1;
        }

        protected override void InstantiateOperationObject()
        {
            Op = new CreateGif(txtFile.Text) {OutputFile = new OutputFile()};
        }

        protected override void SetControlDefaults()
        {
            txtStartTime.Text = "00:00:00";
            txtDuration.Text = "35";
        }

        protected override void LoadCodecSpecificControls()
        {
            // left empty so as not to run base method.
        }

        protected new bool ValidateDuration()
        {
            var status = true;

            if (!Helper.IsNullorEmptyTrim(txtDuration.Text))
            {
                if (Helper.IsAllDigits(txtDuration.Text) == false)
                    status = false;
            }
            else
            {
                status = false;
            }

            errorProvider1.SetError(txtDuration, !status ? "Please enter a duration in seconds." : "");

            return status;
        }

        protected override void SetupOutput()
        {
            Op.AssignCodec("gif");
            Op.AssignOutputFilePath();
            txtOutputFileName.Text = Op.OutputFile.Path;
        }

        protected override void FfmpegParamUpdate()
        {
            Op.OutputFile.Fps = "15";
            Op.OutputFile.Scale = "320";
            Op.OutputFile.StartTime = txtStartTime.Text;
            Op.OutputFile.Duration = txtDuration.Text;

            // has the output file path changed? If so we need to tell the OutputFile object.                

            if (txtOutputFileName.Text != Op.OutputFile.Path)
                Op.OutputFile.Path = txtOutputFileName.Text;

            Op.AssignParameterString();
            txtParam.Text = Op.ParameterString;
            txtParam2.Text = ((CreateGif) Op).ParameterString2ndPass;

            toolTip1.SetToolTip(txtParam, txtParam.Text);
            toolTip1.SetToolTip(txtParam2, txtParam2.Text);
        }

        protected override void ProgressFinished(string labelText)
        {
            Invoke(new MethodInvoker(delegate
            {
                //progressBar1.Value = 100;
                //progressBar1.Update();
                lblProgress.Text = labelText;
            }));
        }


        protected virtual void ProgressFinishedCreateGif(int passCount)
        {
            if (passCount == 1)
                Invoke(new MethodInvoker(delegate
                {
                    progressBar1.Value = 50;
                    progressBar1.Update();
                    // run second pass
                    //passCount = 2;
                    //PerformSecondPass();
                }));
            else
                Invoke(new MethodInvoker(delegate
                {
                    progressBar1.Value = 100;
                    progressBar1.Update();
                }));
        }

        protected override void PerformOperation()
        {
            if (ValidateDuration())
            {
                ((CreateGif) Op).ProgressFinishedCreateGifCallback = ProgressFinishedCreateGif;

                base.PerformOperation();
            }
        }
        //}

        //    ffmpeg2.ExecuteAsync();
        //    Op.ProgressFinishedCreateGifCallback = ProgressFinishedCreateGif;
        //{

        //protected void PerformSecondPass()

        // ***************************** old code
    }
}