using GBertolini.UsersService.Models.Models.Implementations;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GBertolini.UsersService.DataAccess
{
    public class UsersDbContext : DbContext
    {
        private const string _dbFileName = "users.db";

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
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
    }
}
