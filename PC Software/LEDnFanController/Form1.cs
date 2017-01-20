using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management;
using System.IO;

namespace LEDnFanController
{
    public partial class frmMain : Form
    {

        private double[,] fanSpeed = new Double[7,2];
        private List<Dictionary<string, double>> fanCurve = new List<Dictionary<string, double>>();
        private int lastSpeed = 0;

        public frmMain()
        {
            InitializeComponent();
            FormLoad();
            bwFanSpeedCalc.RunWorkerAsync();
        }

        private void btnLEDColor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            colorDialog1.AllowFullOpen = true;
            colorDialog1.FullOpen = true;
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.LEDColorStart = colorDialog1.Color;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Upgrade();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            frmSettings form = new frmSettings();
            form.FormClosed += new FormClosedEventHandler(frmSetting_FormClosed);
            form.ShowDialog();
        }

        void frmSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Restart();
        }

        //Data Manipulation
        private void FormLoad()
        {
            txtPort.Text = Properties.Settings.Default.Com;
            tmrGeneric.Interval = Properties.Settings.Default.SendInterval*1000;
            serialPort1.PortName = Properties.Settings.Default.Com;
            if (!Properties.Settings.Default.LEDTypeSingle){
                lblLEDBright.Hide();
                txtLEDBright.Hide();
                txtLEDColorEnd.Show();
                txtLEDColorStart.Show();
                txtLEDColorStart.BackColor = Properties.Settings.Default.LEDColorStart;
                txtLEDColorEnd.BackColor = Properties.Settings.Default.LEDColorEnd;
            }
            else{
                lblLEDBright.Show();
                txtLEDBright.Show();
                txtLEDColorEnd.Hide();
                txtLEDColorStart.Hide();
            }
            switch (Properties.Settings.Default.FanMode)
            {
                case 0:
                    btnSilent.Enabled = false;
                    grpFan.Enabled = false;
                    txtMode.Text = "Silent";
                    break;
                case 1:
                    btnPerf.Enabled = false;
                    grpFan.Enabled = false;
                    txtMode.Text = "Performance";
                    break;
                case 2:
                    btnCustom.Enabled = false;
                    txtMode.Text = "Custom";
                    grpFan.Enabled = true;
                    break;
                case 3:
                    grpFan.Enabled = false;
                    btnAuto.Enabled = false;
                    txtMode.Text = "Auto";
                    break;
            }
            string pointsString = Properties.Settings.Default.FanControllerPoints;
            string[] points = pointsString.Split(";".ToCharArray());
            int i = 0;
            foreach (string point in points)
            {
                if (point == "") continue;
                string[] pointxy = point.Split(",".ToCharArray());
                double x = Convert.ToDouble(pointxy[0]);
                double y = Convert.ToDouble(pointxy[1]);
                fanSpeed[i, 0] = x;
                fanSpeed[i, 1] = y;
                i++;
            }
            fanCurve = new List<Dictionary<string, double>>();
            for (i = 1; i < 7; i++)
            {
                double last_x = fanSpeed[i - 1, 0];
                double last_y = fanSpeed[i - 1, 1];
                double curr_x = fanSpeed[i, 0];
                double curr_y = fanSpeed[i, 1];
                double slope = (curr_y - last_y) / (curr_x - last_x);
                double y_inter = curr_y - curr_x * slope;
                int j = i - 1;
                fanCurve.Add(new Dictionary<string, double>());
                fanCurve[j].Add("min", last_x);
                fanCurve[j].Add("max", curr_x);
                fanCurve[j].Add("rate", slope);
                fanCurve[j].Add("c", y_inter);
            }
        }

        private void sendData()
        {
            int speed_f1 = Convert.ToInt32(txtSpeed1.Value);
            int speed_f2 = Convert.ToInt32(txtSpeed2.Value);
            int color_R = -1, color_G = -1, color_B = -1, bright = -1;
            if (!Properties.Settings.Default.LEDTypeSingle)
            {
                color_R = Properties.Settings.Default.LEDColorStart.R;
                color_G = Properties.Settings.Default.LEDColorStart.G;
                color_B = Properties.Settings.Default.LEDColorStart.B;
            }else
            {
                bright = Convert.ToInt32(txtLEDBright.Value);
            }
        }

        private int calcFanSpeed(double temp)
        {
            double grad = 0;
            foreach(Dictionary<string, double> gradient in fanCurve)
            {
                if(gradient["min"] <= temp && gradient["max"] > temp)
                {
                    grad = gradient["rate"];
                    break;
                }
            }
            int fanSpeed = Convert.ToInt32(grad * temp);
            return fanSpeed;
        }

        private string getWMIData()
        {
            String[] WMI_data = new string[2];
            WMI_data[0] = "temp:";
            WMI_data[1] = "load:";
            int[] temp = new int[2];
            int[] load = new int[3];
            ManagementScope scope = new ManagementScope(@"\root\OpenHardwareMonitor");
            scope.Connect();
            string[] logings = {
                "/intelcpu/0/load/0", "/nvidiagpu/0/load/2", "/ram/load/0",
                "/intelcpu/0/temperature/2", "/nvidiagpu/0/temperature/0"
            };
            List<WqlObjectQuery> queryList = new List<WqlObjectQuery>();
            foreach(string logitem in logings)
            {
                queryList.Add(new WqlObjectQuery("select * from sensor where identifier = '"+logitem+"'"));
            }
            foreach (ObjectQuery query in queryList)
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                foreach (ManagementObject data in searcher.Get())
                {
                    switch (data["SensorType"].ToString())
                    {
                        case "Temperature":
                            string[] temp1 = data["Name"].ToString().Split(" ".ToCharArray());
                            switch (temp1[0])
                            {
                                case "CPU":
                                    temp[0] = Convert.ToInt32(data["Value"]);
                                    break;
                                case "GPU":
                                    temp[1] = Convert.ToInt32(data["Value"]);
                                    break;
                            }
                            break;
                        case "Load":
                            string[] temp2 = data["Name"].ToString().Split(" ".ToCharArray());
                            switch (temp2[0])
                            {
                                case "CPU":
                                    load[0] = Convert.ToInt32(data["Value"]);
                                    break;
                                case "GPU":
                                    load[1] = Convert.ToInt32(data["Value"]);
                                    break;
                                case "Memory":
                                    load[2] = Convert.ToInt32(data["Value"]);
                                    break;
                            }
                            break;
                    }
                }
            }
            string temps = string.Join(",", temp.Select(x => x.ToString()).ToArray()) + ",";
            string loads = string.Join(",", load.Select(x => x.ToString()).ToArray()) + ",";
            WMI_data[0] += temps;
            WMI_data[1] += loads;
            string data_s = WMI_data[0] + ";" + WMI_data[1];
            return data_s;
        }
        
        //Minimize to Taskbar
        private void frmMain_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(500);
                this.Hide();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void btnSilent_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FanMode = 0;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            txtSpeed1.Value = 0;
            txtSpeed2.Value = 0;
            btnSilent.Enabled = false;
            btnPerf.Enabled = true;
            btnCustom.Enabled = true;
            btnAuto.Enabled = true;
            grpFan.Enabled = false;
            txtMode.Text = "Silent";
        }

        private void btnPerf_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FanMode = 1;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            txtSpeed1.Value = 100;
            txtSpeed2.Value = 100;
            btnPerf.Enabled = false;
            btnSilent.Enabled = true;
            btnCustom.Enabled = true;
            btnAuto.Enabled = true;
            grpFan.Enabled = false;
            txtMode.Text = "Performance";
        }

        private void btnCustom_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FanMode = 2;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            txtSpeed1.Value = 50;
            txtSpeed2.Value = 50;
            btnCustom.Enabled = false;
            btnPerf.Enabled = true;
            btnSilent.Enabled = true;
            btnAuto.Enabled = true;
            txtMode.Text = "Custom";
            grpFan.Enabled = true;
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.FanMode = 3;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
            bwFanSpeedCalc.RunWorkerAsync();
            btnPerf.Enabled = true;
            btnSilent.Enabled = true;
            btnCustom.Enabled = true;
            btnAuto.Enabled = false;
            grpFan.Enabled = false;
            txtMode.Text = "Auto";
        }

        private void txtLEDColorStart_Click(object sender, EventArgs e)
        {
            ColorDialog diag = new ColorDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                txtLEDColorStart.BackColor = diag.Color;
                txtLEDColorEnd.BackColor = diag.Color;
                Properties.Settings.Default.LEDColorStart = diag.Color;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
        }

        private void txtLEDColorEnd_MouseClick(object sender, MouseEventArgs e)
        {
            ColorDialog diag = new ColorDialog();
            if (diag.ShowDialog() == DialogResult.OK)
            {
                txtLEDColorEnd.BackColor = diag.Color;
                Properties.Settings.Default.LEDColorEnd = diag.Color;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
            }
        }

        private void bwFanSpeedCalc_DoWork(object sender, DoWorkEventArgs e)
        {
            var t = Properties.Settings.Default.FanMode;
            if (Properties.Settings.Default.FanMode == 3)
            {
                ManagementScope scope = new ManagementScope(@"\root\OpenHardwareMonitor");
                scope.Connect();
                WqlObjectQuery query = new WqlObjectQuery("select * from sensor where identifier = '" + "/intelcpu/0/temperature/2" + "'");
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                double temp = 0;
                int fSpeed = 0;
                foreach (ManagementObject data in searcher.Get())
                {
                    temp = Convert.ToDouble(data["Value"]);
                }
                foreach (Dictionary<string, double> item in fanCurve)
                {
                    if (item["min"] < temp && item["max"] > temp)
                    {
                        double fs_temp = temp * item["rate"] + item["c"];
                        fSpeed = (int)Math.Round(fs_temp / 5.0) * 5;
                        break;
                    }
                }
                this.Invoke(new MethodInvoker(delegate
                {
                    txtSpeed1.Value = fSpeed;
                    txtSpeed2.Value = fSpeed;
                }));
            }
        }

        private string getFanSpeed()
        {
            int fanSpeed1 = (int)txtSpeed1.Value;
            int fanSpeed2 = (int)txtSpeed2.Value;
            string fanData = "fans>" + fanSpeed1.ToString() + "," + fanSpeed2.ToString() + ",;";
            return fanData;
        }

        private void bwDataSender_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!serialPort1.IsOpen)
            {
                string data = "*"+dataInJSON();
                serialPort1.Open();
                serialPort1.WriteLine(data);
                serialPort1.Close();
                //*stat > temp:39,38,; load: 17,4,42,; fans > 50,50,;
            }
        }

        private string dataInJSON()
        {
            string[] json = new string[2];
            string data = "";
            var dataWMI = "stat>"+getWMIData();
            var dataFan = getFanSpeed();
            return data = dataWMI+";"+dataFan;
        }

        private void tmrFanSpeed_Tick(object sender, EventArgs e)
        {
            if (!bwFanSpeedCalc.IsBusy)
            {
                bwFanSpeedCalc.RunWorkerAsync();
            }
        }

        private void tmrSendData_Tick(object sender, EventArgs e)
        {
            if (!bwDataSender.IsBusy)
            {
                bwDataSender.RunWorkerAsync();
            }
        }
    }
}
