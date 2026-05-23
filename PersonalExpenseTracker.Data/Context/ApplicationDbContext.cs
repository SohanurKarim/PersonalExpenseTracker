using Microsoft.EntityFrameworkCore;
using PersonalExpenseTracker.Data.Configurations;
using PersonalExpenseTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.Data.Context
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ExpenseCategory> ExpenseCategories { get; set; }

        protected override void OnModelCreating(
            ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(
                new ExpenseConfiguration());

            modelBuilder.ApplyConfiguration(
                new ExpenseCategoryConfiguration());
        }
    }
}
