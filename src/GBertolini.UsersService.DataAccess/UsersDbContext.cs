using GBertolini.UsersService.Models.Models.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace GBertolini.UsersService.DataAccess
{
    public class UsersDbContext : DbContext
    {
        private const string _dbFileName = "users.db";

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (IsUnitTestingEnvironment())
                CreateContextForInMemory(optionsBuilder);
            else
                CreateContextForSQLite(optionsBuilder);
        }

        private void CreateContextForInMemory(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "usersDbInMemory");
            base.OnConfiguring(optionsBuilder);
        }

        private void CreateContextForSQLite(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: $"Filename={_dbFileName}",
                sqliteOptionsAction: options =>
                {
                    options.MigrationsAssembly(Assembly.GetExecutingAssembly().FullName);
                });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(user => user.Id);
            });
            base.OnModelCreating(modelBuilder);
        }

        private static bool IsUnitTestingEnvironment()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            return environment != null ? environment.Equals("UnitTesting") : false;
        }
    }
}
