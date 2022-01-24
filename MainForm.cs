using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using AForge.Video;
using AForge.Video.DirectShow;
using System.Drawing.Imaging;
using System.IO;
using Microsoft.Win32;
using AForge.Vision.Motion;

using System.Threading;
using System.Runtime.InteropServices;
using System.Collections;


namespace Snapshoter
{
    public partial class MainForm : Form
    {
        //////////////////
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoDevice;
        private VideoCapabilities[] videoCapabilities;
        private VideoCapabilities[] snapshotCapabilities;

        private MotionDetector detector = new MotionDetector(
            new TwoFramesDifferenceDetector(),
            new MotionAreaHighlighting());

        private ImageFormat format = ImageFormat.Jpeg;
        private string patternFileName = string.Empty;
        private ulong Counter = 0;
        private float Sensitiv = 0.1f;
        private bool IsAutoDirectory = false;
        private bool IsStartCap = false;
        private bool IsMotion = false;
        private bool IsRecDraw = false;
        private bool IsVideo = false;


        private int ActualSnapshotWidth = 0;
        private int ActualSnapshotHeight = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        // Main form is loaded
        private void MainForm_Load(object sender, EventArgs e)
        {
            chkMotition.Checked = IsMotion;
            string DefaultCamera = RegistryManager.DefaultCamera;
            bool AutoSetCamera = false;
            videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count != 0)
            {
                for (int i = 0; i < videoDevices.Count; i++)
                {
                    devicesCombo.Items.Add(videoDevices[i].Name);
                    if (videoDevices[i].Name == DefaultCamera) { devicesCombo.SelectedIndex = i; AutoSetCamera = true; }
                }
            }
            else
            {
                devicesCombo.Items.Add("Устройства DirectShow не обнаружены");
            }
            if (!AutoSetCamera) devicesCombo.SelectedIndex = 0;
            detector.Reset();
            EnableConnectionControls(true);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Disconnect();
        }

        // Enable/disable connection related controls
        private void EnableConnectionControls(bool enable)
        {
            devicesCombo.Enabled = enable;
            connectButton.Enabled = enable;
            disconnectButton.Enabled = !enable;
            btnStartStopCap.Enabled = !enable;
            menuStartRec.Enabled = !enable;
        }

        // New video device is selected
        private void devicesCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (videoDevices.Count != 0)
            {
                videoDevice = new VideoCaptureDevice(videoDevices[devicesCombo.SelectedIndex].MonikerString);
            }
        }

        // On "Connect" button clicked
        private void connectButton_Click(object sender, EventArgs e)
        {
            if (videoDevice != null)
            {
                if ((snapshotCapabilities != null) && (snapshotCapabilities.Length != 0))
                {
                    videoDevice.ProvideSnapshots = true;

                    videoDevice.SnapshotFrame += new NewFrameEventHandler(videoDevice_SnapshotFrame);
                }
                patternFileName = ParsePattern("%Y %M %D %H %m %S-%C");
                if (chkMotition.Checked)// cmbSensitiv_SelectedIndexChanged(null, null);
                    ActualSnapshotWidth = videoDevice.DesiredFrameSize.Width;
                ActualSnapshotHeight = videoDevice.DesiredFrameSize.Height;

                EnableConnectionControls(false);

                videoSourcePlayer.VideoSource = videoDevice;
                videoSourcePlayer.Start();
            }
        }

        // On "Disconnect" button clicked
        private void disconnectButton_Click(object sender, EventArgs e)
        {
            if (IsStartCap) btnStartStopCap_Click(null, null);
            Disconnect();
        }

        // Disconnect from video device
        private void Disconnect()
        {
            if (videoSourcePlayer.VideoSource != null)
            {
                // stop video device
                videoSourcePlayer.SignalToStop();
                videoSourcePlayer.WaitForStop();
                videoSourcePlayer.VideoSource = null;

                if (videoDevice.ProvideSnapshots)
                {
                    videoDevice.SnapshotFrame -= new NewFrameEventHandler(videoDevice_SnapshotFrame);
                }

                EnableConnectionControls(true);
            }
            RegistryManager.IsMotition = chkMotition.Checked;
            RegistryManager.DefaultCamera = devicesCombo.SelectedItem.ToString();
        }

        // Simulate snapshot trigger
        private void triggerButton_Click(object sender, EventArgs e)
        {
            ShowSnapshot(videoSourcePlayer.GetCurrentVideoFrame());
        }

        // New snapshot frame is available
        private void videoDevice_SnapshotFrame(object sender, NewFrameEventArgs eventArgs)
        {
            ShowSnapshot((Bitmap)eventArgs.Frame.Clone());
        }

        private string ParsePattern(string input)
        {
            StringBuilder ret = new StringBuilder(input);
            ret.Replace("%Y", "{0}");
            ret.Replace("%M", "{1}");
            ret.Replace("%D", "{2}");
            ret.Replace("%H", "{3}");
            ret.Replace("%m", "{4}");
            ret.Replace("%S", "{5}");
            ret.Replace("%N", "{6}");
            ret.Replace("%C", "{7}");
            return ret.ToString();
        }

        private string GetNameFile()
        {
            GC.Collect(1);
            DateTime now = DateTime.Now;
            Counter = Counter == ulong.MaxValue ? 0 : ++Counter;

            string pathSave = "C:\\Users\\yanas\\Desktop";

            if (IsAutoDirectory)
            {
                string exist = Path.Combine(pathSave, string.Format("{0}.{1}.{2}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year));
                if (!Directory.Exists(exist)) Directory.CreateDirectory(exist);
                pathSave = exist;
            }
            pathSave = Path.Combine(pathSave, patternFileName);
            return string.Format(pathSave, now.Year, now.Month, now.Day, now.Hour, now.Minute, now.Second, devicesCombo.Text, Counter);
        }

        private void ShowSnapshot(Bitmap snapshot)
        {
            if (snapshot == null) return;
            if (InvokeRequired)
            {
                Invoke(new Action<Bitmap>(ShowSnapshot), snapshot);
            }
            else
            {
                float MotionLvl = 0f;
                if (detector == null && chkMotition.Checked) return;
                if (chkMotition.Checked) MotionLvl = detector.ProcessFrame((Bitmap)snapshot.Clone());

                string fileName = GetNameFile();
                fileName += "." + format.ToString();

                try
                {
                    if (IsMotion)
                    {
                        if (MotionLvl > Sensitiv)
                        {
                            if (!IsVideo) snapshot.Save(fileName, format);
                            IsRecDraw = true;
                        }
                    }
                    else
                    {
                        if (!IsVideo) snapshot.Save(fileName, format);
                        IsRecDraw = true;
                    }

                }
                catch (Exception ex)
                {
                    btnStartStopCap_Click(null, null);
                    MessageBox.Show("Ошибка сохранения скриншота.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void btnStartStopCap_Click(object sender, EventArgs e)
        {
            if (IsStartCap)
            {
                if (!IsMotion) IsRecDraw = false;
                btnStartStopCap.Text = "Начать запись";
                tmTimer.Stop();
                if (IsMotion)

                    IsStartCap = !IsStartCap;
            }
            else
            {
                if (!IsMotion) IsRecDraw = true;
                btnStartStopCap.Text = "Остановить";
                if (IsMotion) tmTimer.Interval = 1000;

                tmTimer.Start();

                IsStartCap = !IsStartCap;
            }
        }

        private void tmTimer_Tick(object sender, EventArgs e)
        {
            if (IsMotion) IsRecDraw = false;
            ShowSnapshot(videoSourcePlayer.GetCurrentVideoFrame());
        }

        private void chkMotition_CheckedChanged(object sender, EventArgs e)
        {
            IsMotion = chkMotition.Checked;
        }

    }
}