using Net.Codecrete.QrCodeGenerator;
using SkiaSharp;
using System.Text;

namespace QrCodeGeneratorExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //生成二维码并保存为png
            var test1 = QrCode.EncodeText("追逐时光者！！！", QrCode.Ecc.Medium);
            test1.SaveAsPng("test1-qr-code.png", 10, 3);

            //生成带颜色的二维码并保存为png
            var test2 = QrCode.EncodeText("追逐时光者！！！", QrCode.Ecc.High);
            test2.SaveAsPng("test2-qr-code.png", 12, 4,
                foreground: SKColor.Parse("#628bb5"),
                background: SKColor.Parse("#ffffff"));

            //生成二维码并保存为svg
            var test3 = QrCode.EncodeText("追逐时光者！！！", QrCode.Ecc.Medium);
            var svg = test3.ToSvgString(4);
            File.WriteAllText("test3-qr-code.svg", svg, Encoding.UTF8);

            //生成带颜色的二维码并保存为svg
            var test4 = QrCode.EncodeText("追逐时光者！！！", QrCode.Ecc.Medium);
            var svg1 = test4.ToSvgString(4, "#98b2cd", "#ffffff");
            File.WriteAllText("test4-qr-code.svg", svg1, Encoding.UTF8);
        }
    }
}
