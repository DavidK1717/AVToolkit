using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Util;
using Newtonsoft.Json.Linq;
using DKUtil;

namespace AVToolkit
{
    public partial class FrmNormaliseAudio : frmOperation
    {
        string FirstPassParameterStringTemp;

        public FrmNormaliseAudio()
        {
            InitializeComponent();

            VideoCodecs = new[] { "copy" };
        }

        protected override void InstantiateOperationObject()
        {
           Op = new NormaliseAudio(txtFile.Text) { OutputFile = new OutputFile() };
        }
        
        protected override void SetupOutput()
        {
            Op.AssignCodec("Copy");
            Op.OutputFile.Codec.Extension = Path.GetExtension(Op.InputFile.Path);
            Op.AssignOutputFilePath();
            txtOutputFileName.Text = Op.OutputFile.Path;
        }

        protected override void AdditionalProcessing()
        {
            // initial operation can be slow so keep the user informed
            lblWorking.Visible = true;
            Application.DoEvents();

            ((NormaliseAudio)Op).DeleteExistingFile();

            ((NormaliseAudio)Op).AssignParameterStringFirstPass();

            Op.Execute();

            ((NormaliseAudio)Op).CreateJObject();

            UpdateLoudNormDetails(txtLoudNormIn, ((NormaliseAudio)Op).JObj);

            lblWorking.Visible = false;
        }

        protected override void LoadFileTypesCombo()
        {
            cboFileType.Items.Clear();

            foreach (var t in VideoCodecs)
                cboFileType.Items.Add(t);

            cboFileType.SelectedIndex = 0;
        }

        protected override void FfmpegParamUpdate()
        {
           if (txtOutputFileName.Text != Op.OutputFile.Path)
                Op.OutputFile.Path = txtOutputFileName.Text;

            Op.AssignParameterString();

            txtParam.Text = Op.ParameterString;

            FirstPassParameterStringTemp = Op.ParameterString;

            txtParam2.Text = ((NormaliseAudio)Op).ParameterString2ndPass;

            toolTip1.SetToolTip(txtParam, txtParam.Text);
            toolTip1.SetToolTip(txtParam2, txtParam2.Text);
        }

        protected override void ProgressFinished(string labelText)
        {
            Invoke(new MethodInvoker(delegate
            {
                lblProgress.Text = labelText;
            }));
        }

        protected virtual void ProgressFinishedNormaliseAudio(int passCount)
        {
            var FileNameTemp = ((NormaliseAudio)Op).FileName;

            if (passCount == 1)
                Invoke(new MethodInvoker(delegate
                {
                    progressBar1.Value = 30;
                    progressBar1.Update();

                    ((NormaliseAudio)Op).CreateJObject();

                    UpdateLoudNormDetails(txtLoudNormIn, ((NormaliseAudio)Op).JObj);
                }));
            else if (passCount == 2)
                Invoke(new MethodInvoker(delegate
                {
                    progressBar1.Value = 70;
                    progressBar1.Update();

                    ((NormaliseAudio)Op).FileName = "loudnorm2.json";

                    ((NormaliseAudio)Op).DeleteExistingFile();
                }));
            else
                Invoke(new MethodInvoker(delegate
                {
                    progressBar1.Value = 100;
                    progressBar1.Update();

                    ((NormaliseAudio)Op).CreateJObject();

                    UpdateLoudNormDetails(txtLoudNormOut, ((NormaliseAudio)Op).JObj);

                    ((NormaliseAudio)Op).FileName = FileNameTemp;

                    lblWorking.Visible = false;
                }));
        }

        protected override void PerformOperation()
        {
            // initial operation can be slow so keep the user informed
            lblWorking.Visible = true;
            Application.DoEvents();

            ((NormaliseAudio) Op).ProgressFinishedNormaliseAudioCallback = ProgressFinishedNormaliseAudio;

            base.PerformOperation();
        }

        protected virtual void UpdateLoudNormDetails(TextBox txt, JObject jO)
        {
            txt.Text = "Input Integrated: " + (string) jO["input_i"] + " LUFS";
            txt.AppendText(Environment.NewLine);
            txt.AppendText("Input True Peak: " + (string)jO["input_tp"] + " dBTP");
            txt.AppendText(Environment.NewLine);
            txt.AppendText("Input LRA: " + (string)jO["input_lra"] + " LU");
            txt.AppendText(Environment.NewLine);
            txt.AppendText("Input Threshold: " + (string)jO["input_thresh"] + " LUFS");
            txt.AppendText(Environment.NewLine);
            txt.AppendText("Output Integrated: " + (string)jO["output_i"] + " LUFS");
            txt.AppendText(Environment.NewLine);
            txt.AppendText("Output True Peak: " + (string)jO["output_tp"] + " dBTP");
            txt.AppendText(Environment.NewLine);
            txt.AppendText("Output LRA: " + (string)jO["output_lra"] + " LU");
            txt.AppendText(Environment.NewLine);
            txt.AppendText("Output Threshold: " + (string)jO["output_thresh"] + " LUFS");
            txt.AppendText(Environment.NewLine);
            txt.AppendText("Normalization Type: " + Helper.UppercaseFirst((string)jO["normalization_type"]));
            txt.AppendText(Environment.NewLine);
            txt.AppendText("Target Offset: " + (string)jO["target_offset"] + " LU");
            txt.AppendText(Environment.NewLine);
        }
    }
}
