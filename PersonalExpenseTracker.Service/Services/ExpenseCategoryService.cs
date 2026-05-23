using PersonalExpenseTracker.Data.Entities;
using PersonalExpenseTracker.Repository.Interfaces;
using PersonalExpenseTracker.Service.DTOs;
using PersonalExpenseTracker.Service.Interfaces;

namespace PersonalExpenseTracker.Service.Services
{

    public class ExpenseCategoryService : IExpenseCategoryService
    {
        private readonly IExpenseCategoryRepository _repo;

        public ExpenseCategoryService(IExpenseCategoryRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CategoryDto>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();

            return data.Select(x => new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            }).ToList();
        }

        public async Task<ServiceResult> CreateAsync(CategoryCreateDto dto)
        {
            var exists = await _repo.ExistsAsync(dto.Name);

            if (exists)
                return ServiceResult.Fail("Category already exists");

            var entity = new ExpenseCategory
            {
                Name = dto.Name,
                Description = dto.Description
            };

            await _repo.AddAsync(entity);

            return ServiceResult.Ok("Category created");
        }

        public async Task<ServiceResult> UpdateAsync(CategoryEditDto dto)
        {
            var entity = await _repo.GetByIdAsync(dto.Id);

            if (entity == null)
                return ServiceResult.Fail("Not found");

            entity.Name = dto.Name;
            entity.Description = dto.Description;

            await _repo.UpdateAsync(entity);

            return ServiceResult.Ok("Updated");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdWithExpensesAsync(id);

            if (entity == null)
                return ServiceResult.Fail("Not found");

            if (entity.Expenses.Any())
                return ServiceResult.Fail("Cannot delete category with expenses");

            await _repo.DeleteAsync(entity);

            return ServiceResult.Ok("Deleted");
        }

        public async Task<CategoryDto?> GetByIdAsync(int id)
        {
            var x = await _repo.GetByIdAsync(id);

            if (x == null) return null;

            return new CategoryDto
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            };
        }
    }
}
