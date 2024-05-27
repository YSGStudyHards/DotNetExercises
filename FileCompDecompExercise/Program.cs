namespace FileCompDecompExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("追逐时光者 Hello, World!");

            string sourceFolder = @".\source"; //要压缩的文件夹路径
            string extractFolder = @".\target\extracted"; //解压后的文件夹路径

            //压缩后的zip文件路径
            string zipFile = @".\target\compressed.zip";

            //创建一个新的 .zip 文件并压缩文件夹内容
            FileCompressionHelper.CreateZipFile(sourceFolder, zipFile);

            //提取 .zip 文件到一个新文件夹
            FileCompressionHelper.ExtractZipFile(zipFile, extractFolder);

            Console.WriteLine("操作完成");
        }
    }
}
