using System.IO.Compression;

namespace FileCompDecompExercise
{
    /// <summary>
    /// 文件压缩帮助类（.zip文件）
    /// </summary>
    public class FileCompressionHelper
    {
        /// <summary>
        /// 指定文件目录压缩为zip文件
        /// </summary>
        /// <param name="sourceDirectory">指定压缩的文件目录</param>
        /// <param name="zipFilePath">压缩后文件存放路径</param>
        public static void CompressZipFileDirectory(string sourceDirectory, string zipFilePath)
        {
            //确保指定的路径中的目录存在
            DirectoryInfo directoryInfo = new DirectoryInfo(zipFilePath);
            if (directoryInfo.Parent != null)
            {
                directoryInfo = directoryInfo.Parent;
            }

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            //创建一个新的 .zip 文件并将文件夹内容压缩进去
            ZipFile.CreateFromDirectory(sourceDirectory, zipFilePath, CompressionLevel.Optimal, false);
            Console.WriteLine("文件目录压缩完成");
        }

        /// <summary>
        /// 指定文件压缩为zip文件
        /// </summary>
        /// <param name="sourceFilePath">指定要压缩的文件路径</param>
        /// <param name="zipFilePath">指定压缩后的zip文件路径</param>
        public static void CompressZipFile(string sourceFilePath, string zipFilePath)
        {
            //确保指定的路径中的目录存在
            DirectoryInfo directoryInfo = new DirectoryInfo(zipFilePath);
            if (directoryInfo.Parent != null)
            {
                directoryInfo = directoryInfo.Parent;
            }

            if (!directoryInfo.Exists)
            {
                directoryInfo.Create();
            }

            // 创建一个新的 Zip 存档并向其中添加指定的文件
            using (ZipArchive archive = ZipFile.Open(zipFilePath, ZipArchiveMode.Update))
            {
                archive.CreateEntryFromFile(sourceFilePath, Path.GetFileName(sourceFilePath));
            }
            Console.WriteLine("文件压缩完成");
        }

        /// <summary>
        /// 解压.zip文件到目标文件夹
        /// </summary>
        /// <param name="zipFilePath">要解压的.zip文件路径</param>
        /// <param name="extractPath">解压目标文件夹路径</param>
        public static void ExtractZipFile(string zipFilePath, string extractPath)
        {
            if (!Directory.Exists(extractPath))
            {
                Directory.CreateDirectory(extractPath);
            }

            // 提取 .zip 文件到指定文件夹
            ZipFile.ExtractToDirectory(zipFilePath, extractPath);
            Console.WriteLine("文件解压完成");
        }
    }
}
