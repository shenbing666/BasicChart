using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace CHART_DEMO.ChartHandle
{
    public abstract class Charts
    {
        public Chart chart;

        protected readonly Color[] ChartsColor = {  Color.Red,
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

        #region 属性
        private string title = "";
        private int xInterval = 1;
        private int yInterval = 2;
        private int y2Interval = 0;
        private string xTitle = "序号";
        private string yTitle = "数值";
        private string y2Title = "数值";
        private Color foreColor = Color.Black;
        private Color backColor = Color.Transparent;
        private Font chartFont = new Font("微软雅黑", 12);
        private AxisArrowStyle axisArrowStyle = AxisArrowStyle.SharpTriangle;
        private List<xy> xys;
        private ChartStyleEnum chartStyle;
        private Docking titleDocking = Docking.Bottom;


        /// <summary>
        /// 标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        /// <summary>
        /// 字体颜色，默认白色
        /// </summary>
        public Color ForeColor
        {
            get { return Color.White; }
            set { foreColor = value; }
        }
        /// <summary>
        /// 背景颜色，默认透明
        /// </summary>
        public Color BackColor
        {
            get { return Color.Transparent; }
            set { backColor = value; }
        }
        /// <summary>
        /// x轴标题，默认序号
        /// </summary>
        public string XTitle
        {
            get { return "序号"; }
            set { xTitle = value; }
        }

        /// <summary>
        /// x轴间隔
        /// </summary>
        public int XInterval
        {
            get { return 1; }
            set { xInterval = value; }
        }
        /// <summary>
        /// y轴标题，默认数值
        /// </summary>
        public string YTitle
        {
            get { return "数值"; }
            set { yTitle = value; }
        }
        /// <summary>
        /// y轴间隔
        /// </summary>
        public int YInterval
        {
            get { return 2; }
            set { yInterval = value; }
        }
        /// <summary>
        /// y2轴标题，默认数值
        /// </summary>
        public string Y2Title
        {
            get { return "数值"; }
            set { y2Title = value; }
        }
        /// <summary>
        /// y2轴间隔
        /// </summary>
        public int Y2Interval
        {
            get { return 2; }
            set { y2Interval = value; }
        }
        /// <summary>
        /// 轴箭头类型，默认尖三角
        /// </summary>
        public AxisArrowStyle AxisArrowStyle
        {
            get { return AxisArrowStyle.SharpTriangle; }
            set { axisArrowStyle = value; }
        }
        /// <summary>
        /// xy轴坐标
        /// </summary>
        public List<xy> Xys
        {
            get { return xys; }
            set { xys = value; }
        }
        /// <summary>
        /// 图表类型
        /// </summary>
        public ChartStyleEnum ChartStyle
        {
            get { return chartStyle; }
            set { chartStyle = value; }
        }
        /// <summary>
        /// 标题位置，默认底部
        /// </summary>
        public Docking TitleDocking
        {
            get { return Docking.Bottom; }
            set { titleDocking = value; }
        }

        /// <summary>
        /// 图表字体，默认微软雅黑 12
        /// </summary>
        public Font ChartFont
        {
            get { return chartFont; }
            set { chartFont = value; }
        }
        #endregion

        public Charts(Chart chart1)
        {
            if (chart == null)
            {
                chart = chart1;
            }
        }

        protected void SetFormat()
        {
            ChartHelper.SetTitle(chart, title, chartFont, titleDocking, foreColor);
            ChartHelper.SetStyle(chart, backColor, foreColor);
            ChartHelper.SetLegend(chart, Docking.Top, StringAlignment.Center, backColor, foreColor);
            ChartHelper.SetXY(chart, xTitle, yTitle, StringAlignment.Far, foreColor, foreColor, AxisArrowStyle.SharpTriangle, xInterval, yInterval,y2Interval);
            ChartHelper.SetMajorGrid(chart, Color.Gray, 20, 2);
        }

        //public abstract Chart SetSeries(Chart chart, List<xy> xys);

        //public abstract Chart SetXYs(Chart chart, List<xy> xys);

        protected abstract Chart SetSeries(List<xy> xys);


        protected abstract Chart SetXYs(List<xy> xys);
        /// <summary>
        /// 加载图表对象
        /// </summary>
        /// <param name="lst"></param>
        /// <returns></returns>
        public abstract Chart init(List<xy> lst);
    }
}
