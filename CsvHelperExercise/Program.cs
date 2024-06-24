using CsvHelper;
using System.Globalization;

namespace CsvHelperExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new List<StudentInfo>
            {
                new StudentInfo { ID = 1, Name = "张三", Age = 20, Class = "终极一班", Gender = "男", Address = "北京市东城区" },
                new StudentInfo { ID = 2, Name = "李四", Age = 21, Class = "终极一班", Gender = "女", Address = "上海市黄浦区" },
                new StudentInfo { ID = 3, Name = "王五", Age = 22, Class = "终极一班", Gender = "男", Address = "广州市越秀区" },
                new StudentInfo { ID = 4, Name = "赵六", Age = 20, Class = "终极二班", Gender = "女", Address = "深圳市福田区" },
                new StudentInfo { ID = 5, Name = "孙七", Age = 23, Class = "终极二班", Gender = "男", Address = "杭州市西湖区" },
                new StudentInfo { ID = 6, Name = "周八", Age = 24, Class = "终极二班", Gender = "女", Address = "南京市玄武区" },
                new StudentInfo { ID = 7, Name = "吴九", Age = 22, Class = "终极二班", Gender = "男", Address = "成都市锦江区" },
                new StudentInfo { ID = 8, Name = "小袁", Age = 21, Class = "终极三班", Gender = "女", Address = "重庆市渝中区" },
                new StudentInfo { ID = 9, Name = "大姚", Age = 20, Class = "终极三班", Gender = "男", Address = "武汉市武昌区" },
                new StudentInfo { ID = 10, Name = "追逐时光者", Age = 23, Class = "终极三班", Gender = "女", Address = "长沙市天心区" }
            };

            //写入CSV文件数据
            using var writer = new StreamWriter(@".\StudentInfoFile.csv");
            using var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(students);

            //读取CSV文件数据
            using var reader = new StreamReader(@".\StudentInfoFile.csv");
            using var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
            var getStudentInfos = csvReader.GetRecords<StudentInfo>().ToList();
        }
    }
}
