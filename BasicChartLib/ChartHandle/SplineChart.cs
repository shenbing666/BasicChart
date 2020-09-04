using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace CHART_DEMO.ChartHandle
{
    /// <summary>
    /// 折线图
    /// </summary>
    public class SplineChart : Charts
    {
        public SplineChart(Chart chart)
            : base(chart)
        {

        }

        /// <summary>
        /// 设置默认格式
        /// </summary>
        /// <param name="chart">chart控件</param>
        /// <param name="format">图表类型：1柱形图，2饼状图(单)，3折线图,4曲线图＋区间(单),5柱形图和饼形图(单)</param>
        /// <param name="count">Series数量</param>

        //public override Chart SetSeries(Chart chart, List<xys> xys)
        protected override Chart SetSeries(List<xy> xys)
        {
            chart.Series.Clear();

            for (int i = 0; i < xys.Count; i++)
            {
                if (string.IsNullOrEmpty(xys[i].LineTitle))
                {
                    ChartHelper2.AddSeries(chart, "折线图" + i, SeriesChartType.Spline, ChartsColor[i], ChartsColor[i + 1], true);
                }
                else
                {
                    ChartHelper2.AddSeries(chart, xys[i].LineTitle, SeriesChartType.Spline, ChartsColor[i], ChartsColor[i + 1], true);
                }

            }

            return chart;
        }
        /// <summary>
        /// 设置xy轴数据
        /// </summary>
        //public override Chart SetXYs(Chart chart, List<xys> xys)
        protected override Chart SetXYs(List<xy> xys)
        {

            if (StringTools.arrLenthEqual(xys))
            {
                for (int i = 0; i < xys.Count; i++)
                {
                    chart.Series[i].Points.DataBindXY(xys[i].x, xys[i].y);
                }
            }
            return chart;
        }
        public override Chart init(List<xy> lst)
        {
            SetFormat();
            SetSeries(lst);
            SetXYs(lst);
            return chart;
        }
    }
}
