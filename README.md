# BasicChart

通过winform实现chart控件

目前只有折线图（单双轴）、条形图、饼图

博客地址：https://www.cnblogs.com/shenbing/p/13614012.html
 

 
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
