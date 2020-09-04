using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace CHART_DEMO.ChartHandle
{
    /// <summary>
    /// 
    /// </summary>
    public class ColumnChart : Charts
    {
        public ColumnChart(Chart chart)
            : base(chart)
        {

        }
        //public override Chart SetSeries(Chart chart, List<xy> xys)
        protected override Chart SetSeries(List<xy> xys)
        {
            chart.Series.Clear();

            for (int i = 0; i < xys.Count; i++)
            {
                if (string.IsNullOrEmpty(xys[i].LineTitle))
                {
                    ChartHelper2.AddSeries(chart, "柱状图" + i, SeriesChartType.Column, ChartsColor[i], ChartsColor[i + 1], true);
                }
                else
                {
                    ChartHelper2.AddSeries(chart, xys[i].LineTitle, SeriesChartType.Column, ChartsColor[i], ChartsColor[i + 1], true);
                }
            }

            return chart;
        }

        /// <summary>
        /// 设置xy轴数据
        /// </summary>
        //public override Chart SetXYs(Chart chart, List<xy> xys)
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
