using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;

namespace LEDnFanController
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            FormLoad();
        }

        private void FormLoad()
        {
            foreach (string s in SerialPort.GetPortNames())
            {
                cmdPorts.Items.Add(s);
            }
            cmdPorts.Text = Properties.Settings.Default.Com;
            if (Properties.Settings.Default.LEDTypeSingle)
            {
                radLED1.Select();
            }else
            {
                radLED2.Select();
            }
        }

        private void listAvailable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Com = cmdPorts.Text;
            if (radLED1.Checked)
            {
                Properties.Settings.Default.LEDTypeSingle = true;
            }else if (radLED2.Checked)
            {
                Properties.Settings.Default.LEDTypeSingle = false;
            }
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Upgrade();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFanCurve_Click(object sender, EventArgs e)
        {
            frmFanCurve curveForm = new frmFanCurve();
            curveForm.ShowDialog();
        }
    }
}
