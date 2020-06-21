using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

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
        }

    }
}