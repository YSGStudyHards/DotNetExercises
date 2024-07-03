using Terminal.Gui;

namespace TerminalGuiExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 用户登录示例代码

            Application.Run<UserLoginExampleWindow>();

            #endregion

            #region 消息框代码

            Application.Init();

            MessageBox.Query(100, 15,
               "Question", "Do you like console apps?", "Yes", "No");

            Application.Shutdown();

            #endregion

            #region 创建一个简单的带菜单栏的文本用户界面示例代码

            Application.Init();
            var menu = new MenuBar(new MenuBarItem[] {
            new MenuBarItem ("_File", new MenuItem [] {
                new MenuItem ("_Quit", "", () => {
                    Application.RequestStop ();
                })
            }),});

            var win = new Window("追逐时光者，你好！！！")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill() - 1
            };

            Application.Top.Add(menu, win);
            Application.Run();
            Application.Shutdown();

            #endregion
        }
    }

    public class UserLoginExampleWindow : Window
    {
        public TextField usernameText;

        public UserLoginExampleWindow()
        {
            Title = "用户登录示例应用程序（Ctrl+Q退出）";

            //创建输入组件和标签
            var usernameLabel = new Label()
            {
                Text = "用户名:",
                Y = 5
            };

            usernameText = new TextField("")
            {
                X = Pos.Right(usernameLabel),
                Y = Pos.Bottom(usernameLabel) - 1,
                Width = Dim.Fill(),
            };

            var passwordLabel = new Label()
            {
                Text = "密码:",
                X = Pos.Left(usernameLabel),
                Y = Pos.Bottom(usernameLabel) + 5
            };

            var passwordText = new TextField("")
            {
                Secret = true,
                X = Pos.Left(usernameText),
                Y = Pos.Top(passwordLabel),
                Width = Dim.Fill(),
            };

            //创建登录按钮
            var btnLogin = new Button()
            {
                Text = "登录",
                Y = Pos.Bottom(passwordLabel) + 1,
                X = Pos.Center(),
                IsDefault = true,
            };

            //单击登录按钮时显示消息弹出
            btnLogin.Clicked += () =>
            {
                if (usernameText.Text == "admin" && passwordText.Text == "123456")
                {
                    MessageBox.Query("登录结果", "登录成功", "Ok");
                    Application.RequestStop();
                }
                else
                {
                    MessageBox.ErrorQuery("登录结果", "用户名或密码不正确", "Ok");
                }
            };

            //将视图添加到窗口
            Add(usernameLabel, usernameText, passwordLabel, passwordText, btnLogin);
        }
    }
}
