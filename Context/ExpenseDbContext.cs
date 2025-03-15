using Microsoft.EntityFrameworkCore;
using ExpenseSplitterApi.Models;

namespace ExpenseSplitterApi.Context
{
    public class ExpenseDbContext : DbContext
    {
        public ExpenseDbContext(DbContextOptions<ExpenseDbContext> options) : base(options) { }

        public DbSet<Group> Groups { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<UserBalance> UserBalances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasPrecision(18, 2); // 18 digits total, 2 digits after the decimal

            modelBuilder.Entity<UserBalance>()
                .Property(ub => ub.Balance)
                .HasPrecision(18, 2); // 18 digits total, 2 digits after the decimal

            modelBuilder.Entity<Expense>()
    .HasOne(e => e.Group)
    .WithMany(g => g.Expenses) // ✅ Fix: Link navigation to Group's Expense list
    .HasForeignKey(e => e.GroupId)
    .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<UserBalance>()
                .HasOne(ub => ub.Group)
                .WithMany()
                .HasForeignKey(ub => ub.GroupId);

           modelBuilder.Entity<Group>().HasData(
    new Group
    {
        GroupId = 1,
        GroupName = "Office Trip",
        CreatedBy = 101,
       CreatedOn = new DateTime(2025,3,14)
    }
);

        }

    }
}
