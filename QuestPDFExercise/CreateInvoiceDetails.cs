namespace QuestPDFExercise
{
    public class CreateInvoiceDetails
    {
        private static readonly Random _random = new Random();

        public enum InvoiceType
        {
            餐饮费,
            交通费,
            住宿费,
            日用品,
            娱乐费,
            医疗费,
            通讯费,
            教育费,
            装修费,
            旅游费
        }

        /// <summary>
        /// 获取发票详情数据
        /// </summary>
        /// <returns></returns>
        public static InvoiceModel GetInvoiceDetails()
        {
            return new InvoiceModel
            {
                InvoiceNumber = _random.Next(1_000, 10_000),
                IssueDate = DateTime.Now,
                DueDate = DateTime.Now + TimeSpan.FromDays(14),
                SellerCompanyName = "追逐时光者",
                CustomerCompanyName = "DotNetGuide技术社区",
                OrderItems = Enumerable
                .Range(1, 20)
                .Select(_ => GenerateRandomOrderItemInfo())
                .ToList(),
                Comments = "DotNetGuide技术社区是一个面向.NET开发者的开源技术社区，旨在为开发者们提供全面的C#/.NET/.NET Core相关学习资料、技术分享和咨询、项目推荐、招聘资讯和解决问题的平台。在这个社区中，开发者们可以分享自己的技术文章、项目经验、遇到的疑难技术问题以及解决方案，并且还有机会结识志同道合的开发者。我们致力于构建一个积极向上、和谐友善的.NET技术交流平台，为广大.NET开发者带来更多的价值和成长机会。"
            };
        }

        /// <summary>
        /// 订单信息生成
        /// </summary>
        /// <returns></returns>
        private static OrderItem GenerateRandomOrderItemInfo()
        {
            var types = (InvoiceType[])Enum.GetValues(typeof(InvoiceType));
            return new OrderItem
            {
                Name = types[_random.Next(types.Length)].ToString(),
                Price = (decimal)Math.Round(_random.NextDouble() * 100, 2),
                Quantity = _random.Next(1, 10)
            };
        }
    }
}
