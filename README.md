# BasicChart

通过winform实现chart控件

目前只有折线图（单双轴）、条形图、饼图

博客地址：https://www.cnblogs.com/shenbing/p/13614012.html
 
模拟数据：
List<string> x1 = new List<string>() { "1", "2", "3", "4", "5" };
List<string> x2 = new List<string>() { "直接访问", "邮件营销", "联盟广告", "视频广告", "搜索引擎" };
Random ra = new Random();
List<double> y1 = new List<double>() {
    ra.Next(1, 10), ra.Next(1, 10),ra.Next(1, 10),ra.Next(1, 10),ra.Next(1, 20)
};

List<double> y2 = new List<double>() {
    ra.Next(1, 20), ra.Next(1, 20), ra.Next(1, 20),ra.Next(1, 20), ra.Next(1, 40)
};
 
折线图：
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

柱状图：
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

饼图：
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
