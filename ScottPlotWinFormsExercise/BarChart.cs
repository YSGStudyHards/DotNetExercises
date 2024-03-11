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
    /// 柱状图实现
    /// </summary>
    public partial class BarChart : Form
    {
        public BarChart()
        {
            InitializeComponent();

            double[] values = { 5, 10, 7, 13, 22, 18, 33, 16 };
            formsPlot1.Plot.Add.Bars(values);
            formsPlot1.Refresh();
        }
    }
}
