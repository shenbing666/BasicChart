using BasicChartLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CHART_DEMO
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<string> x1 = new List<string>() { "1", "2", "3", "4", "5" };
            Random ra = new Random();
            List<double> y1 = new List<double>() {
                ra.Next(1, 10), ra.Next(1, 10),ra.Next(1, 10),ra.Next(1, 10),ra.Next(1, 20)
            };


            List<double> y2 = new List<double>() {
                ra.Next(1, 20), ra.Next(1, 20), ra.Next(1, 20),ra.Next(1, 20), ra.Next(1, 40)
            };

            ChartBasicModel model = new ChartBasicModel(
                  chart1,
                  new ChartStyle() { },
                  new ChartTitle() { },
                  new XAxis() { Name = "序号", Type = "折线图", Data = x1 },
                  new YAxis() { Name = "数值", Type = "value" },
                  new Series[] {
                    new Series {Type=ChartTypeEnum.Line,Name="折线1",Data=y1},
                    new Series {Type=ChartTypeEnum.Line,Name="折线1",Data=y2 }
                    }
                );
            ChartBasic chartBasic = new ChartBasic();
            chart1 = chartBasic.init(model);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            //MessageBox.Show(comboBox1.Text);
            chart1.Titles.Clear();

            List<string> x1 = new List<string>() { "1", "2", "3", "4", "5" };
            List<string> x2 = new List<string>() { "直接访问", "邮件营销", "联盟广告", "视频广告", "搜索引擎" };
            Random ra = new Random();
            List<double> y1 = new List<double>() {
                ra.Next(1, 10), ra.Next(1, 10),ra.Next(1, 10),ra.Next(1, 10),ra.Next(1, 20)
            };


            List<double> y2 = new List<double>() {
                ra.Next(1, 20), ra.Next(1, 20), ra.Next(1, 20),ra.Next(1, 20), ra.Next(1, 40)
            };

            switch (comboBox1.Text)
            {
                case "折线图":
                    ChartBasicModel model = new ChartBasicModel(
                           chart1,
                           new ChartStyle() { },
                           new ChartTitle() { },
                           new XAxis() { Name = "序号", Type = "折线图", Data = x1 },
                           new YAxis() { Name = "数值", Type = "value" },
                           new Series[] {
                              new Series {Type=ChartTypeEnum.Line,Name="折线1",Data=y1},
                              new Series {Type=ChartTypeEnum.Line,Name="折线2",Data=y2 }
                           }
                        );
                    ChartBasic chartBasic = new ChartBasic();
                    chart1 = chartBasic.init(model);
                    break;
                case "柱状图":
                    ChartBasicModel model1 = new ChartBasicModel(
                       chart1,
                       new ChartStyle() { },
                       new ChartTitle() { },
                       new XAxis() { Name = "序号", Type = "折线图", Data = x1 },
                       new YAxis() { Name = "数值", Type = "value" },
                       new Series[] {
                         new Series {Type=ChartTypeEnum.Column,Name="柱状图1",Data=y1},
                         new Series {Type=ChartTypeEnum.Column,Name="柱状图2",Data=y2 },
                         new Series {Type=ChartTypeEnum.Column,Name="柱状图3",Data=y2 }
                       }
                    );
                    ChartBasic chartBasic1 = new ChartBasic();
                    chart1 = chartBasic1.init(model1);
                    break;                 
                case "饼图":
                    ChartBasicModel model2 = new ChartBasicModel(
                       chart1,
                       new ChartStyle() { },
                       new ChartTitle() { },
                       new XAxis() { Name = "序号", Type = "折线图", Data = x2 },
                       new YAxis() { Name = "数值", Type = "value" },
                       new Series[] {
                         new Series {Type=ChartTypeEnum.Pie,Name="柱状图1",Data=y1},
                       }
                    );
                    ChartBasic chartBasic2 = new ChartBasic();
                    chart1 = chartBasic2.init(model2);
                    break;
                default:
                    break;
            }
        }
    }
}
