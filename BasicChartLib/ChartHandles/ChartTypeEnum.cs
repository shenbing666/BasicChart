using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasicChartLib
{
    public enum ChartTypeEnum
    {
        /// <summary>
        /// 13 面积图类型√
        /// </summary>
        Area,
        /// <summary>
        /// 7 条形图类型√
        /// </summary>
        Bar,
        /// <summary>
        /// 28 盒须图类型√
        /// </summary>
        BoxPlot,
        /// <summary>
        /// 2气泡图类型√
        /// </summary>
        Bubble,
        /// <summary>
        /// 20 线图类型。
        /// </summary>
        Candlestick,
        /// <summary>
        /// 10柱形图类型。
        /// </summary>
        Column,
        /// <summary>
        /// 18圆环图类型。
        /// </summary>
        Doughnut,
        /// <summary>
        /// 27误差条形图类型。
        /// </summary>
        ErrorBar,
        /// <summary>
        /// 6快速扫描线图类型。
        /// </summary>
        FastLine,
        /// <summary>
        /// 1快速点图类型。
        /// </summary>
        FastPoint,
        /// <summary>
        /// 33漏斗图类型。
        /// </summary>
        Funnel,
        /// <summary>
        /// 31卡吉图类型。
        /// </summary>
        Kagi,
        /// <summary>
        /// 3折线图类型。
        /// </summary>
        Line,
        /// <summary>
        /// 17饼图类型。
        /// </summary>
        Pie,
        /// <summary>
        /// 0点图类型。
        /// </summary>
        Point,
        /// <summary>
        /// 32点数图类型
        /// </summary>
        PointAndFigure,
        /// <summary>
        /// 26极坐标图类型【有问题】
        /// </summary>
        Polar,
        /// <summary>
        /// 34棱锥图类型。
        /// </summary>
        Pyramid,
        /// <summary>
        /// 25雷达图类型。
        /// </summary>
        Radar,
        /// <summary>
        /// 21范围图类型。
        /// </summary>
        Range,
        /// <summary>
        /// 23范围条形图类型。
        /// </summary>
        RangeBar,
        /// <summary>
        /// 24范围柱形图类型。
        /// </summary>
        RangeColumn,
        /// <summary>
        /// 29砖形图类型。
        /// </summary>
        Renko,
        /// <summary>
        /// 4样条图类型。
        /// </summary>
        Spline,
        /// <summary>
        /// 14样条面积图类型。
        /// </summary>
        SplineArea,
        /// <summary>
        /// 22样条范围图类型。
        /// </summary>
        SplineRange,
        /// <summary>
        /// 15堆积面积图类型。
        /// </summary>
        StackedArea,
        /// <summary>
        /// 16百分比堆积面积图类型。
        /// </summary>
        StackedArea100,
        /// <summary>
        /// 8堆积条形图类型。
        /// </summary>
        StackedBar,
        /// <summary>
        /// 9百分比堆积条形图类型。
        /// </summary>
        StackedBar100,
        /// <summary>
        /// 11堆积柱形图类型。
        /// </summary>
        StackedColumn,
        /// <summary>
        /// 12百分比堆积柱形图类型。
        /// </summary>
        StackedColumn100,
        /// <summary>
        /// 5阶梯线图类型。
        /// </summary>
        StepLine,
        /// <summary>
        /// 19股价图类型。
        /// </summary>
        Stock,
        /// <summary>
        /// 30新三值图类型/三行中断图表法
        /// </summary>
        ThreeLineBreak,
    }
}
