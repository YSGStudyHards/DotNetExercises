using NetDimension.NanUI;
using NetDimension.NanUI.Forms;

namespace NanUIExercise
{
    public class MyWindow : Formium
    {
        public MyWindow()
        {
            Url = "https://juejin.cn/";
        }

        protected override FormStyle ConfigureWindowStyle(WindowStyleBuilder builder)
        {
            // 此处配置窗口的样式和属性，或留空以使用默认样式

            var style = builder.UseSystemForm();

            style.TitleBar = false;

            style.DefaultAppTitle = "My First NanUI App";

            return style;
        }
    }
}
