using Yitter.IdGenerator;

namespace IdGeneratorExercise
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 第一步：全局初始化（应用程序启动时执行一次）

            // 创建 IdGeneratorOptions 对象，可在构造函数中输入 WorkerId：
            // options.WorkerIdBitLength = 10; // 默认值6，限定 WorkerId 最大值为2^6-1，即默认最多支持64个节点。
            // options.SeqBitLength = 6; // 默认值6，限制每毫秒生成的ID个数。若生成速度超过5万个/秒，建议加大 SeqBitLength 到 10。
            // options.BaseTime = Your_Base_Time; // 如果要兼容老系统的雪花算法，此处应设置为老系统的BaseTime。
            // WorkerId：WorkerId，机器码，最重要参数，无默认值，必须 全局唯一（或相同 DataCenterId 内唯一），必须 程序设定，缺省条件（WorkerIdBitLength取默认值）时最大值63，理论最大值 2^WorkerIdBitLength-1（不同实现语言可能会限定在 65535 或 32767，原理同 WorkerIdBitLength 规则）。不同机器或不同应用实例 不能相同，你可通过应用程序配置该值，也可通过调用外部服务获取值。
            // ...... 其它参数参考 IdGeneratorOptions 定义。
            var idGeneratorOptions = new IdGeneratorOptions(1) { WorkerIdBitLength = 6 };
            // 保存参数（务必调用，否则参数设置不生效）：
            YitIdHelper.SetIdGenerator(idGeneratorOptions);
            // 以上过程只需全局一次，且应在生成ID之前完成。

            #endregion

            #region 第二步：生成分布式ID

            for (int i = 0; i < 1000; i++)
            {
                // 初始化后，在任何需要生成ID的地方，调用以下方法：
                var newId = YitIdHelper.NextId();
                Console.WriteLine($"Number{i}，{newId}");
            }

            #endregion
        }
    }
}
