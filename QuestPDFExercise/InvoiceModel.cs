namespace QuestPDFExercise
{
    public class InvoiceModel
    {

        /// <summary>
        /// 发票号码
        /// </summary>
        public int InvoiceNumber { get; set; }

        /// <summary>
        /// 发票开具日期
        /// </summary>
        public DateTime IssueDate { get; set; }

        /// <summary>
        /// 发票到期日期
        /// </summary>
        public DateTime DueDate { get; set; }

        /// <summary>
        /// 卖方公司名称
        /// </summary>
        public string SellerCompanyName { get; set; }

        /// <summary>
        /// 买方公司名称
        /// </summary>
        public string CustomerCompanyName { get; set; }

        /// <summary>
        /// 订单消费列表
        /// </summary>
        public List<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Comments { get; set; }
    }

    public class OrderItem
    {
        /// <summary>
        /// 消费类型
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// 消费数量
        /// </summary>
        public int Quantity { get; set; }
    }
}
