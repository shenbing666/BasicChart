﻿using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;

namespace BasicChartLib
{

    /// <summary>
    /// 图表基础样式
    /// </summary>
    public class ChartStyle
    {
        private Color _backColor = Color.Transparent;
        private Color _areasBackColor = Color.Transparent;
        private Color _foreColor = Color.Black;
        private Color _xMajorGridLineColor = Color.Gray;
        private Color _yMajorGridLineColor = Color.Gray;
        private double _xMajorGridInterval = 2;
        private double _yMajorGridInterval = 10;
        private double _x2MajorGridInterval = 0;
        private double _y2MajorGridInterval = 0;

        /// <summary>
        /// 背景颜色
        /// </summary>
        public Color BackColor { get => _backColor; set => _backColor = value; }
        /// <summary>
        /// 区域颜色
        /// </summary>
        public Color AreasBackColor { get => _areasBackColor; set => _areasBackColor = value; }
        /// <summary>
        /// 前景颜色
        /// </summary>
        public Color ForeColor { get => _foreColor; set => _foreColor = value; }

        /// <summary>
        /// X轴网格线颜色
        /// </summary>
        public Color XMajorGridLineColor { get => _xMajorGridLineColor; set => _xMajorGridLineColor = value; }

        /// <summary>
        /// Y轴网格线颜色
        /// </summary>
        public Color YMajorGridLineColor { get => _yMajorGridLineColor; set => _yMajorGridLineColor = value; }

        /// <summary>
        /// X轴网格线间隔
        /// </summary>
        public double XMajorGridInterval { get => _xMajorGridInterval; set => _xMajorGridInterval = value; }

        /// <summary>
        /// X 2轴网格线间隔
        /// </summary>
        public double X2MajorGridInterval { get => _x2MajorGridInterval; set => _x2MajorGridInterval = value; }

        /// <summary>
        /// Y轴网格线间隔
        /// </summary>
        public double YMajorGridInterval { get => _yMajorGridInterval; set => _yMajorGridInterval = value; }

        /// <summary>
        /// Y 2轴网格线间隔
        /// </summary>
        public double Y2MajorGridInterval { get => _y2MajorGridInterval; set => _y2MajorGridInterval = value; }

    }

    /// <summary>
    /// 标题样式
    /// </summary>
    public class ChartTitle
    {
        private Font _font = new Font("微软雅黑", 12);
        private Docking _docking = Docking.Bottom;
        private Color _foreColor = Color.Black;
        private string _name="默认标题";

        public string Name { get => _name; set => _name = value; }
        public Font Font { get => _font; set => _font = value; }
        public Docking Docking { get => _docking; set => _docking = value; }
        public Color ForeColor { get => _foreColor; set => _foreColor = value; }
    }

    /// <summary>
    /// x轴
    /// </summary>
    public class XAxis
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public List<string> Data { get; set; }
    }

    /// <summary>
    /// y轴
    /// </summary>
    public class YAxis
    {
        public string Name { get; set; }
        public string Type { get; set; }

    }

    /// <summary>
    /// 系列
    /// </summary>
    public class Series
    {
        public string Name { get; set; }
        /// <summary>
        /// 图标类型，bar、line、pie
        /// </summary>
        public ChartTypeEnum Type { get; set; }
        public List<double> Data { get; set; }
        public bool ShowBackground { get; set; }
        public Color BackgroundStyle { get; set; }

    }

    /// <summary>
    /// 图表模型
    /// </summary>
    public class ChartBasicModel
    {
        public ChartBasicModel() { }

        public ChartBasicModel(Chart chart,ChartStyle style, ChartTitle title, XAxis x, YAxis y, Series[] series)
        {
            this.chart = chart;
            this.chartStyle = style;
            this.title = title;
            this.xAxis = x;
            this.yAxis = y;
            this.serie = series;
        }
        public Chart chart;

        public ChartStyle chartStyle;
        public ChartTitle title { get; set; }
        public XAxis xAxis { get; set; }
        public YAxis yAxis { get; set; }
        public Series[] serie { get; set; }


    }
}
