using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LEDnFanController
{
    public partial class frmFanCurve : Form
    {
        ChartArea ca_ = null;
        Series s_ = null;
        DataPoint dp_ = null;
        bool synched = false;
        public frmFanCurve()
        {
            InitializeComponent();
            initChart();
        }

        private void initChart()
        {
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.Maximum = 100;
            chart1.ChartAreas[0].AxisY.Maximum = 100;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            chart1.ChartAreas[0].AxisX.Interval = 5;
            chart1.ChartAreas[0].AxisY.Interval = 5;
            Series series = chart1.Series.Add("Fan Curve");
            series.ChartType = SeriesChartType.Line;
            chart1.Series[0].MarkerSize = 10;
            chart1.Series[0].MarkerStyle = MarkerStyle.Square;
            string watch = Properties.Settings.Default.FanControllerPoints;
            string[] points = watch.Split(";".ToCharArray());
            foreach(string point in points)
            {
                if (point == "") continue;
                string[] pointxy = point.Split(",".ToCharArray());
                string x = pointxy[0];
                string y = pointxy[1];
                series.Points.AddXY(Math.Round(Convert.ToDouble(x) / 5.0)*5, Math.Round(Convert.ToDouble(y)/5)*5);
            }
            ca_ = chart1.ChartAreas[0];
            s_ = chart1.Series[0];
        }

        private void frmFanCurve_FormClosing(object sender, FormClosingEventArgs e)
        {
            string pointList = "";
            int i = 0;
            foreach (System.Windows.Forms.DataVisualization.Charting.DataPoint point in chart1.Series[0].Points)
            {
                pointList += Convert.ToString(point.XValue) + "," +Convert.ToString(point.YValues[0]) + ";";
                i++;
            }
            Properties.Settings.Default.FanControllerPoints = pointList;
            Properties.Settings.Default.Save();
        }

        void SyncAllPoints(ChartArea ca, Series s)
        {
            foreach (DataPoint dp in s.Points) SyncAPoint(ca, s, dp);
            synched = true;
        }

        void SyncAPoint(ChartArea ca, Series s, DataPoint dp)
        {
            float mh = dp.MarkerSize / 2f;
            float px = (float)ca.AxisX.ValueToPixelPosition(dp.XValue);
            float py = (float)ca.AxisY.ValueToPixelPosition(dp.YValues[0]);
            dp.Tag = (new RectangleF(px - mh, py - mh, dp.MarkerSize, dp.MarkerSize));
        }

        private void chart1_Resize(object sender, EventArgs e)
        {
            synched = false;
        }

        private void chart1_PrePaint(object sender, ChartPaintEventArgs e)
        {
            if (!synched) SyncAllPoints(ca_, s_);
        }

        private void chart1_MouseDown(object sender, MouseEventArgs e)
        {
            foreach (DataPoint dp in s_.Points)
                if (((RectangleF)dp.Tag).Contains(e.Location))
                {
                    dp.Color = Color.Orange;
                    dp_ = dp;
                    break;
                }
        }

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button.HasFlag(MouseButtons.Left) && dp_ != null)
            {
                float mh = dp_.MarkerSize / 2f;
                double vx = ca_.AxisX.PixelPositionToValue(e.Location.X);
                double vy = ca_.AxisY.PixelPositionToValue(e.Location.Y);

                dp_.SetValueXY(vx, vy);
                SyncAPoint(ca_, s_, dp_);
                chart1.Invalidate();
            }
            //else
            //{
            //    Cursor = Cursors.Default;
            //    foreach (DataPoint dp in s_.Points)
            //    {
            //        if (((RectangleF)dp.Tag).Contains(e.Location))
            //        {
            //            Cursor = Cursors.Hand; break;
            //        }
            //    }
            //}
        }

        private void chart1_MouseUp(object sender, MouseEventArgs e)
        {
            if (dp_ != null)
            {
                dp_.Color = s_.Color;
                dp_ = null;
            }
        }
    }
}
