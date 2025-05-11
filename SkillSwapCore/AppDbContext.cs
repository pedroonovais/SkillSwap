using Microsoft.EntityFrameworkCore;
using SkillSwapCore.Entities;

namespace SkillSwapCore
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseOracle("YourOracleConnectionString");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(u => u.SkillsOffered)
                .WithOne(s => s.Owner)
                .HasForeignKey(s => s.OwnerId);

            modelBuilder.Entity<User>()
                .HasMany(u => u.TransactionsSent)
                .WithOne(t => t.FromUser)
                .HasForeignKey(t => t.FromUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasMany(u => u.TransactionsReceived)
                .WithOne(t => t.ToUser)
                .HasForeignKey(t => t.ToUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
