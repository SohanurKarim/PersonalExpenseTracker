using PersonalExpenseTracker.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.Service.Interfaces
{

    public interface IExpenseCategoryService
    {
        Task<List<CategoryDto>> GetAllAsync();
        Task<CategoryDto?> GetByIdAsync(int id);
        Task<ServiceResult> CreateAsync(CategoryCreateDto dto);
        Task<ServiceResult> UpdateAsync(CategoryEditDto dto);
        Task<ServiceResult> DeleteAsync(int id);
    }
}
