using System;
using System.IO;
using System.Reflection;

namespace AVToolkit
{
    public partial class FrmExtractSection : frmExtractMultipleImages
    {
        public FrmExtractSection()
        {
            InitializeComponent();
        }

        protected override void InstantiateOperationObject()
        {
            Op = new ExtractSection(txtFile.Text) {OutputFile = new OutputFile()};
        }

        protected override void LoadCodecSpecificControls()
        {
            // does nothing. Just prevents base class code from running.
        }

        protected override void SetupOutput()
        {
            Op.AssignCodec("copy");
            Op.OutputFile.Codec.Extension = Path.GetExtension(Op.InputFile.Path);
            Op.AssignOutputFilePath();
            txtOutputFileName.Text = Op.OutputFile.Path;
        }


        protected override void FfmpegParamUpdate()
        {
            Op.OutputFile.StartTime = txtStartTime.Text;
            Op.OutputFile.Duration = txtDuration.Text;
            Op.OutputFile.ToEnd = chkEnd.Checked;

            // It may be bad design in that it contravenes the principle of abstraction but
            // here we want to call the grand base class not the base class so
            // base.FfmpegParamUpdate() will not do it. This works:
            var ptr = typeof(frmOperation)
                .GetMethod("FfmpegParamUpdate", BindingFlags.Instance | BindingFlags.NonPublic).MethodHandle
                .GetFunctionPointer();
            var grandBaseFfmpegParamUpdate = (Action) Activator.CreateInstance(typeof(Action), this, ptr);
            grandBaseFfmpegParamUpdate();
        }
    }
}