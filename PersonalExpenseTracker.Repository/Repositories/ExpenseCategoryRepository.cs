using Microsoft.EntityFrameworkCore;
using PersonalExpenseTracker.Data.Context;
using PersonalExpenseTracker.Data.Entities;
using PersonalExpenseTracker.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.Repository.Repositories
{

    public class ExpenseCategoryRepository
        : Repository<ExpenseCategory>,
          IExpenseCategoryRepository
    {
        public ExpenseCategoryRepository(
            ApplicationDbContext context)
            : base(context)
        {
        }

        public async Task<bool> ExistsAsync(string name)
        {
            return await _context.ExpenseCategories
                .AnyAsync(x => x.Name.ToLower() == name.ToLower());
        }

        public async Task<ExpenseCategory?>
            GetByIdWithExpensesAsync(int id)
        {
            return await _context.ExpenseCategories
                .Include(x => x.Expenses)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<IEnumerable<ExpenseCategory>>
            GetAllAsync()
        {
            return await _context.ExpenseCategories
                .OrderBy(x => x.Name)
                .ToListAsync();
        }
    }
}
