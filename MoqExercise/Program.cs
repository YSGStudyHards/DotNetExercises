using Moq;

namespace MoqExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserInfoTest();
            VerifyTest();
            TestThrowException();
        }

        public static void UserInfoTest()
        {
            // 创建 IUserInfo 的模拟对象  
            var mockUserInfo = new Mock<IUserInfo>();

            // 设置模拟对象的属性值  
            mockUserInfo.SetupProperty(u => u.UserName, "大姚");
            mockUserInfo.SetupProperty(u => u.Age, 27);

            // 设置 GetUserData 方法的返回值  
            mockUserInfo.Setup(u => u.GetUserData()).Returns("UserName: 大姚, Age: 25");

            // 获取模拟对象的实例
            var userInfo = mockUserInfo.Object;

            // 调用方法并输出结果  
            Console.WriteLine(userInfo.GetUserData());
            Console.WriteLine("UserName: {0}, Age: {1}", userInfo.UserName, userInfo.Age);
        }

        public static void VerifyTest()
        {
            // 创建模拟对象
            var serviceMock = new Mock<IVerifyService>();

            // 创建被测试对象并注入模拟对象
            var serviceClient = new VerifyServiceClient(serviceMock.Object);

            // 执行测试
            serviceClient.Execute([1, 2, 3]);

            // 验证方法调用次数和参数
            serviceMock.Verify(x => x.Process(1));
            serviceMock.Verify(x => x.Process(3));
            serviceMock.Verify(x => x.Process(2));
            //serviceMock.Verify(x => x.Process(12));   //这里会抛出异常，表示验证失败

            // 如果运行到这里没有抛出异常，表示验证通过
            Console.WriteLine("验证通过！");
        }

        public static void TestThrowException()
        {
            // 创建 IUserInfo 的模拟对象
            var mockUserInfo = new Mock<IUserInfo>();

            // 设置 GetUserData 方法在调用时抛出异常  
            mockUserInfo.Setup(x => x.GetUserData()).Throws(new Exception("模拟的异常"));

            // 获取模拟对象的实例
            var userInfo = mockUserInfo.Object.GetUserData();
        }
    }
}
