using Eto.Forms;
using Application = Eto.Forms.Application;
using Button = Eto.Forms.Button;
using Form = Eto.Forms.Form;
using Label = Eto.Forms.Label;

namespace EtoFormsExercise
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            new Application(Eto.Platforms.WinForms).Run(new MainForm());
        }
    }

    public class MainForm : Form
    {
        private TextArea textArea;

        public MainForm()
        {
            Title = "My EtoForms Exercise";
            ClientSize = new Eto.Drawing.Size(800, 600);

            // 创建按钮  
            var button = new Button { Text = "Click Me" };
            button.Click += Button_Click;

            // 创建文本区域  
            textArea = new TextArea
            {
                Size = new Eto.Drawing.Size(600, 300)
            };

            // 创建布局  
            var layout = new StackLayout
            {
                Padding = 10,
                Spacing = 10,
                Items =
                {
                    new Label { Text = "Hello, My EtoForms Exercise!" },
                    button,
                    textArea
                }
            };

            Content = layout;
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // 当按钮被点击时，更新文本区域的内容
            textArea.Text += "DotNetGuide技术社区是一个面向.NET开发者的开源技术社区，旨在为开发者们提供全面的C#/.NET/.NET Core相关学习资料、技术分享和咨询、项目框架推荐、求职和招聘资讯、以及解决问题的平台。";
        }
    }
}