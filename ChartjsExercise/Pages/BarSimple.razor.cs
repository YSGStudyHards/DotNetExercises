using ChartjsExercise.Model;

namespace ChartjsExercise.Pages
{
    partial class BarSimple
    {
    }

    public class BarSimpleData
    {
        public static List<string> SimpleBarText = new List<string>() { "一月", "二月", "三月", "四月", "五月", "六月", "七月" };
        public static List<DataItem> SimpleBar = new List<DataItem>()
        {
            new DataItem() { Name = "一月", Value = 65 },
            new DataItem() { Name = "二月", Value = 59 },
            new DataItem() { Name = "三月", Value = 80 },
            new DataItem() { Name = "四月", Value = 81 },
            new DataItem() { Name = "五月", Value = 56 },
            new DataItem() { Name = "六月", Value = 55 },
            new DataItem() { Name = "七月", Value = 40 }
        };
    }
}
