using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CHART_DEMO
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Title title1 = new Title();
            title1.Text = "总合格率（%）";
            title1.ForeColor = Color.Blue;
            this.chart1.Titles.Add(title1);


            this.chart1.Series.Clear();
            Series series1 = new Series();
            series1.ChartType = SeriesChartType.Pie;
            this.chart1.Series.Add(series1);


            int[] percents = new int[3] { 50, 30, 20 };
            string[] pointsText = new string[3] { "紧急", "严重", "普通" };
            Color[] myColor = new Color[3] { Color.FromArgb(0, 183, 238),
                                              Color.FromArgb(250, 205, 137),
                                                Color.FromArgb(255, 124, 255)};
            DataPoint[] AllPoints = new DataPoint[3];
            for (int i = 0; i < AllPoints.Length; i++)
            {
                AllPoints[i] = new DataPoint(i + 1, percents[i]);
                AllPoints[i].LegendText = pointsText[i];
                AllPoints[i].Color = myColor[i];
                AllPoints[i].ToolTip = percents[i].ToString() + "%";
                AllPoints[i].Label = percents[i].ToString() + "%";
                AllPoints[i].LabelForeColor = Color.Black;
                this.chart1.Series[0].Points.Add(AllPoints[i]);
            }


            this.chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
            this.chart1.Series[0]["PieLabelStyle"] = "Outside";
            this.chart1.EndInit();
        }
    }
}
