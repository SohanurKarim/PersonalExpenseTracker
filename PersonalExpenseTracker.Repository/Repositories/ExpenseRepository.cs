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

    public class ExpenseRepository
        : Repository<Expense>,
          IExpenseRepository
    {
        public ExpenseRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public override async Task<IEnumerable<Expense>> GetAllAsync()
        {
            return await _context.Expenses
                .Include(x => x.Category)
                .OrderByDescending(x => x.Date)
                .ToListAsync();
        }

        public override async Task<Expense?> GetByIdAsync(int id)
        {
            return await _context.Expenses
                .Include(x => x.Category)
                .FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
