using PersonalExpenseTracker.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.Service.Interfaces
{
    public interface IExpenseService
    {
        Task<List<ExpenseDto>> GetAllAsync();
        Task<ExpenseEditDto?> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(ExpenseCreateDto dto);
        Task<ServiceResult> UpdateAsync(ExpenseEditDto dto);
        Task<ServiceResult> DeleteAsync(int id);
        Task<ExpenseDto?> DetailsAsync(int id);
    }
}
