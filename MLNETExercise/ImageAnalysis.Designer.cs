using System.Windows.Forms;

namespace MLNETExercise
{
    partial class ImageAnalysis
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
            Btn_SelectImage = new Button();
            label1 = new Label();
            txt_Box = new TextBox();
            pictureBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // Btn_SelectImage
            // 
            Btn_SelectImage.Location = new Point(103, 66);
            Btn_SelectImage.Name = "Btn_SelectImage";
            Btn_SelectImage.Size = new Size(158, 50);
            Btn_SelectImage.TabIndex = 0;
            Btn_SelectImage.Text = "选择图片";
            Btn_SelectImage.UseVisualStyleBackColor = true;
            Btn_SelectImage.Click += Btn_SelectImage_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(103, 265);
            label1.Name = "label1";
            label1.Size = new Size(68, 17);
            label1.TabIndex = 1;
            label1.Text = "分析结果：";
            // 
            // txt_Box
            // 
            txt_Box.Location = new Point(177, 262);
            txt_Box.Name = "txt_Box";
            txt_Box.Size = new Size(162, 23);
            txt_Box.TabIndex = 2;
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(418, 43);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(336, 303);
            pictureBox.TabIndex = 3;
            pictureBox.TabStop = false;
            // 
            // ImageAnalysis
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox);
            Controls.Add(txt_Box);
            Controls.Add(label1);
            Controls.Add(Btn_SelectImage);
            Name = "ImageAnalysis";
            Text = "图像分类";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private void Btn_SelectImage_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Image";
                openFileDialog.Filter = "Image Files (*.jpg, *.png, *.bmp)|*.jpg;*.png;*.bmp|All Files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // 获取用户选择的文件路径
                    string selectedImagePath = openFileDialog.FileName;

                    // 从文件加载图片
                    Image img = Image.FromFile(openFileDialog.FileName);
                    this.pictureBox.Image = img;

                    var imageBytes = File.ReadAllBytes(selectedImagePath);
                    MLImageAnalysis.ModelInput sampleData = new MLImageAnalysis.ModelInput()
                    {
                        ImageSource = imageBytes,
                    };

                    //Load model and predict output
                    var result = MLImageAnalysis.Predict(sampleData);
                    this.txt_Box.Text = result.PredictedLabel;
                }
            }
        }

        #endregion

        private OpenFileDialog openFileDialog;
        private Button Btn_SelectImage;
        private Label label1;
        private TextBox txt_Box;
        private PictureBox pictureBox;
    }
}
