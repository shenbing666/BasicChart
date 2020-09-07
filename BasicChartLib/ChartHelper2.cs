using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace CHART_DEMO
{
    public class ChartHelper2
    {
        private static readonly Color[] color = {  Color.Red,
                        Color.Blue,
                        Color.Yellow,
                        Color.DarkRed,
                        Color.Purple,
                        Color.DarkOrange,
                        Color.Maroon,
                        Color.LightCoral,
                        Color.LightPink,
                        Color.Magenta,
                        Color.IndianRed,
                        Color.MediumVioletRed,
                        Color.OrangeRed,
                        Color.PaleVioletRed};
        /// <summary>
        /// Name：添加序列
        /// Author：by boxuming 2019-04-28 13:59
        /// </summary>
        /// <param name="chart">图表对象</param>
        /// <param name="seriesName">序列名称</param>
        /// <param name="chartType">图表类型</param>
        /// <param name="color">颜色</param>
        /// <param name="markColor">标记点颜色</param>
        /// <param name="showValue">是否显示数值</param>
        public static void AddSeries(Chart chart, string seriesName, SeriesChartType chartType, Color color, Color markColor, bool showValue = false)
        {
            chart.Series.Add(seriesName);
            chart.Series[seriesName].ChartType = chartType;
            chart.Series[seriesName].Color = color;
            if (showValue)
            {
                chart.Series[seriesName].IsValueShownAsLabel = true;
                chart.Series[seriesName].MarkerStyle = MarkerStyle.Circle;
                chart.Series[seriesName].MarkerColor = markColor;
                chart.Series[seriesName].LabelForeColor = color;
                chart.Series[seriesName].LabelAngle = -90;
            }
        }

        /// <summary>
        /// Name：设置标题
        /// Author：by boxuming 2019-04-28 14:25
        /// </summary>
        /// <param name="chart">图表对象</param>
        /// <param name="chartName">图表名称</param>
        public static void SetTitle(Chart chart, string chartName, Font font, Docking docking, Color foreColor)
        {
            chart.Titles.Add(chartName);
            chart.Titles[0].Font = font;
            chart.Titles[0].Docking = docking;
            chart.Titles[0].ForeColor = foreColor;
        }

        /// <summary>
        /// Name：设置样式
        /// Author：by boxuming 2019-04-23 14:04
        /// </summary>
        /// <param name="chart">图表对象</param>
        /// <param name="backColor">背景颜色</param>
        /// <param name="foreColor">字体颜色</param>
        public static void SetStyle(Chart chart, Color backColor, Color foreColor)
        {
            chart.BackColor = backColor;
            chart.ChartAreas[0].BackColor = backColor;
            chart.ForeColor = Color.Red;
        }

        /// <summary>
        /// Name：设置图例
        /// Author：by boxuming 2019-04-23 14:30
        /// </summary>
        /// <param name="chart">图表对象</param>
        /// <param name="docking">停靠位置</param>
        /// <param name="align">对齐方式</param>
        /// <param name="backColor">背景颜色</param>
        /// <param name="foreColor">字体颜色</param>
        public static void SetLegend(Chart chart, Docking docking, StringAlignment align, Color backColor, Color foreColor)
        {
            chart.Legends[0].Docking = docking;
            chart.Legends[0].Alignment = align;
            chart.Legends[0].BackColor = backColor;
            chart.Legends[0].ForeColor = foreColor;
        }

        /// <summary>
        /// Name：设置XY轴
        /// Author：by boxuming 2019-04-23 14:35
        /// </summary>
        /// <param name="chart">图表对象</param>
        /// <param name="xTitle">X轴标题</param>
        /// <param name="yTitle">Y轴标题</param>
        /// <param name="align">坐标轴标题对齐方式</param>
        /// <param name="foreColor">坐标轴字体颜色</param>
        /// <param name="lineColor">坐标轴颜色</param>
        /// <param name="arrowStyle">坐标轴箭头样式</param>
        /// <param name="xInterval">X轴的间距</param>
        /// <param name="yInterval">Y轴的间距</param>
        public static void SetXY(Chart chart, string xTitle, string yTitle, StringAlignment align, Color foreColor, Color lineColor, AxisArrowStyle arrowStyle, double xInterval, double yInterval)
        {
            chart.ChartAreas[0].AxisX.Title = xTitle;
            chart.ChartAreas[0].AxisY.Title = yTitle;
            chart.ChartAreas[0].AxisX.TitleAlignment = align;
            chart.ChartAreas[0].AxisY.TitleAlignment = align;
            chart.ChartAreas[0].AxisX.TitleForeColor = foreColor;
            chart.ChartAreas[0].AxisY.TitleForeColor = foreColor;
            chart.ChartAreas[0].AxisX.LabelStyle = new LabelStyle() { ForeColor = foreColor };
            chart.ChartAreas[0].AxisY.LabelStyle = new LabelStyle() { ForeColor = foreColor };
            chart.ChartAreas[0].AxisX.LineColor = lineColor;
            chart.ChartAreas[0].AxisY.LineColor = lineColor;
            chart.ChartAreas[0].AxisX.ArrowStyle = arrowStyle;
            chart.ChartAreas[0].AxisY.ArrowStyle = arrowStyle;
            chart.ChartAreas[0].AxisX.Interval = xInterval;
            chart.ChartAreas[0].AxisY.Interval = yInterval;
        }

        /// <summary>
        /// Name：设置网格
        /// Author：by boxuming 2019-04-23 14:55
        /// </summary>
        /// <param name="chart">图表对象</param>
        /// <param name="lineColor">网格线颜色</param>
        /// <param name="xInterval">X轴网格的间距</param>
        /// <param name="yInterval">Y轴网格的间距</param>
        public static void SetMajorGrid(Chart chart, Color lineColor, double xInterval, double yInterval)
        {
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = lineColor;
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = lineColor;
            chart.ChartAreas[0].AxisX.MajorGrid.Interval = xInterval;
            chart.ChartAreas[0].AxisY.MajorGrid.Interval = yInterval;
        }

        /// <summary>
        /// 设置默认格式
        /// </summary>
        /// <param name="chart">chart控件</param>
        /// <param name="format">图表类型：1柱形图，2饼状图(单)，3折线图,4曲线图＋区间(单),5柱形图和饼形图(单)</param>
        /// <param name="count">Series数量</param>
        public static void SetFormat(Chart chart, int format, int count = 0)
        {

            chart.Series.Clear();
            switch (format)
            {
                case 1:
                    for (int i = 0; i < count; i++)
                    {
                        AddSeries(chart, "柱状图" + i, SeriesChartType.Column, color[i], color[i], true);
                    }
                    //AddSeries(chart, "柱状图", SeriesChartType.Column, Color.Lime, Color.Red, true);
                    SetTitle(chart, "柱状图", new Font("微软雅黑", 12), Docking.Bottom, Color.White);
                    SetStyle(chart, Color.Transparent, Color.White);
                    SetLegend(chart, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);
                    SetXY(chart, "序号", "数值", StringAlignment.Far, Color.White, Color.White, AxisArrowStyle.SharpTriangle, 1, 2);
                    SetMajorGrid(chart, Color.Gray, 20, 2);
                    break;
                case 2:
                    AddSeries(chart, "饼状图", SeriesChartType.Pie, Color.Lime, Color.Red, true);
                    SetStyle(chart, Color.Transparent, Color.White);
                    SetLegend(chart, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);
                    break;
                case 3:
                    for (int i = 0; i < count; i++)
                    {
                        AddSeries(chart, "曲线图" + i, SeriesChartType.Spline, color[i], color[i], true);
                    }
                    SetTitle(chart, "曲线图", new Font("微软雅黑", 12), Docking.Bottom, Color.White);
                    SetStyle(chart, Color.Transparent, Color.White);
                    SetLegend(chart, Docking.Top,StringAlignment.Center, Color.Transparent, Color.White);
                    //最后两个参数调整 xy轴间隔
                    SetXY(chart, "序号", "数值", StringAlignment.Far, Color.White, Color.White, AxisArrowStyle.SharpTriangle, 1, 2);
                    SetMajorGrid(chart, Color.Gray, 20, 2);
                    break;
                case 4:
                    AddSeries(chart, "曲线图", SeriesChartType.SplineRange, Color.FromArgb(100, 46, 199, 201), Color.Red, true);
                    SetTitle(chart, "曲线图", new Font("微软雅黑", 12), Docking.Bottom, Color.FromArgb(46, 199, 201));
                    SetStyle(chart, Color.Transparent, Color.White);
                    SetLegend(chart, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);
                    SetXY(chart, "序号", "数值", StringAlignment.Far, Color.White, Color.White, AxisArrowStyle.SharpTriangle, 1, 2);
                    SetMajorGrid(chart, Color.Gray, 20, 2);
                    break;
                case 5:
                    AddSeries(chart, "柱状图", SeriesChartType.Column, Color.Lime, Color.Red, true);
                    AddSeries(chart, "曲线图", SeriesChartType.Spline, Color.Red, Color.Red);
                    SetTitle(chart, "柱状图与曲线图", new Font("微软雅黑", 12), Docking.Bottom, Color.White);
                    SetStyle(chart, Color.Transparent, Color.White);
                    SetLegend(chart, Docking.Top, StringAlignment.Center, Color.Transparent, Color.White);
                    SetXY(chart, "序号", "数值", StringAlignment.Far, Color.White, Color.White, AxisArrowStyle.SharpTriangle, 1, 2);
                    SetMajorGrid(chart, Color.Gray, 20, 2);
                    break;
                default:
                    break;
            }

        }
        ///// <summary>
        ///// 设置默认格式
        ///// </summary>
        ///// <param name="chart">控件</param>
        ///// <param name="format">格式:1柱形图，2饼状图，3折线图,4柱形图&&饼形图</param>
        //public static void SetSeries(Chart chart, SeriesChartType seriesChartType, int ser)
        //{
        //    AddSeries(chart, "", seriesChartType, Color.Lime, Color.Red, true);

        //    //AddSeries(chart, "柱状图", SeriesChartType.Column, Color.Lime, Color.Red, true);
        //    //AddSeries(chart, "曲线图", SeriesChartType.Spline, Color.Red, Color.Red, true);
        //    //AddSeries(chart, "饼状图", SeriesChartType.Pie, Color.Lime, Color.Red, true);
        //}
    }
}
