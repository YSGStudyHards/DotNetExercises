using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileCompDecompExercise
{
    /// <summary>
    /// 文件压缩帮助类（.zip文件和.gz文件）
    /// </summary>
    public class FileCompressionHelper
    {
        public static void CompressZipFile(string sourceFile, string zipFile)
        {
            //创建一个新的 .zip 文件并将文件夹内容压缩进去
            ZipFile.CreateFromDirectory(sourceFile, zipFile);
            Console.WriteLine("文件压缩完成");
        }

        public static void ExtractZipFile(string zipFile, string extractFolder)
        {
            if (!Directory.Exists(extractFolder))
            {
                // 如果文件夹不存在，则创建该文件夹
                Directory.CreateDirectory(extractFolder);
            }

            // 提取 .zip 文件到指定文件夹
            ZipFile.ExtractToDirectory(zipFile, extractFolder);
            Console.WriteLine("文件解压完成");
        }

    }
}
