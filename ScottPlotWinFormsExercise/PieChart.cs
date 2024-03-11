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
    /// 饼图实现
    /// </summary>
    public partial class PieChart : Form
    {
        public PieChart()
        {
            InitializeComponent();

            double[] values = { 3, 2, 8, 4, 8, 10 };
            formsPlot1.Plot.Add.Pie(values);
            formsPlot1.Refresh();
        }
    }
}
