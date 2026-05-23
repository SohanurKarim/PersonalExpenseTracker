using PersonalExpenseTracker.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.Repository.Interfaces
{
    public interface IExpenseCategoryRepository
        : IRepository<ExpenseCategory>
    {
        Task<bool> ExistsAsync(string name);

        Task<ExpenseCategory?> GetByIdWithExpensesAsync(int id);
    }
}
