using PersonalExpenseTracker.Data.Entities;
using PersonalExpenseTracker.Repository.Interfaces;
using PersonalExpenseTracker.Service.DTOs;
using PersonalExpenseTracker.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.Service.Services
{
    public class ExpenseService : IExpenseService
    {
        private readonly IExpenseRepository _repo;

        public ExpenseService(IExpenseRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<ExpenseDto>> GetAllAsync()
        {
            var data = await _repo.GetAllAsync();

            return data.Select(x => new ExpenseDto
            {
                Id = x.Id,
                Title = x.Title,
                Amount = x.Amount,
                Date = x.Date,
                Notes = x.Notes,
                CategoryName = x.Category.Name,
                HasReceipt = x.ReceiptFileName != null
            }).ToList();
        }

        public async Task<ServiceResult> CreateAsync(ExpenseCreateDto dto)
        {
            var entity = new Expense
            {
                Title = dto.Title,
                Amount = dto.Amount,
                Date = dto.Date,
                Notes = dto.Notes,
                CategoryId = dto.CategoryId,
                ReceiptFileName = dto.ReceiptFileName
            };

            await _repo.AddAsync(entity);

            return ServiceResult.Ok("Expense created");
        }

        public async Task<ServiceResult> DeleteAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);

            if (entity == null)
                return ServiceResult.Fail("Not found");

            await _repo.DeleteAsync(entity);

            return ServiceResult.Ok("Deleted");
        }

        public async Task<ExpenseDto?> DetailsAsync(int id)
        {
            var entity = await _repo.GetByIdAsync(id);

            if (entity == null)
                return null;

            return new ExpenseDto
            {
                Id = entity.Id,
                Title = entity.Title,
                Amount = entity.Amount,
                Date = entity.Date,
                Notes = entity.Notes,
                CategoryName = entity.Category.Name,
                HasReceipt = entity.ReceiptFileName != null
            };
        }

        public Task<ExpenseDto?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ServiceResult> UpdateAsync(ExpenseEditDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
