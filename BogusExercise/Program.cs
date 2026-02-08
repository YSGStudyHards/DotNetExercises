using Bogus;

namespace BogusExercise
{
    public class Program
    {
        static void Main(string[] args)
        {
            //生成 3 个随机订单的模拟用户信息
            var users = GenerateSampleUsers(3);

            // 生成随机用户信息
            //GenerateRandomData();

            // 使用自定义扩展
            var faker = new Faker();
            Console.WriteLine($"最爱糖果: {faker.Candy()}");
            Console.WriteLine($"最爱饮料: {faker.Drink()}");
        }

        /// <summary>
        /// 生成随机订单的模拟用户
        /// </summary>
        /// <param name="count"></param>
        /// <returns></returns>
        public static List<User> GenerateSampleUsers(int count = 3)
        {
            // 设置随机种子，生成可重复的数据集
            Randomizer.Seed = new Random(3897234);

            var fruit = new[] { "apple", "banana", "orange", "strawberry", "kiwi" };

            var orderIds = 0;
            var testOrders = new Faker<Order>()
                // 开启严格模式：确保所有属性都有规则
                .StrictMode(true)
                // OrderId 自增
                .RuleFor(o => o.OrderId, f => orderIds++)
                // 从水果篮中随机挑选
                .RuleFor(o => o.Item, f => f.PickRandom(fruit))
                // 随机数量 1~10
                .RuleFor(o => o.Quantity, f => f.Random.Number(1, 10))
                // 可空 int?，80% 概率为 null
                .RuleFor(o => o.LotNumber, f => f.Random.Int(0, 100).OrNull(f, .8f));

            var userIds = 0;
            var testUsers = new Faker<User>()
                // 自定义构造函数
                .CustomInstantiator(f => new User(userIds++, f.Random.Replace("###-##-####")))
                // 基本规则
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Avatar, f => f.Internet.Avatar())
                .RuleFor(u => u.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
                .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                .RuleFor(u => u.SomethingUnique, f => $"Value {f.UniqueIndex}")
                .RuleFor(u => u.SomeGuid, Guid.NewGuid)
                // 随机选取枚举
                .RuleFor(u => u.Gender, f => f.PickRandom<Gender>())
                .RuleFor(u => u.CartId, f => Guid.NewGuid())
                // 组合属性：利用已生成的 FirstName 和 LastName
                .RuleFor(u => u.FullName, (f, u) => u.FirstName + " " + u.LastName)
                // 嵌套集合生成
                .RuleFor(u => u.Orders, f => testOrders.Generate(3))
                // 生成完成后的回调
                .FinishWith((f, u) =>
                {
                    Console.WriteLine("User Created! Name={0}", u.FullName);
                });

            // 一次生成 3 个用户
            return testUsers.Generate(count);
        }

        /// <summary>
        /// 生成随机用户信息
        /// </summary>
        public static void GenerateRandomData()
        {
            // 自动生成姓名、邮箱、地址、电话等关联数据
            var faker = new Faker("zh_CN");// 使用简体中文
            var randomName = faker.Name.FullName();
            var randomEmail = faker.Internet.Email();
            var randomAddress = faker.Address.FullAddress();
            var randomPhone = faker.Phone.PhoneNumber();
            Console.WriteLine($"Name: {randomName}");
            Console.WriteLine($"Email: {randomEmail}");
            Console.WriteLine($"Address: {randomAddress}");
            Console.WriteLine($"Phone: {randomPhone}");
        }
    }

    /// <summary>
    /// 为 Bogus 的 Faker 类提供食品相关的自定义假数据扩展方法
    /// </summary>
    public static class FoodExtensions
    {
        /// <summary>
        /// 生成一个随机的糖果名称
        /// </summary>
        /// <param name="faker"></param>
        /// <returns></returns>
        public static string Candy(this Faker faker)
        {
            return faker.PickRandom(new[] { "巧克力", "棒棒糖", "口香糖", "软糖", "太妃糖" });
        }

        /// <summary>
        /// 生成一个随机的饮品名称
        /// </summary>
        /// <param name="faker"></param>
        /// <returns></returns>
        public static string Drink(this Faker faker)
        {
            return faker.PickRandom(new[] { "可乐", "雪碧", "橙汁", "咖啡", "牛奶" });
        }
    }

    /// <summary>
    /// EF Core 数据库种子数据填充
    /// 适合开发/测试环境，在应用启动时自动填充数据：
    /// FakeData.Init(10); // 生成 10 个 Blog，每个包含 3~5 篇 Post
    /// </summary>
    public static class FakeData
    {
        public static List<Blog> Blogs = new List<Blog>();
        public static List<Post> Posts = new List<Post>();

        public static void Init(int count)
        {
            var postId = 1;
            var postFaker = new Faker<Post>()
                .RuleFor(p => p.PostId, _ => postId++)
                .RuleFor(p => p.Title, f => f.Hacker.Phrase())
                .RuleFor(p => p.Content, f => f.Lorem.Sentence());

            var blogId = 1;
            var blogFaker = new Faker<Blog>()
                .RuleFor(b => b.BlogId, _ => blogId++)
                .RuleFor(b => b.Url, f => f.Internet.Url())
                .RuleFor(b => b.Posts, (f, b) =>
                {
                    postFaker.RuleFor(p => p.BlogId, _ => b.BlogId);
                    var posts = postFaker.GenerateBetween(3, 5);

                    // 关键：收集所有 Posts 到静态列表中
                    Posts.AddRange(posts);

                    return posts;
                });

            // 清空旧数据，避免重复调用累积
            Blogs.Clear();
            Posts.Clear();

            Blogs = blogFaker.Generate(count);
        }
    }

    /// <summary>
    /// Blog
    /// </summary>
    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }
        public List<Post> Posts { get; set; }
    }

    /// <summary>
    /// Post
    /// </summary>
    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; }
    }

    /// <summary>
    /// 订单实体
    /// </summary>
    public class Order
    {
        public int OrderId { get; set; }
        public string Item { get; set; }
        public int Quantity { get; set; }
        public int? LotNumber { get; set; }
    }

    /// <summary>
    /// 性别枚举
    /// </summary>
    public enum Gender
    {
        Male,
        Female
    }

    /// <summary>
    /// 用户实体
    /// </summary>
    public class User
    {
        public User(int userId, string ssn)
        {
            this.Id = userId;
            this.SSN = ssn;
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string SomethingUnique { get; set; }
        public Guid SomeGuid { get; set; }
        public string Avatar { get; set; }
        public Guid CartId { get; set; }
        public string SSN { get; set; }
        public Gender Gender { get; set; }
        public List<Order> Orders { get; set; }
    }
}
