using CHART_DEMO.ChartHandle;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CHART_DEMO
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            #region 数据
            Random ra = new Random();
            List<double> x1 = new List<double>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            List<double> y1 = new List<double>() {
                ra.Next(1, 10), ra.Next(1, 10),ra.Next(1, 10),ra.Next(1, 10),ra.Next(1, 20),ra.Next(1, 10),
                ra.Next(1, 10), ra.Next(1, 10),ra.Next(1, 10),ra.Next(1, 30), ra.Next(1, 10), ra.Next(1, 10)
            };

         
            List<double> y2 = new List<double>() {
                ra.Next(15, 40), ra.Next(15, 40), ra.Next(15, 40),ra.Next(15, 40), ra.Next(15, 40),ra.Next(15, 40),
                ra.Next(15, 40),ra.Next(15, 40),ra.Next(15, 40),ra.Next(15, 40),ra.Next(15, 40),ra.Next(15, 40)
            };
            List<double> y3 = new List<double>() { 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15 };
            List<string> legend = new List<string>() { "焦比", "煤比", "例子", "例子", "例子", "例子", "例子", "例子", "例子", "例子", "例子", "例子" };
            #endregion

            try
            {
                //初始化数据集合
                List<xy> lst = new List<xy>();
                lst.Add(new xy { x = x1, y = y1,PieLegendText=legend, LineTitle = "一高炉" });
                lst.Add(new xy { x = x1, y = y2, LineTitle = "二高炉" });
                lst.Add(new xy { x = x1, y = y3, LineTitle = "平均产量" });
               
                //实例化图表对象
                Charts c = new SplineChart(chart1);
                c.Title = "折线图双轴";
                c.XTitle = "月份";
                c.YTitle = "产量";
                c.XInterval = 2;
                c.YInterval = 10;
                c.Y2Interval = 20;
                c.init(lst);

                //实例化图表对象
                Charts c1 = new ColumnChart(chart2);
                c1.Title = "圆柱图";
                c1.XTitle = "月份";
                c1.YTitle = "产量";
                c1.XInterval = 2;
                c1.YInterval = 10;
                 c1.init(lst);

                //实例化图表对象
                Charts c2 = new PieChart(chart3);
                c2.Title = "饼图";
                c2.init(lst);

                //实例化图表对象
                Charts c3 = new SplineChart(chart4);
                c3.Title = "折线图单轴";
                c3.XTitle = "月份";
                c3.YTitle = "产量";
                c3.XInterval = 2;
                c3.YInterval = 10;
                c.Y2Interval = 20;
                c3.init(lst);
         
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            getData("DL");
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            getData("DL1");
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            getData("DL2");
        }

        //获取数据
        private void getData(string type)
        {
            #region 数据
            Random ra = new Random();
            List<int> x = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            List<int> y = new List<int>() {
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 20),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 30),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10)
            };

            List<int> y1 = new List<int>() {
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 20),
                ra.Next(1, 10),
                ra.Next(1, 20),
                ra.Next(1, 10),
                ra.Next(1, 10),
                ra.Next(1, 10)
            };
            List<int> y2 = new List<int>() { 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            #endregion

            switch (type)
            {
                case "DL":
                    setData(x, y, y1, y2);
                    break;
                case "DL1":
                    y1 = null;
                    y2 = null;
                    setData1(x, y);
                    break;
                case "DL2":
                    y = null;
                    y2 = null;
                    setData2(x, y1);
                    break;
                default:
                    break;
            }
        }

        public delegate void RefreshChartDelegate(List<int> x, List<int> y, string type);
        private void setData(List<int> x, List<int> y, List<int> y1, List<int> y2)
        {
            chart1.Series[0].Points.DataBindXY(x, y);
            chart1.Series[1].Points.DataBindXY(x, y1);
            chart1.Series[2].Points.DataBindXY(x, y2);
        }
        private void setData1(List<int> x, List<int> y)
        {
            chart1.Series[0].Points.DataBindXY(x, y);

        }
        private void setData2(List<int> x, List<int> y1)
        {
            chart1.Series[0].Points.DataBindXY(x, y1);
        }
    }
}
