using Spectre.Console;

namespace SpectreExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //原生控制台文字输出
            Console.WriteLine("你好追逐时光者！！！");

            //类库设置控制台文字输出
            //类库文档颜色选择表：https://spectreconsole.net/appendix/colors
            AnsiConsole.Markup("[underline red]你好[/][Blue]追逐时光者[/][DarkMagenta]！！！[/]");

            #region 创建表
            // 创建表
            var table = new Table();

            //添加一些列
            table.AddColumn("[red]编号[/]");
            table.AddColumn("[green]姓名[/]");
            table.AddColumn("[blue]年龄[/]");

            //添加一些行
            table.AddRow("1", "追逐时光者", "20岁");
            table.AddRow("2", "大姚", "22岁");
            table.AddRow("3", "小袁", "18岁");
            table.AddRow("4", "小明", "23岁");

            // 将表格渲染到控制台
            AnsiConsole.Write(table);
            #endregion

            #region 条形图

            AnsiConsole.Write(new BarChart()
    .Width(60)
    .Label("[green bold underline]水果数量[/]")
    .CenterLabel()
    .AddItem("苹果", 12, Color.Yellow)
    .AddItem("西瓜", 54, Color.Green)
    .AddItem("香蕉", 33, Color.Red)
    .AddItem("芒果", 55, Color.Blue));

            #endregion


            //日历
            var calendar = new Calendar(2024, 5);
            AnsiConsole.Write(calendar);

            #region 布局

            // Create the layout
            var layout = new Layout("Root")
                .SplitColumns(
                    new Layout("Left"),
                    new Layout("Right")
                        .SplitRows(
                            new Layout("Top"),
                            new Layout("Bottom")));

            // Update the left column
            layout["Left"].Update(
                new Panel(
                    Align.Center(
                        new Markup("[blue]你好![/]"),
                        VerticalAlignment.Middle))
                    .Expand());

            // Render the layout
            AnsiConsole.Write(layout);

            #endregion

            #region 规则水平线

            var rule = new Rule("[red]Hello[/]");
            AnsiConsole.Write(rule);

            var ruleLeft = new Rule("[blue]Hello[/]");
            ruleLeft.Justification = Justify.Left;
            AnsiConsole.Write(ruleLeft);

            var ruleRight = new Rule("[yellow]Hello[/]");
            ruleRight.Justification = Justify.Right;
            AnsiConsole.Write(ruleRight);

            #endregion

        }
    }
}
