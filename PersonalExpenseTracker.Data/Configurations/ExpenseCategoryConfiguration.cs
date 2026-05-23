using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonalExpenseTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.Data.Configurations
{
    public class ExpenseCategoryConfiguration
        : IEntityTypeConfiguration<ExpenseCategory>
    {
        public void Configure(
            EntityTypeBuilder<ExpenseCategory> builder)
        {
            builder.ToTable("ExpenseCategories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.Property(x => x.Description)
                .HasMaxLength(300);

            builder.HasData(
                new ExpenseCategory
                {
                    Id = 1,
                    Name = "Food",
                    Description = "Daily food expenses"
                },

                new ExpenseCategory
                {
                    Id = 2,
                    Name = "Transport",
                    Description = "Travel and transport costs"
                },

                new ExpenseCategory
                {
                    Id = 3,
                    Name = "Utilities",
                    Description = "Electricity, gas, internet bills"
                },

                new ExpenseCategory
                {
                    Id = 4,
                    Name = "Entertainment",
                    Description = "Movies, games and fun"
                }
            );
        }
    }
}
