# BasicChart

通过winform 实现chart控件

案例展示：

 1 　　　　　　　#region 数据
 2             Random ra = new Random();
 3             List<double> x1 = new List<double>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
 4             List<double> y1 = new List<double>() {
 5                 ra.Next(1, 10), ra.Next(1, 10),ra.Next(1, 10),ra.Next(1, 10),ra.Next(1, 20),ra.Next(1, 10),
 6                 ra.Next(1, 10), ra.Next(1, 10),ra.Next(1, 10),ra.Next(1, 30), ra.Next(1, 10), ra.Next(1, 10)
 7             };
 8 
 9          
10             List<double> y2 = new List<double>() {
11                 ra.Next(15, 40), ra.Next(15, 40), ra.Next(15, 40),ra.Next(15, 40), ra.Next(15, 40),ra.Next(15, 40),
12                 ra.Next(15, 40),ra.Next(15, 40),ra.Next(15, 40),ra.Next(15, 40),ra.Next(15, 40),ra.Next(15, 40)
13             };
14             List<double> y3 = new List<double>() { 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15, 15 };
15             List<string> legend = new List<string>() { "焦比", "煤比", "例子", "例子", "例子", "例子", "例子", "例子", "例子", "例子", "例子", "例子" };
16             #endregion
17 
18             try
19             {
20                 //初始化数据集合
21                 List<xy> lst = new List<xy>();
22                 lst.Add(new xy { x = x1, y = y1,PieLegendText=legend, LineTitle = "一高炉" });
23                 lst.Add(new xy { x = x1, y = y2, LineTitle = "二高炉" });
24                 lst.Add(new xy { x = x1, y = y3, LineTitle = "平均产量" });
25                
26                 //实例化图表对象
27                 Charts c = new SplineChart(chart1);
28                 c.Title = "折线图双轴";
29                 c.XTitle = "月份";
30                 c.YTitle = "产量";
31                 c.XInterval = 2;
32                 c.YInterval = 10;
33                 c.Y2Interval = 20;
34                 c.init(lst);
35 
36                 //实例化图表对象
37                 Charts c1 = new ColumnChart(chart2);
38                 c1.Title = "圆柱图";
39                 c1.XTitle = "月份";
40                 c1.YTitle = "产量";
41                 c1.XInterval = 2;
42                 c1.YInterval = 10;
43                  c1.init(lst);
44 
45                 //实例化图表对象
46                 Charts c2 = new PieChart(chart3);
47                 c2.Title = "饼图";
48                 c2.init(lst);
49 
50                 //实例化图表对象
51                 Charts c3 = new SplineChart(chart4);
52                 c3.Title = "折线图单轴";
53                 c3.XTitle = "月份";
54                 c3.YTitle = "产量";
55                 c3.XInterval = 2;
56                 c3.YInterval = 10;
57               
58                 c3.init(lst);
59          
60             }
61             catch (Exception ex)
62             {
63                 throw ex;
64             }

 
