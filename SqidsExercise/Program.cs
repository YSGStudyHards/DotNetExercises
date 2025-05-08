using Sqids;

namespace SqidsExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 使用默认选项创建 SqidsEncoder 实例
            var sqids = new SqidsEncoder<int>();

            // 编码单个数字
            var id = sqids.Encode(99);
            Console.WriteLine($"编码单个数字: {id}"); // 输出：Q8P

            // 解码单个 ID
            var number = sqids.Decode(id).Single();
            Console.WriteLine($"解码单个 ID '{id}': {number}"); // 输出：99

            // 编码多个数字
            var ids = sqids.Encode(7, 8, 9);
            Console.WriteLine($"编码多个数字 7, 8, 9: {ids}"); // 输出：ylrR3H

            // 解码多个 ID
            var numbers = sqids.Decode(ids);
            Console.WriteLine($"解码多个 ID '{ids}': {string.Join(", ", numbers)}"); // 输出：7, 8, 9

            // 使用自定义选项创建 SqidsEncoder 实例
            var customSqids = new SqidsEncoder<int>(new SqidsOptions
            {
                Alphabet = "mTHivO7hx3RAbr1f586SwjNnK2lgpcUVuG09BCtekZdJ4DYFPaWoMLQEsXIqyz",//自定义字母表（注意：字母表至少需要 3 个字符）
                MinLength = 5,//最小长度，默认情况下，Sqids 使用尽可能少的字符来编码给定的数字。但是，如果你想让你的所有 ID 至少达到一定的长度（例如，为了美观），你可以通过 MinLength 选项进行配置：
                BlockList = { "whatever", "else", "you", "want" } //自定义黑名单，Sqids 自带一个大的默认黑名单，这将确保常见的诅咒词等永远不会出现在您的 ID 中。您可以像这样向这个默认黑名单添加额外项：
            });

            // 使用自定义 SqidsEncoder 编码和解码
            var customId = customSqids.Encode(8899);
            Console.WriteLine($"使用自定义 SqidsEncoder 编码: {customId}"); // 输出：i1uYg

            var customNumber = customSqids.Decode(customId).Single();
            Console.WriteLine($"使用自定义 SqidsEncoder 解码: {customNumber}"); // 输出：8899
        }
    }
}
