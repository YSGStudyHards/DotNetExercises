using ScottPlot;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScottPlotWinFormsExercise
{
    /// <summary>
    /// 散点图实现
    /// </summary>
    public partial class ScatterChart : Form
    {
        public ScatterChart()
        {
            InitializeComponent();

            //从原始数据开始
            double[] xs = Generate.Consecutive(100);
            double[] ys = Generate.NoisyExponential(100);

            //对数据进行对数缩放，并处理负值
            double[] logYs = ys.Select(Math.Log10).ToArray();

            //将对数缩放的数据添加到绘图中
            var sp = formsPlot1.Plot.Add.Scatter(xs, logYs);
            sp.LineWidth = 0;

            //创建一个次要刻度生成器，用于放置对数分布的次要刻度
            ScottPlot.TickGenerators.LogMinorTickGenerator minorTickGen = new();

            //创建一个数值刻度生成器，使用自定义的次要刻度生成器
            ScottPlot.TickGenerators.NumericAutomatic tickGen = new();
            tickGen.MinorTickGenerator = minorTickGen;

            //创建一个自定义刻度格式化程序，用于设置每个刻度的标签文本
            static string LogTickLabelFormatter(double y) => $"{Math.Pow(10, y):N0}";

            //告诉我们的主要刻度生成器仅显示整数的主要刻度
            tickGen.IntegerTicksOnly = true;

            //告诉我们的自定义刻度生成器使用新的标签格式化程序
            tickGen.LabelFormatter = LogTickLabelFormatter;

            //告诉左轴使用我们的自定义刻度生成器
            formsPlot1.Plot.Axes.Left.TickGenerator = tickGen;

            //显示次要刻度的网格线
            var grid = formsPlot1.Plot.GetDefaultGrid();
            grid.MajorLineStyle.Color = Colors.Black.WithOpacity(.15);
            grid.MinorLineStyle.Color = Colors.Black.WithOpacity(.05);
            grid.MinorLineStyle.Width = 1;

            formsPlot1.Refresh();
        }
    }
}
