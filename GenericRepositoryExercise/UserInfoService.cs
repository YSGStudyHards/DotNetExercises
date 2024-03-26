using TanvirArjel.EFCore.GenericRepository;

namespace GenericRepositoryExercise
{
    public class UserInfoService
    {
        private readonly IRepository<TestDbContext> _repository;

        public UserInfoService(IRepository<TestDbContext> repository)
        {
            _repository = repository;
        }

        public async Task UserInfoCRUD()
        {
            // 创建一个新用户
            var newUser = new UserInfo { Name = "daydayup", Age = 28, Email = "daydayup@example.com" };
            await _repository.AddAsync(newUser);
            await _repository.SaveChangesAsync();

            // 更新用户信息
            newUser.Email = "new_updated@example.com";
            _repository.Update(newUser);
            await _repository.SaveChangesAsync();

            // 删除用户
            _repository.Remove(newUser);
            await _repository.SaveChangesAsync();

            // 查询所有用户
            var users = await _repository.GetListAsync<UserInfo>();
            foreach (var user in users)
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Age: {user.Age}, Email: {user.Email}");
            }

            //查询总数
            var totalCount = await _repository.GetCountAsync<UserInfo>();

            // 根据条件查询用户
            var filteredUsers = await _repository.GetListAsync<UserInfo>(u => u.Age > 25);
            foreach (var user in filteredUsers)
            {
                Console.WriteLine($"Id: {user.Id}, Name: {user.Name}, Age: {user.Age}, Email: {user.Email}");
            }
        }
    }
}
