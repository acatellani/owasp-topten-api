using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using owasp_topten_api.Entities;

namespace owasp_topten_api.Entities
{
    public class DataContext : DbContext
    {

        public DbSet<User> Users { get; set; }

        public DbSet<Account> Accounts { get; set; }

        ///static LoggerFactory object
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite("Data Source=DB\\Database.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users");

            modelBuilder.Entity<Account>()
                .ToTable("Accounts")
                .HasOne(p => p.User);

            modelBuilder.Entity<User>().HasData(new User() {
                Id= 1,
                FirstName = "Frida",
                LastName = "Kahlo",
                Username = "fkahlo",
                Password= "123456",
                Role = "User"
            });

            modelBuilder.Entity<Account>().HasData(new {
                Id = 1,
                Balance = 2500m,
                UserId = 1
            });

            modelBuilder.Entity<User>().HasData(new User() {
                Id= 2,
                FirstName = "Albert",
                LastName = "Einstein",
                Username = "aeinstein",
                Password= "123456",
                Role = "User"
            });

            modelBuilder.Entity<Account>().HasData(new {
                Id = 2,
                Balance = 5000m,
                UserId = 2
            });

            modelBuilder.Entity<User>().HasData(new User() {
                Id= 3,
                FirstName = "Chuck",
                LastName = "Norris",
                Username = "cnorris",
                Password= "123456",
                Role = "Admin"
            });

            modelBuilder.Entity<Account>().HasData(new {
                Id = 3,
                Balance = 15000m,
                UserId = 3
            });
        }

    }
}