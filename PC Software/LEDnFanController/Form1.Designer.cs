namespace LEDnFanController
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.btnSilent = new System.Windows.Forms.Button();
            this.btnPerf = new System.Windows.Forms.Button();
            this.btnAuto = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnSettings = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtMode = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtPort = new System.Windows.Forms.ToolStripTextBox();
            this.btnCustom = new System.Windows.Forms.Button();
            this.txtSpeed1 = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSpeed2 = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.grpFan = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblLEDBright = new System.Windows.Forms.Label();
            this.txtLEDBright = new System.Windows.Forms.NumericUpDown();
            this.txtLEDColorStart = new System.Windows.Forms.TextBox();
            this.txtLEDColorEnd = new System.Windows.Forms.TextBox();
            this.bwFanSpeedCalc = new System.ComponentModel.BackgroundWorker();
            this.bwDataSender = new System.ComponentModel.BackgroundWorker();
            this.tmrGeneric = new System.Windows.Forms.Timer(this.components);
            this.tmrFanSpeed = new System.Windows.Forms.Timer(this.components);
            this.tmrSendData = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpeed1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpeed2)).BeginInit();
            this.grpFan.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLEDBright)).BeginInit();
            this.SuspendLayout();
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 57600;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon1.BalloonTipText = "This app sits in the background so that it can work.\r\n";
            this.notifyIcon1.BalloonTipTitle = "LED Fan Controller";
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "LED Fan Controller";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // btnSilent
            // 
            this.btnSilent.Location = new System.Drawing.Point(237, 12);
            this.btnSilent.Name = "btnSilent";
            this.btnSilent.Size = new System.Drawing.Size(151, 26);
            this.btnSilent.TabIndex = 7;
            this.btnSilent.Text = "Silent Mode";
            this.btnSilent.UseVisualStyleBackColor = true;
            this.btnSilent.Click += new System.EventHandler(this.btnSilent_Click);
            // 
            // btnPerf
            // 
            this.btnPerf.Location = new System.Drawing.Point(237, 44);
            this.btnPerf.Name = "btnPerf";
            this.btnPerf.Size = new System.Drawing.Size(151, 26);
            this.btnPerf.TabIndex = 8;
            this.btnPerf.Text = "Performance Mode";
            this.btnPerf.UseVisualStyleBackColor = true;
            this.btnPerf.Click += new System.EventHandler(this.btnPerf_Click);
            // 
            // btnAuto
            // 
            this.btnAuto.Location = new System.Drawing.Point(237, 108);
            this.btnAuto.Name = "btnAuto";
            this.btnAuto.Size = new System.Drawing.Size(151, 26);
            this.btnAuto.TabIndex = 9;
            this.btnAuto.Text = "Auto Mode";
            this.btnAuto.UseVisualStyleBackColor = true;
            this.btnAuto.Click += new System.EventHandler(this.btnAuto_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSettings,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.txtMode,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.txtPort});
            this.toolStrip1.Location = new System.Drawing.Point(0, 150);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(405, 25);
            this.toolStrip1.TabIndex = 12;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.Resize += new System.EventHandler(this.frmMain_Resize);
            // 
            // btnSettings
            // 
            this.btnSettings.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnSettings.Image = ((System.Drawing.Image)(resources.GetObject("btnSettings.Image")));
            this.btnSettings.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(53, 22);
            this.btnSettings.Text = "Settings";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(81, 22);
            this.toolStripLabel1.Text = "Current Mode";
            // 
            // txtMode
            // 
            this.txtMode.Name = "txtMode";
            this.txtMode.ReadOnly = true;
            this.txtMode.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(60, 22);
            this.toolStripLabel2.Text = "COM Port";
            // 
            // txtPort
            // 
            this.txtPort.Name = "txtPort";
            this.txtPort.ReadOnly = true;
            this.txtPort.Size = new System.Drawing.Size(75, 25);
            // 
            // btnCustom
            // 
            this.btnCustom.Location = new System.Drawing.Point(237, 76);
            this.btnCustom.Name = "btnCustom";
            this.btnCustom.Size = new System.Drawing.Size(151, 26);
            this.btnCustom.TabIndex = 9;
            this.btnCustom.Text = "Custom Mode";
            this.btnCustom.UseVisualStyleBackColor = true;
            this.btnCustom.Click += new System.EventHandler(this.btnCustom_Click);
            // 
            // txtSpeed1
            // 
            this.txtSpeed1.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtSpeed1.Location = new System.Drawing.Point(101, 13);
            this.txtSpeed1.Name = "txtSpeed1";
            this.txtSpeed1.Size = new System.Drawing.Size(100, 20);
            this.txtSpeed1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "FAN 1";
            // 
            // txtSpeed2
            // 
            this.txtSpeed2.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.txtSpeed2.Location = new System.Drawing.Point(101, 39);
            this.txtSpeed2.Name = "txtSpeed2";
            this.txtSpeed2.Size = new System.Drawing.Size(100, 20);
            this.txtSpeed2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "FAN 2";
            // 
            // grpFan
            // 
            this.grpFan.Controls.Add(this.label2);
            this.grpFan.Controls.Add(this.txtSpeed2);
            this.grpFan.Controls.Add(this.label1);
            this.grpFan.Controls.Add(this.txtSpeed1);
            this.grpFan.Location = new System.Drawing.Point(12, 76);
            this.grpFan.Name = "grpFan";
            this.grpFan.Size = new System.Drawing.Size(206, 64);
            this.grpFan.TabIndex = 14;
            this.grpFan.TabStop = false;
            this.grpFan.Text = "Fan Control";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblLEDBright);
            this.groupBox1.Controls.Add(this.txtLEDBright);
            this.groupBox1.Controls.Add(this.txtLEDColorStart);
            this.groupBox1.Controls.Add(this.txtLEDColorEnd);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(206, 58);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "LED Settings";
            // 
            // lblLEDBright
            // 
            this.lblLEDBright.AutoSize = true;
            this.lblLEDBright.Location = new System.Drawing.Point(13, 29);
            this.lblLEDBright.Name = "lblLEDBright";
            this.lblLEDBright.Size = new System.Drawing.Size(80, 13);
            this.lblLEDBright.TabIndex = 2;
            this.lblLEDBright.Text = "LED Brightness";
            // 
            // txtLEDBright
            // 
            this.txtLEDBright.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtLEDBright.Location = new System.Drawing.Point(99, 25);
            this.txtLEDBright.Name = "txtLEDBright";
            this.txtLEDBright.Size = new System.Drawing.Size(100, 20);
            this.txtLEDBright.TabIndex = 1;
            // 
            // txtLEDColorStart
            // 
            this.txtLEDColorStart.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtLEDColorStart.Location = new System.Drawing.Point(17, 25);
            this.txtLEDColorStart.Name = "txtLEDColorStart";
            this.txtLEDColorStart.ReadOnly = true;
            this.txtLEDColorStart.Size = new System.Drawing.Size(78, 20);
            this.txtLEDColorStart.TabIndex = 0;
            this.txtLEDColorStart.Text = "Start Color";
            this.txtLEDColorStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLEDColorStart.Click += new System.EventHandler(this.txtLEDColorStart_Click);
            // 
            // txtLEDColorEnd
            // 
            this.txtLEDColorEnd.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtLEDColorEnd.Location = new System.Drawing.Point(101, 25);
            this.txtLEDColorEnd.Name = "txtLEDColorEnd";
            this.txtLEDColorEnd.ReadOnly = true;
            this.txtLEDColorEnd.Size = new System.Drawing.Size(78, 20);
            this.txtLEDColorEnd.TabIndex = 0;
            this.txtLEDColorEnd.Text = "End Color";
            this.txtLEDColorEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtLEDColorEnd.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtLEDColorEnd_MouseClick);
            // 
            // bwFanSpeedCalc
            // 
            this.bwFanSpeedCalc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwFanSpeedCalc_DoWork);
            // 
            // bwDataSender
            // 
            this.bwDataSender.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDataSender_DoWork);
            // 
            // tmrFanSpeed
            // 
            this.tmrFanSpeed.Enabled = true;
            this.tmrFanSpeed.Interval = 1000;
            this.tmrFanSpeed.Tick += new System.EventHandler(this.tmrFanSpeed_Tick);
            // 
            // tmrSendData
            // 
            this.tmrSendData.Enabled = true;
            this.tmrSendData.Interval = 5000;
            this.tmrSendData.Tick += new System.EventHandler(this.tmrSendData_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(405, 175);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpFan);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.btnCustom);
            this.Controls.Add(this.btnAuto);
            this.Controls.Add(this.btnPerf);
            this.Controls.Add(this.btnSilent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LED Color and Fan Speed Control";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpeed1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSpeed2)).EndInit();
            this.grpFan.ResumeLayout(false);
            this.grpFan.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLEDBright)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Button btnSilent;
        private System.Windows.Forms.Button btnPerf;
        private System.Windows.Forms.Button btnAuto;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtMode;
        private System.Windows.Forms.ToolStripButton btnSettings;
        private System.Windows.Forms.Button btnCustom;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtPort;
        private System.Windows.Forms.NumericUpDown txtSpeed1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txtSpeed2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpFan;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtLEDColorStart;
        private System.Windows.Forms.TextBox txtLEDColorEnd;
        private System.Windows.Forms.Label lblLEDBright;
        private System.Windows.Forms.NumericUpDown txtLEDBright;
        private System.ComponentModel.BackgroundWorker bwFanSpeedCalc;
        private System.ComponentModel.BackgroundWorker bwDataSender;
        private System.Windows.Forms.Timer tmrGeneric;
        private System.Windows.Forms.Timer tmrFanSpeed;
        private System.Windows.Forms.Timer tmrSendData;
    }
}

