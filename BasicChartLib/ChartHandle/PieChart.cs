using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace CHART_DEMO.ChartHandle
{

    /// <summary>
    /// 饼图
    /// </summary>
   public class PieChart : Charts
    {
        public PieChart(Chart chart)
            : base(chart)
        {

        }
        //public override Chart SetSeries(Chart chart, List<xy> xys) 
        protected override Chart SetSeries(List<xy> xys)
        {
            chart.Series.Clear();

            if (string.IsNullOrEmpty(xys[0].LineTitle))
            {
                ChartHelper.AddSeries(chart, xys[0].LineTitle, SeriesChartType.Pie, ChartsColor[0], ChartsColor[1], true);
            }
            else
            {
                ChartHelper.AddSeries(chart, xys[0].LineTitle, SeriesChartType.Pie, ChartsColor[0], ChartsColor[1], true);
            }


            return chart;
        }

        /// <summary>
        /// 设置xy轴数据
        /// </summary>
        //public override Chart SetXYs(Chart chart, List<xy> xys)
        protected override Chart SetXYs(List<xy> xys)
        {
            chart.Series[0].Points.DataBindXY(xys[0].x, xys[0].y);
            DataPointCollection points = chart.Series[0].Points;
            for (int i = 0; i < points.Count; i++)
            {
                points[i].Color = ChartsColor[i];
                if (xys[0].PieLegendText != null && (points.Count== xys[0].PieLegendText.Count))
                {
                    points[i].LegendText = xys[0].PieLegendText[i];
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
