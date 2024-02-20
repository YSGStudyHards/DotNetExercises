using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace QuestPDFExercise
{
    public class CreateInvoiceDocument : IDocument
    {
        /// <summary>
        /// 获取Logo的的Image对象
        /// </summary>
        public static Image LogoImage { get; } = Image.FromFile("dotnetguide.png");

        public InvoiceModel Model { get; }

        public CreateInvoiceDocument(InvoiceModel model)
        {
            Model = model;
        }

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    //设置页面的边距
                    page.Margin(50);

                    //字体默认大小18号字体
                    page.DefaultTextStyle(x => x.FontSize(18));

                    //页眉部分
                    page.Header().Element(BuildHeaderInfo);

                    //内容部分
                    page.Content().Element(BuildContentInfo);

                    //页脚部分
                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.CurrentPageNumber();
                        text.Span(" / ");
                        text.TotalPages();
                    });
                });
        }

        #region 构建页眉部分
        void BuildHeaderInfo(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(column =>
                {
                    column.Item().Text($"发票编号 #{Model.InvoiceNumber}").FontFamily("fangsong").FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);

                    column.Item().Text(text =>
                    {
                        text.Span("发行日期: ").FontFamily("fangsong").FontSize(13).SemiBold();
                        text.Span($"{Model.IssueDate:d}");
                    });

                    column.Item().Text(text =>
                    {
                        text.Span("终止日期: ").FontFamily("fangsong").FontSize(13).SemiBold();
                        text.Span($"{Model.DueDate:d}");
                    });
                });

                //在当前行的常量项中插入一个图像
                row.ConstantItem(130).Image(LogoImage);
            });
        }

        #endregion

        #region 构建内容部分

        void BuildContentInfo(IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(20);

                column.Item().Row(row =>
                {
                    row.RelativeItem().Component(new AddressComponent("卖方公司名称", Model.SellerCompanyName));
                    row.ConstantItem(50);
                    row.RelativeItem().Component(new AddressComponent("客户公司名称", Model.CustomerCompanyName));
                });

                column.Item().Element(CreateTable);

                var totalPrice = Model.OrderItems.Sum(x => x.Price * x.Quantity);
                column.Item().PaddingRight(5).AlignRight().Text($"总计: {totalPrice}").FontFamily("fangsong").SemiBold();

                if (!string.IsNullOrWhiteSpace(Model.Comments))
                    column.Item().PaddingTop(25).Element(BuildComments);
            });
        }

        /// <summary>
        /// 创建表格
        /// </summary>
        /// <param name="container">container</param>
        void CreateTable(IContainer container)
        {
            var headerStyle = TextStyle.Default.SemiBold();

            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(25);
                    columns.RelativeColumn(3);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.Header(header =>
                {
                    header.Cell().Text("#").FontFamily("fangsong");
                    header.Cell().Text("消费类型").Style(headerStyle).FontFamily("fangsong");
                    header.Cell().AlignRight().Text("花费金额").Style(headerStyle).FontFamily("fangsong");
                    header.Cell().AlignRight().Text("数量").Style(headerStyle).FontFamily("fangsong");
                    header.Cell().AlignRight().Text("总金额").Style(headerStyle).FontFamily("fangsong");
                    //设置了表头单元格的属性
                    header.Cell().ColumnSpan(5).PaddingTop(5).BorderBottom(1).BorderColor(Colors.Black);
                });

                foreach (var item in Model.OrderItems)
                {
                    var index = Model.OrderItems.IndexOf(item) + 1;

                    table.Cell().Element(CellStyle).Text($"{index}").FontFamily("fangsong");
                    table.Cell().Element(CellStyle).Text(item.Name).FontFamily("fangsong");
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.Price}").FontFamily("fangsong");
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.Quantity}").FontFamily("fangsong");
                    table.Cell().Element(CellStyle).AlignRight().Text($"{item.Price * item.Quantity}").FontFamily("fangsong");
                    static IContainer CellStyle(IContainer container) => container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                }
            });
        }

        #endregion

        #region 构建页脚部分

        void BuildComments(IContainer container)
        {
            container.ShowEntire().Background(Colors.Grey.Lighten3).Padding(10).Column(column =>
            {
                column.Spacing(5);
                column.Item().Text("DotNetGuide技术社区介绍").FontSize(14).FontFamily("fangsong").SemiBold();
                column.Item().Text(Model.Comments).FontFamily("fangsong");
            });
        }

        #endregion
    }

    public class AddressComponent : IComponent
    {
        private string Title { get; }
        private string CompanyName { get; }

        public AddressComponent(string title, string companyName)
        {
            Title = title;
            CompanyName = companyName;
        }

        public void Compose(IContainer container)
        {
            container.ShowEntire().Column(column =>
            {
                column.Spacing(2);

                column.Item().Text(Title).FontFamily("fangsong").SemiBold();
                column.Item().PaddingBottom(5).LineHorizontal(1);
                column.Item().Text(CompanyName).FontFamily("fangsong");
            });
        }
    }
}
