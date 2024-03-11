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
    /// 折线图实现
    /// </summary>
    public partial class LineChart : Form
    {
        public LineChart()
        {
            InitializeComponent();

            double[] dataX = GetRandomNum(20).Distinct().OrderByDescending(x => x).ToArray();
            double[] dataY = GetRandomNum(19).Distinct().OrderByDescending(x => x).ToArray();
            formsPlot1.Plot.Add.Scatter(dataX, dataY);
            formsPlot1.Refresh();
        }

        public double[] GetRandomNum(int length)
        {
            double[] getDate = new double[length];
            Random random = new Random(); //创建一个Random实例
            for (int i = 0; i < length; i++)
            {
                getDate[i] = random.Next(1, 100); //使用同一个Random实例生成随机数
            }
            return getDate;
        }
    }
}
