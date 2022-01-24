namespace Snapshoter
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.devicesCombo = new System.Windows.Forms.ComboBox();
            this.connectButton = new System.Windows.Forms.Button();
            this.disconnectButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.videoSourcePlayer = new AForge.Controls.VideoSourcePlayer();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tbVision = new System.Windows.Forms.TabPage();
            this.tbOption = new System.Windows.Forms.TabPage();
            this.chkMotition = new System.Windows.Forms.CheckBox();
            this.btnStartStopCap = new System.Windows.Forms.Button();
            this.tmTimer = new System.Windows.Forms.Timer(this.components);
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.notifyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStartRec = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tbVision.SuspendLayout();
            this.tbOption.SuspendLayout();
            this.notifyContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Камера";
            // 
            // devicesCombo
            // 
            this.devicesCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.devicesCombo.FormattingEnabled = true;
            this.devicesCombo.Location = new System.Drawing.Point(75, 9);
            this.devicesCombo.Margin = new System.Windows.Forms.Padding(4);
            this.devicesCombo.Name = "devicesCombo";
            this.devicesCombo.Size = new System.Drawing.Size(524, 24);
            this.devicesCombo.TabIndex = 1;
            this.devicesCombo.SelectedIndexChanged += new System.EventHandler(this.devicesCombo_SelectedIndexChanged);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(623, 9);
            this.connectButton.Margin = new System.Windows.Forms.Padding(4);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(119, 28);
            this.connectButton.TabIndex = 6;
            this.connectButton.Text = "&Подключить";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // disconnectButton
            // 
            this.disconnectButton.Location = new System.Drawing.Point(623, 45);
            this.disconnectButton.Margin = new System.Windows.Forms.Padding(4);
            this.disconnectButton.Name = "disconnectButton";
            this.disconnectButton.Size = new System.Drawing.Size(119, 28);
            this.disconnectButton.TabIndex = 7;
            this.disconnectButton.Text = "&Отключить";
            this.disconnectButton.UseVisualStyleBackColor = true;
            this.disconnectButton.Click += new System.EventHandler(this.disconnectButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.videoSourcePlayer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(4, 4);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(827, 514);
            this.panel1.TabIndex = 8;
            // 
            // videoSourcePlayer
            // 
            this.videoSourcePlayer.AutoSizeControl = true;
            this.videoSourcePlayer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.videoSourcePlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoSourcePlayer.ForeColor = System.Drawing.Color.DarkRed;
            this.videoSourcePlayer.Location = new System.Drawing.Point(0, 0);
            this.videoSourcePlayer.Margin = new System.Windows.Forms.Padding(4);
            this.videoSourcePlayer.Name = "videoSourcePlayer";
            this.videoSourcePlayer.Size = new System.Drawing.Size(827, 514);
            this.videoSourcePlayer.TabIndex = 0;
            this.videoSourcePlayer.VideoSource = null;
            // 
            // toolTip
            // 
            this.toolTip.AutoPopDelay = 5000;
            this.toolTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.toolTip.InitialDelay = 100;
            this.toolTip.ReshowDelay = 100;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tbVision);
            this.tabControl.Controls.Add(this.tbOption);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(843, 551);
            this.tabControl.TabIndex = 10;
            // 
            // tbVision
            // 
            this.tbVision.Controls.Add(this.panel1);
            this.tbVision.Location = new System.Drawing.Point(4, 25);
            this.tbVision.Margin = new System.Windows.Forms.Padding(4);
            this.tbVision.Name = "tbVision";
            this.tbVision.Padding = new System.Windows.Forms.Padding(4);
            this.tbVision.Size = new System.Drawing.Size(835, 522);
            this.tbVision.TabIndex = 0;
            this.tbVision.Text = "Просмотр";
            this.tbVision.UseVisualStyleBackColor = true;
            // 
            // tbOption
            // 
            this.tbOption.Controls.Add(this.chkMotition);
            this.tbOption.Controls.Add(this.btnStartStopCap);
            this.tbOption.Controls.Add(this.devicesCombo);
            this.tbOption.Controls.Add(this.label1);
            this.tbOption.Controls.Add(this.disconnectButton);
            this.tbOption.Controls.Add(this.connectButton);
            this.tbOption.Location = new System.Drawing.Point(4, 25);
            this.tbOption.Margin = new System.Windows.Forms.Padding(4);
            this.tbOption.Name = "tbOption";
            this.tbOption.Padding = new System.Windows.Forms.Padding(4);
            this.tbOption.Size = new System.Drawing.Size(835, 522);
            this.tbOption.TabIndex = 1;
            this.tbOption.Text = "Настройки";
            this.tbOption.UseVisualStyleBackColor = true;
            // 
            // chkMotition
            // 
            this.chkMotition.AutoSize = true;
            this.chkMotition.Location = new System.Drawing.Point(12, 51);
            this.chkMotition.Margin = new System.Windows.Forms.Padding(4);
            this.chkMotition.Name = "chkMotition";
            this.chkMotition.Size = new System.Drawing.Size(185, 21);
            this.chkMotition.TabIndex = 10;
            this.chkMotition.Text = "Отслеживать движение";
            this.chkMotition.UseVisualStyleBackColor = true;
            this.chkMotition.CheckedChanged += new System.EventHandler(this.chkMotition_CheckedChanged);
            // 
            // btnStartStopCap
            // 
            this.btnStartStopCap.Location = new System.Drawing.Point(286, 51);
            this.btnStartStopCap.Margin = new System.Windows.Forms.Padding(4);
            this.btnStartStopCap.Name = "btnStartStopCap";
            this.btnStartStopCap.Size = new System.Drawing.Size(313, 62);
            this.btnStartStopCap.TabIndex = 10;
            this.btnStartStopCap.Text = "Начать запись";
            this.btnStartStopCap.UseVisualStyleBackColor = true;
            this.btnStartStopCap.Click += new System.EventHandler(this.btnStartStopCap_Click);
            // 
            // tmTimer
            // 
            this.tmTimer.Interval = 4000;
            this.tmTimer.Tick += new System.EventHandler(this.tmTimer_Tick);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipText = "Скриншотер";
            this.notifyIcon.ContextMenuStrip = this.notifyContextMenu;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Visible = true;
            // 
            // notifyContextMenu
            // 
            this.notifyContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.notifyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuOpen,
            this.menuStartRec});
            this.notifyContextMenu.Name = "notifyContextMenu";
            this.notifyContextMenu.Size = new System.Drawing.Size(267, 52);
            // 
            // menuOpen
            // 
            this.menuOpen.Name = "menuOpen";
            this.menuOpen.Size = new System.Drawing.Size(266, 24);
            this.menuOpen.Text = "Открыть";
            // 
            // menuStartRec
            // 
            this.menuStartRec.Name = "menuStartRec";
            this.menuStartRec.Size = new System.Drawing.Size(266, 24);
            this.menuStartRec.Text = "Начать/Остановить запись";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 551);
            this.Controls.Add(this.tabControl);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(847, 580);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tbVision.ResumeLayout(false);
            this.tbOption.ResumeLayout(false);
            this.tbOption.PerformLayout();
            this.notifyContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox devicesCombo;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button disconnectButton;
        private System.Windows.Forms.Panel panel1;
        private AForge.Controls.VideoSourcePlayer videoSourcePlayer;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tbVision;
        private System.Windows.Forms.TabPage tbOption;
        private System.Windows.Forms.Button btnStartStopCap;
        private System.Windows.Forms.Timer tmTimer;
        private System.Windows.Forms.CheckBox chkMotition;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip notifyContextMenu;
        private System.Windows.Forms.ToolStripMenuItem menuOpen;
        private System.Windows.Forms.ToolStripMenuItem menuStartRec;
    }
}

