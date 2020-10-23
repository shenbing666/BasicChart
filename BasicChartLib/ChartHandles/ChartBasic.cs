using BasicChartLib.Common;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasicChartLib
{
    public class ChartBasic
    {
        public Chart init(ChartBasicModel model)
        {
            SetFormat(model);
            model.chart=SetSeries(model);
            model.chart=SetXYs(model);
            return model.chart;
        }

        /// <summary>
        /// 设置默认格式
        /// </summary>
        /// <param name="model"></param>
        private void SetFormat(ChartBasicModel model)
        {
            ChartHelper.SetTitle(model.chart, model.title.Name, model.title.Font, model.title.Docking, model.title.ForeColor);
            ChartHelper.SetStyle(model.chart, model.chartStyle.BackColor, model.chartStyle.ForeColor);
            ChartHelper.SetLegend(model.chart, Docking.Top, StringAlignment.Center, model.chartStyle.BackColor, model.chartStyle.ForeColor);
            ChartHelper.SetXY(model.chart, model.xAxis.Name, model.xAxis.Name, StringAlignment.Far, model.chartStyle.ForeColor, model.chartStyle.ForeColor,
                AxisArrowStyle.SharpTriangle, model.chartStyle.XMajorGridInterval, model.chartStyle.YMajorGridInterval, model.chartStyle.Y2MajorGridInterval);
            ChartHelper.SetMajorGrid(model.chart, Color.Gray, 20, 2);
        }

        private Chart SetSeries(ChartBasicModel model)
        {
            Chart chart = model.chart;
            chart.Series.Clear();

            for (int i = 0; i < model.serie.Length; i++)
            {
                ChartHelper.AddSeries(chart, model.serie[i].Name+ i, getSeriesChartType(model.serie[i].Type), ChartColors.ChartsColor[i], ChartColors.ChartsColor[i], true);
            }

            return chart;
        }

        /// <summary>
        /// 设置xy轴数据
        /// </summary>
        private Chart SetXYs(ChartBasicModel model)
        {
            Chart chart = model.chart;
            //饼图特殊，只有一个序列，需要配置颜色
            if (model.serie[0].Type==ChartTypeEnum.Pie) {
                chart.Series[0].Points.DataBindXY(model.xAxis.Data, model.serie[0].Data);
                DataPointCollection points = chart.Series[0].Points;
                for (int i = 0; i < points.Count; i++)
                {
                    points[i].Color = ChartColors.ChartsColor[i];
                    if (model.xAxis.Data.Count==model.serie[0].Data.Count)
                    {
                        points[i].LegendText = model.xAxis.Data[i].ToString().Trim();
                    }
                }
            }
            else
            {
                for (int i = 0; i < model.serie.Length; i++)
                {
                    chart.Series[i].Points.DataBindXY(model.xAxis.Data, model.serie[i].Data);
                }
            }
            

            return chart;
        }


        private SeriesChartType getSeriesChartType(ChartTypeEnum type) {
            switch (type)
            {
               
                case ChartTypeEnum.Column:
                    return SeriesChartType.Column;
                case ChartTypeEnum.Pie:
                    return SeriesChartType.Pie;
                case ChartTypeEnum.Line:
                    return SeriesChartType.Line;
                default:
                    break;
            }
            return SeriesChartType.Line;
        }
    }
}
