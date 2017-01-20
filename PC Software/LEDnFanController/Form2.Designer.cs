namespace LEDnFanController
{
    partial class frmSettings
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
            this.cmdPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpLCD = new System.Windows.Forms.GroupBox();
            this.btnLCD = new System.Windows.Forms.Button();
            this.listAvailable = new System.Windows.Forms.CheckedListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpLEDType = new System.Windows.Forms.GroupBox();
            this.radLED1 = new System.Windows.Forms.RadioButton();
            this.radLED2 = new System.Windows.Forms.RadioButton();
            this.grpMisc = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFanCurve = new System.Windows.Forms.Button();
            this.grpLCD.SuspendLayout();
            this.grpLEDType.SuspendLayout();
            this.grpMisc.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmdPorts
            // 
            this.cmdPorts.FormattingEnabled = true;
            this.cmdPorts.Location = new System.Drawing.Point(87, 12);
            this.cmdPorts.Name = "cmdPorts";
            this.cmdPorts.Size = new System.Drawing.Size(196, 21);
            this.cmdPorts.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "COM Port";
            // 
            // grpLCD
            // 
            this.grpLCD.Controls.Add(this.btnLCD);
            this.grpLCD.Controls.Add(this.listAvailable);
            this.grpLCD.Location = new System.Drawing.Point(155, 48);
            this.grpLCD.Name = "grpLCD";
            this.grpLCD.Size = new System.Drawing.Size(137, 201);
            this.grpLCD.TabIndex = 3;
            this.grpLCD.TabStop = false;
            this.grpLCD.Text = "LCD Display";
            // 
            // btnLCD
            // 
            this.btnLCD.Location = new System.Drawing.Point(29, 20);
            this.btnLCD.Name = "btnLCD";
            this.btnLCD.Size = new System.Drawing.Size(75, 23);
            this.btnLCD.TabIndex = 1;
            this.btnLCD.Text = "&Toggle LCD";
            this.btnLCD.UseVisualStyleBackColor = true;
            // 
            // listAvailable
            // 
            this.listAvailable.FormattingEnabled = true;
            this.listAvailable.Items.AddRange(new object[] {
            "CPU Temp",
            "CPU Usage",
            "RAM Usage",
            "GPU Temp",
            "GPU Usage"});
            this.listAvailable.Location = new System.Drawing.Point(6, 49);
            this.listAvailable.Name = "listAvailable";
            this.listAvailable.Size = new System.Drawing.Size(125, 139);
            this.listAvailable.TabIndex = 0;
            this.listAvailable.SelectedIndexChanged += new System.EventHandler(this.listAvailable_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(74, 255);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.button2_Click);
            // 
            // grpLEDType
            // 
            this.grpLEDType.Controls.Add(this.radLED2);
            this.grpLEDType.Controls.Add(this.radLED1);
            this.grpLEDType.Location = new System.Drawing.Point(12, 48);
            this.grpLEDType.Name = "grpLEDType";
            this.grpLEDType.Size = new System.Drawing.Size(137, 82);
            this.grpLEDType.TabIndex = 5;
            this.grpLEDType.TabStop = false;
            this.grpLEDType.Text = "LED Type";
            // 
            // radLED1
            // 
            this.radLED1.AutoSize = true;
            this.radLED1.Location = new System.Drawing.Point(6, 26);
            this.radLED1.Name = "radLED1";
            this.radLED1.Size = new System.Drawing.Size(81, 17);
            this.radLED1.TabIndex = 0;
            this.radLED1.TabStop = true;
            this.radLED1.Text = "Single Color";
            this.radLED1.UseVisualStyleBackColor = true;
            // 
            // radLED2
            // 
            this.radLED2.AutoSize = true;
            this.radLED2.Location = new System.Drawing.Point(6, 49);
            this.radLED2.Name = "radLED2";
            this.radLED2.Size = new System.Drawing.Size(96, 17);
            this.radLED2.TabIndex = 0;
            this.radLED2.TabStop = true;
            this.radLED2.Text = "Multicolor RGB";
            this.radLED2.UseVisualStyleBackColor = true;
            // 
            // grpMisc
            // 
            this.grpMisc.Controls.Add(this.textBox1);
            this.grpMisc.Controls.Add(this.label2);
            this.grpMisc.Location = new System.Drawing.Point(17, 143);
            this.grpMisc.Name = "grpMisc";
            this.grpMisc.Size = new System.Drawing.Size(132, 58);
            this.grpMisc.TabIndex = 6;
            this.grpMisc.TabStop = false;
            this.grpMisc.Text = "Misc";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Update Time (in s)";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(155, 255);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFanCurve
            // 
            this.btnFanCurve.Location = new System.Drawing.Point(17, 213);
            this.btnFanCurve.Name = "btnFanCurve";
            this.btnFanCurve.Size = new System.Drawing.Size(132, 23);
            this.btnFanCurve.TabIndex = 7;
            this.btnFanCurve.Text = "Auto Fan Curve";
            this.btnFanCurve.UseVisualStyleBackColor = true;
            this.btnFanCurve.Click += new System.EventHandler(this.btnFanCurve_Click);
            // 
            // frmSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 292);
            this.ControlBox = false;
            this.Controls.Add(this.btnFanCurve);
            this.Controls.Add(this.grpMisc);
            this.Controls.Add(this.grpLEDType);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpLCD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdPorts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmSettings";
            this.Text = "Settings";
            this.grpLCD.ResumeLayout(false);
            this.grpLEDType.ResumeLayout(false);
            this.grpLEDType.PerformLayout();
            this.grpMisc.ResumeLayout(false);
            this.grpMisc.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmdPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpLCD;
        private System.Windows.Forms.CheckedListBox listAvailable;
        private System.Windows.Forms.Button btnLCD;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox grpLEDType;
        private System.Windows.Forms.RadioButton radLED2;
        private System.Windows.Forms.RadioButton radLED1;
        private System.Windows.Forms.GroupBox grpMisc;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFanCurve;
    }
}