using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CHART_DEMO
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            ChartHelper1.AddSeries(chart1, "柱状图", SeriesChartType.Column, Color.Lime, Color.Red, true);
            ChartHelper1.AddSeries(chart1, "曲线图", SeriesChartType.Spline, Color.Red, Color.Red);
            ChartHelper1.SetTitle(chart1, "柱状图与曲线图", new Font("微软雅黑", 12), Docking.Bottom, Color.White);
            ChartHelper1.SetStyle(chart1, Color.Transparent, Color.White);
            ChartHelper1.SetLegend(chart1, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);
            ChartHelper1.SetXY(chart1, "序号", "数值", StringAlignment.Far, Color.White, Color.White, AxisArrowStyle.SharpTriangle, 1, 2);
            ChartHelper1.SetMajorGrid(chart1, Color.Gray, 20, 2);

            chart2.Series.Clear();
            ChartHelper1.AddSeries(chart2, "饼状图", SeriesChartType.Pie, Color.Lime, Color.Red, true);
            ChartHelper1.SetStyle(chart2, Color.Transparent, Color.White);
            ChartHelper1.SetLegend(chart2, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);

            chart3.Series.Clear();
            ChartHelper1.AddSeries(chart3, "曲线图", SeriesChartType.SplineRange, Color.FromArgb(100, 46, 199, 201), Color.Red, true);
            ChartHelper1.SetTitle(chart3, "曲线图", new Font("微软雅黑", 12), Docking.Bottom, Color.FromArgb(46, 199, 201));
            ChartHelper1.SetStyle(chart3, Color.Transparent, Color.White);
            ChartHelper1.SetLegend(chart3, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);
            ChartHelper1.SetXY(chart3, "序号", "数值", StringAlignment.Far, Color.White, Color.White, AxisArrowStyle.SharpTriangle, 1, 2);
            ChartHelper1.SetMajorGrid(chart3, Color.Gray, 20, 2);

            chart4.Series.Clear();
            ChartHelper1.AddSeries(chart4, "饼状图", SeriesChartType.Funnel, Color.Lime, Color.Red, true);
            ChartHelper1.SetStyle(chart4, Color.Transparent, Color.White);
            ChartHelper1.SetLegend(chart4, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);

            RefreshData();
        }
        public void RefreshData()
        {
            List<int> x1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            List<int> y1 = new List<int>();
            Random ra = new Random();
            y1 = new List<int>() {
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10)
            };
            RefreshChart(x1, y1, "chart1");
            RefreshChart(x1, y1, "chart2");
            RefreshChart(x1, y1, "chart3");
            RefreshChart(x1, y1, "chart4");
        }

        public delegate void RefreshChartDelegate(List<int> x, List<int> y, string type);
        public void RefreshChart(List<int> x, List<int> y, string type)
        {
            if (type == "chart1")
            {
                if (type == "chart1")
                {
                    if (this.chart1.InvokeRequired)
                    {
                        RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                        this.Invoke(stcb, new object[] { x, y, type });
                    }
                    else
                    {
                        chart1.Series[0].Points.DataBindXY(x, y);
                        chart1.Series[1].Points.DataBindXY(x, y);
                    }
                }
            }
            else if (type == "chart2")
            {
                if (this.chart2.InvokeRequired)
                {
                    RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                    this.Invoke(stcb, new object[] { x, y, type });
                }
                else
                {
                    chart2.Series[0].Points.DataBindXY(x, y);
                    List<Color> colors = new List<Color>() {
                        Color.Red,
                        Color.DarkRed,
                        Color.IndianRed,
                        Color.MediumVioletRed,
                        Color.OrangeRed,
                        Color.PaleVioletRed,
                        Color.Purple,
                        Color.DarkOrange,
                        Color.Maroon,
                        Color.LightCoral,
                        Color.LightPink,
                        Color.Magenta
                    };
                    DataPointCollection points = chart2.Series[0].Points;
                    for (int i = 0; i < points.Count; i++)
                    {
                        points[i].Color = colors[i];
                    }
                }
            }
            else if (type == "chart3")
            {
                if (this.chart3.InvokeRequired)
                {
                    RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                    this.Invoke(stcb, new object[] { x, y, type });
                }
                else
                {
                    chart3.Series[0].Points.DataBindXY(x, y);
                }
            }
            else if (type == "chart4")
            {
                if (this.chart4.InvokeRequired)
                {
                    RefreshChartDelegate stcb = new RefreshChartDelegate(RefreshChart);
                    this.Invoke(stcb, new object[] { x, y, type });
                }
                else
                {
                    chart4.Series[0].Points.DataBindXY(x, y);
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            new Thread(new ThreadStart(RefreshData)).Start();
        }
    }
}
