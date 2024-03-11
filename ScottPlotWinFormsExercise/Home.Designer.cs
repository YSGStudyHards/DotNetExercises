
namespace ScottPlotWinFormsExercise
{
    partial class Home
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Btn_LineChart = new Button();
            Btn_BarChart = new Button();
            Btn_PieChart = new Button();
            Btn_ScatterChart = new Button();
            SuspendLayout();
            // 
            // Btn_LineChart
            // 
            Btn_LineChart.Location = new Point(23, 80);
            Btn_LineChart.Name = "Btn_LineChart";
            Btn_LineChart.Size = new Size(120, 65);
            Btn_LineChart.TabIndex = 0;
            Btn_LineChart.Text = "折线图";
            Btn_LineChart.UseVisualStyleBackColor = true;
            Btn_LineChart.Click += Btn_LineChart_Click;
            // 
            // Btn_BarChart
            // 
            Btn_BarChart.Location = new Point(184, 80);
            Btn_BarChart.Name = "Btn_BarChart";
            Btn_BarChart.Size = new Size(120, 65);
            Btn_BarChart.TabIndex = 1;
            Btn_BarChart.Text = "柱状图";
            Btn_BarChart.UseVisualStyleBackColor = true;
            Btn_BarChart.Click += Btn_BarChart_Click;
            // 
            // Btn_PieChart
            // 
            Btn_PieChart.Location = new Point(342, 80);
            Btn_PieChart.Name = "Btn_PieChart";
            Btn_PieChart.Size = new Size(120, 65);
            Btn_PieChart.TabIndex = 2;
            Btn_PieChart.Text = "饼图";
            Btn_PieChart.UseVisualStyleBackColor = true;
            Btn_PieChart.Click += Btn_PieChart_Click;
            // 
            // Btn_ScatterChart
            // 
            Btn_ScatterChart.Location = new Point(509, 80);
            Btn_ScatterChart.Name = "Btn_ScatterChart";
            Btn_ScatterChart.Size = new Size(120, 65);
            Btn_ScatterChart.TabIndex = 3;
            Btn_ScatterChart.Text = "散点图";
            Btn_ScatterChart.UseVisualStyleBackColor = true;
            Btn_ScatterChart.Click += Btn_ScatterChart_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(666, 232);
            Controls.Add(Btn_ScatterChart);
            Controls.Add(Btn_PieChart);
            Controls.Add(Btn_BarChart);
            Controls.Add(Btn_LineChart);
            Name = "Home";
            Text = "ScottPlotExercise";
            ResumeLayout(false);
        }

        private void Btn_ScatterChart_Click(object sender, EventArgs e)
        {
            ScatterChart formScatterChart = new ScatterChart();
            // 显示目标窗体
            formScatterChart.Show();
        }

        private void Btn_PieChart_Click(object sender, EventArgs e)
        {
            PieChart formPieChart = new PieChart();
            // 显示目标窗体
            formPieChart.Show();
        }

        private void Btn_BarChart_Click(object sender, EventArgs e)
        {
            BarChart formbarChart = new BarChart();
            // 显示目标窗体
            formbarChart.Show();
        }

        private void Btn_LineChart_Click(object sender, EventArgs e)
        {
            LineChart formLineChart = new LineChart();
            // 显示目标窗体
            formLineChart.Show();
        }

        #endregion

        private Button Btn_LineChart;
        private Button Btn_BarChart;
        private Button Btn_PieChart;
        private Button Btn_ScatterChart;
    }
}
