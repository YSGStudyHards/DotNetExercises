using Docnet.Core;
using Docnet.Core.Editors;
using Docnet.Core.Models;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace DocNETExercises
{
    internal class Program
    {
        private const string FilePath = "Assets/VS Code常用快捷键.pdf";
        private static readonly DocLib _docNetInstance = DocLib.Instance;


        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            PDFConvertToImage();
            JPEGImageConvertToPDF();
            GetPDFText();
            GetPDFPageCountAndVersion();
        }

        /// <summary>
        /// 获取 PDF 文件页码和版本
        /// </summary>
        public static void GetPDFPageCountAndVersion()
        {
            using var docReader = _docNetInstance.GetDocReader(FilePath, new PageDimensions(1080, 1920));
            var getPageCount = docReader.GetPageCount();
            var getPdfVersion = docReader.GetPdfVersion();
            Console.WriteLine($"PageCount：{getPageCount}，PdfVersion：{getPdfVersion}");
        }

        /// <summary>
        /// 获取 PDF 文件的文本内容
        /// </summary>
        public static void GetPDFText()
        {
            using var docReader = _docNetInstance.GetDocReader(FilePath, new PageDimensions(1080, 1920));
            using var pageReader = docReader.GetPageReader(0); //注意pageIndex从0开始

            // 获取指定页面的文本（自动处理编码）
            string pageText = pageReader.GetText();

            Console.WriteLine(pageText);
        }

        /// <summary>
        /// 将 JPEG 图片转换为 PDF 文件
        /// </summary>
        public static void JPEGImageConvertToPDF()
        {
            var file = new JpegImage
            {
                Bytes = File.ReadAllBytes("Assets/image1.jpeg"),
                Width = 580,
                Height = 387
            };

            var bytes = _docNetInstance.JpegToPdf(new[] { file });

            File.WriteAllBytes("Assets/output_file.pdf", bytes);
        }

        /// <summary>
        /// 将 PDF 文件转换为图片
        /// </summary>
        public static void PDFConvertToImage()
        {
            using var docReader = _docNetInstance.GetDocReader(FilePath, new PageDimensions(1080, 1920));
            //指定第一页
            using var pageReader = docReader.GetPageReader(0);

            var rawBytes = pageReader.GetImage();
            var width = pageReader.GetPageWidth();
            var height = pageReader.GetPageHeight();
            var characters = pageReader.GetCharacters();

            using var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            AddBytes(bmp, rawBytes);
            DrawRectangles(bmp, characters);

            using var stream = new MemoryStream();

            bmp.Save(stream, ImageFormat.Png);

            File.WriteAllBytes("Assets/output_image.png", stream.ToArray());
        }

        private static void AddBytes(Bitmap bmp, byte[] rawBytes)
        {
            var rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

            var bmpData = bmp.LockBits(rect, ImageLockMode.WriteOnly, bmp.PixelFormat);
            var pNative = bmpData.Scan0;

            Marshal.Copy(rawBytes, 0, pNative, rawBytes.Length);
            bmp.UnlockBits(bmpData);
        }

        private static void DrawRectangles(Bitmap bmp, IEnumerable<Character> characters)
        {
            var pen = new Pen(Color.Red);

            using var graphics = Graphics.FromImage(bmp);

            foreach (var c in characters)
            {
                var rect = new Rectangle(c.Box.Left, c.Box.Top, c.Box.Right - c.Box.Left, c.Box.Bottom - c.Box.Top);
                graphics.DrawRectangle(pen, rect);
            }
        }
    }
}
