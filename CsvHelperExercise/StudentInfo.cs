using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsvHelperExercise
{
    public class StudentInfo
    {
        /// <summary>
        /// 学生学号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 学生年龄
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// 班级
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public string Gender { get; set; }

        /// <summary>
        /// 住址
        /// </summary>
        public string Address { get; set; }
    }
}
