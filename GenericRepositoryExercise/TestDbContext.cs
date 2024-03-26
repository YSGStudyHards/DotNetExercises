using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryExercise
{
    public class TestDbContext : DbContext
    {
        public TestDbContext(DbContextOptions<TestDbContext> options) : base(options)
        {
        }

        public DbSet<UserInfo> UserInfo { get; set; }
    }
}
