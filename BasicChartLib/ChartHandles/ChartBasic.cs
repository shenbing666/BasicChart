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
            model.chart = SetSeries(model);
            model.chart = SetXYs(model);
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
                model.chartStyle.AxisArrowStyle, model.chartStyle.XMajorGridInterval, model.chartStyle.YMajorGridInterval, model.chartStyle.Y2MajorGridInterval);
            ChartHelper.SetMajorGrid(model.chart, model.chartStyle.GridLineColor, 20, 2);
        }

        private Chart SetSeries(ChartBasicModel model)
        {
            Chart chart = model.chart;
            chart.Series.Clear();

            for (int i = 0; i < model.serie.Length; i++)
            {
                ChartHelper.AddSeries(chart, model.serie[i].Name + i, getSeriesChartType(model.serie[i].Type),
                    model.serie[i].LabelColor, ChartColors.ChartsColor[i], true);
            }

            return chart;
        }

        /// <summary>
        /// 设置xy轴数据
        /// </summary>
        private Chart SetXYs(ChartBasicModel model)
        {
            Chart chart = model.chart;
            ChartTypeEnum chartTypeEnum = model.serie[0].Type;
            //饼图/圆环/漏斗图/卡吉图/雷达图/砖型图/新三值图  ---单序列、单y值、需要加颜色
            if (chartTypeEnum == ChartTypeEnum.Pie || chartTypeEnum == ChartTypeEnum.Doughnut || chartTypeEnum == ChartTypeEnum.Funnel
                || chartTypeEnum == ChartTypeEnum.Kagi || chartTypeEnum == ChartTypeEnum.Pyramid || chartTypeEnum == ChartTypeEnum.Kagi
                || chartTypeEnum == ChartTypeEnum.Renko)
            {
                chart.Series[0].Points.DataBindXY(model.xAxis.Data, model.serie[0].Data);
                if (chartTypeEnum != ChartTypeEnum.Radar || chartTypeEnum != ChartTypeEnum.Renko)
                {
                    DataPointCollection points = chart.Series[0].Points;
                    for (int i = 0; i < points.Count; i++)
                    {
                        points[i].Color = ChartColors.ChartsColor[i];
                        if (model.xAxis.Data.Count == model.serie[0].Data.Count)
                        {
                            points[i].LegendText = model.xAxis.Data[i].ToString().Trim();
                        }
                    }
                }
            }
            //气泡图/误差条形图 ---单序列、2个y值
            else if (chartTypeEnum == ChartTypeEnum.Bubble || chartTypeEnum == ChartTypeEnum.ErrorBar || chartTypeEnum == ChartTypeEnum.PointAndFigure)
            {
                // Arguments: X value, low value, high value
                chart.Series[0].Points.DataBindXY(model.xAxis.Data, model.serie[0].Data, model.serie[0].Data2);
            }
            //范围图   ---多序列、2个y值
            else if (chartTypeEnum == ChartTypeEnum.Range || chartTypeEnum == ChartTypeEnum.RangeBar || chartTypeEnum == ChartTypeEnum.RangeColumn
                || chartTypeEnum == ChartTypeEnum.SplineArea)
            {
                for (int i = 0; i < model.serie.Length; i++)
                {
                    chart.Series[i].Points.DataBindXY(model.xAxis.Data, model.serie[i].Data, model.serie[i].Data2);
                }

            }
            //股价图   --多序列、4个y值
            else if (chartTypeEnum == ChartTypeEnum.Stock)
            {

                for (int j = 0; j < model.serie.Length; j++)
                {
                    //最高价，最低价，开盘价和收盘价
                    chart.Series[j].Points.DataBindXY(model.xAxis.Data, model.serie[j].Data, model.serie[j].Data2, model.serie[j].Data3, model.serie[j].Data4);

                    DataPointCollection points = chart.Series[0].Points;
                    for (int i = 0; i < points.Count; i++)
                    {
                        points[i].Color = ChartColors.ChartsColor[i];
                        if (model.xAxis.Data.Count == model.serie[0].Data.Count)
                        {
                            points[i].LegendText = model.xAxis.Data[i].ToString().Trim();
                        }
                    }
                }


            }
            else if (chartTypeEnum == ChartTypeEnum.Polar)
            {
                //x轴为角度，必须是数值
                List<double> lst = model.xAxis.Data.Select<string, double>(x => Convert.ToDouble(x)).ToList();
                chart.Series[0].Points.DataBindXY(lst, model.serie[0].Data);
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


        private SeriesChartType getSeriesChartType(ChartTypeEnum type)
        {
            switch (type)
            {

                case ChartTypeEnum.Column:
                    return SeriesChartType.Column;
                case ChartTypeEnum.Pie:
                    return SeriesChartType.Pie;
                case ChartTypeEnum.Line:
                    return SeriesChartType.Line;
                case ChartTypeEnum.Bubble:
                    return SeriesChartType.Bubble;
                case ChartTypeEnum.Area:
                    return SeriesChartType.Area;
                case ChartTypeEnum.Bar:
                    return SeriesChartType.Bar;
                case ChartTypeEnum.BoxPlot:
                    return SeriesChartType.BoxPlot;
                case ChartTypeEnum.Candlestick:
                    return SeriesChartType.Candlestick;
                case ChartTypeEnum.Doughnut:
                    return SeriesChartType.Doughnut;
                case ChartTypeEnum.ErrorBar:
                    return SeriesChartType.ErrorBar;
                case ChartTypeEnum.FastLine:
                    return SeriesChartType.FastLine;
                case ChartTypeEnum.FastPoint:
                    return SeriesChartType.FastPoint;
                case ChartTypeEnum.Funnel:
                    return SeriesChartType.Funnel;
                case ChartTypeEnum.Kagi:
                    return SeriesChartType.Kagi;
                case ChartTypeEnum.Point:
                    return SeriesChartType.Point;
                case ChartTypeEnum.PointAndFigure:
                    return SeriesChartType.PointAndFigure;
                case ChartTypeEnum.Polar:
                    return SeriesChartType.Polar;
                case ChartTypeEnum.Pyramid:
                    return SeriesChartType.Pyramid;
                case ChartTypeEnum.Radar:
                    return SeriesChartType.Radar;
                case ChartTypeEnum.Range:
                    return SeriesChartType.Range;
                case ChartTypeEnum.RangeBar:
                    return SeriesChartType.RangeBar;
                case ChartTypeEnum.RangeColumn:
                    return SeriesChartType.RangeColumn;
                case ChartTypeEnum.Renko:
                    return SeriesChartType.Renko;
                case ChartTypeEnum.Spline:
                    return SeriesChartType.Spline;
                case ChartTypeEnum.SplineArea:
                    return SeriesChartType.Bubble;
                case ChartTypeEnum.SplineRange:
                    return SeriesChartType.SplineRange;
                case ChartTypeEnum.StackedArea:
                    return SeriesChartType.StackedArea;
                case ChartTypeEnum.StackedArea100:
                    return SeriesChartType.StackedArea100;
                case ChartTypeEnum.StackedBar:
                    return SeriesChartType.StackedBar;
                case ChartTypeEnum.StackedBar100:
                    return SeriesChartType.StackedBar100;
                case ChartTypeEnum.StackedColumn:
                    return SeriesChartType.StackedColumn;
                case ChartTypeEnum.StackedColumn100:
                    return SeriesChartType.StackedColumn100;
                case ChartTypeEnum.StepLine:
                    return SeriesChartType.StepLine;
                case ChartTypeEnum.Stock:
                    return SeriesChartType.Stock;
                case ChartTypeEnum.ThreeLineBreak:
                    return SeriesChartType.ThreeLineBreak;
                default:
                    break;
            }
            return SeriesChartType.Line;
        }
    }
}
