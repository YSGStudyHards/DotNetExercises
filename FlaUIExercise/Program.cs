using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.UIA3;
using System;

namespace FlaUIExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            OperateNotepad();
        }

        /// <summary>
        /// 操作记事本（Notepad）
        /// </summary>
        /// <returns></returns>
        private static void OperateNotepad()
        {
            // 启动记事本
            var notepadApp = Application.Launch("notepad.exe");
            using (var automation = new UIA3Automation())
            {
                var window = notepadApp.GetMainWindow(automation);
                window.WaitUntilClickable();

                Console.WriteLine(window.Title);

                // 获取编辑框（Edit 控件）
                var edit = window.FindFirstDescendant(cf => cf.ByControlType(ControlType.Document))
                                ?.AsTextBox();

                if (edit == null)
                {
                    Console.WriteLine("未找到记事本编辑区域！");
                    notepadApp.Close();
                    return;
                }

                // 输入文本
                edit.Text = "⚔【DotNetGuide专栏C#/.NET/.NET Core编程技巧练习集】C#/.NET/.NET Core编程常用语法、算法、技巧、中间件、类库、工作业务实操练习集，配套详细的文章教程和代码示例，助力快速掌握C#/.NET/.NET Core中各种编程常用语法、算法、技巧、中间件、类库、工作业务实操等等。";
                notepadApp.Close();
            }

            return;
        }
    }
}
