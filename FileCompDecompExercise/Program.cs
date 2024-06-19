namespace FileCompDecompExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sourceFilePath = @".\MySourceFile.xls"; //指定要压缩的文件路径(先创建对应.xls文件)
            var zipSourceFilePath = @".\OutputFolder\ZipSourceFilePath.zip"; //压缩后文件存放路径
            var zipFilePath = @".\OutputFolder\Archive.zip"; //压缩后文件存放路径
            string extractPath = @".\OutputFolder"; // 解压目标文件夹路径
            var sourceDirectory = @".\ZipFileDirectory";//指定压缩的文件目录（先在对应位置创建好）

            //指定文件压缩为zip文件
            FileCompressionHelper.CompressZipFile(sourceFilePath, zipSourceFilePath);

            //指定文件目录压缩为zip文件
            FileCompressionHelper.CompressZipFileDirectory(sourceDirectory, zipFilePath);

            //解压.zip文件到目标文件夹
            FileCompressionHelper.ExtractZipFile(zipFilePath, extractPath);

            Console.WriteLine("操作完成");
        }
    }
}
