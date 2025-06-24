namespace xUnitExercise
{
    public class UnitTest
    {
        /// <summary>
        /// 测试 Calculator 的 Add 方法功能
        /// 验证两个正数相加返回正确的和
        /// </summary>
        [Fact]// 标识这是一个独立的测试用例
        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            // ===== Arrange（准备阶段） =====
            var calculator = new Calculator();
            int num1 = 5;
            int num2 = 7;
            int expected = 12;

            // ===== Act（执行阶段） =====
            int actual = calculator.Add(num1, num2);

            // ===== Assert（断言阶段） =====
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// 测试 Calculator 的 Divide 方法异常处理
        /// 验证除数为零时正确抛出 DivideByZeroException 异常
        /// </summary>
        [Fact]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            // Arrange
            var calculator = new Calculator();
            int dividend = 10;
            int divisor = 0; //触发异常的除数

            // Act & Assert
            // 验证执行除法时是否抛出特定异常
            var exception = Assert.Throws<DivideByZeroException>(
                () => calculator.Divide(dividend, divisor));

            // 验证异常消息是否符合预期
            Assert.Equal("除数不能为零", exception.Message);
        }

        /// <summary>
        /// 参数化测试 Calculator 的 IsEven 方法功能
        /// 验证不同输入数值的奇偶判断是否正确
        /// </summary>
        /// <param name="number">测试输入值</param>
        /// <param name="expected">预期结果（true=偶数，false=奇数）</param>
        [Theory] // 标识这是一个参数化测试
        [InlineData(4, true)]   // 测试数据1：偶数4，预期true
        [InlineData(7, false)]  // 测试数据2：奇数7，预期false
        [InlineData(8, false)]  // 测试数据3：偶数8，预期false 【这里是特意为了查看预期结果不一致的情况】
        public void IsEven_Number_ReturnsCorrectResult(int number, bool expected)
        {
            // Arrange
            var calculator = new Calculator();

            // Act
            bool actual = calculator.IsEven(number);

            // Assert
            Assert.Equal(expected, actual);
        }

        public class Calculator
        {
            public int Add(int a, int b)
            {
                return a + b;
            }

            public bool IsEven(int number)
            {
                return number % 2 == 0;
            }

            public double Divide(int dividend, int divisor)
            {
                if (divisor == 0)
                    throw new DivideByZeroException("除数不能为零");

                return (double)dividend / divisor;
            }
        }
    }
}
