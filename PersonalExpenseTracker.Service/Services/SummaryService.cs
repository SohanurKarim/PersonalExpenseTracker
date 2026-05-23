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
    public class SummaryService : ISummaryService
    {
        private readonly IExpenseRepository _repo;

        public SummaryService(IExpenseRepository repo)
        {
            _repo = repo;
        }

        public async Task<SummaryDto> GetSummaryAsync()
        {
            var data = await _repo.GetAllAsync();

            return new SummaryDto
            {
                CurrentMonthTotal = data
                    .Where(x => x.Date.Month == DateTime.Now.Month)
                    .Sum(x => x.Amount),

                CategoryTotals = data
                    .GroupBy(x => x.Category.Name)
                    .Select(x => new CategoryTotalDto
                    {
                        CategoryName = x.Key,
                        TotalAmount = x.Sum(y => y.Amount)
                    }).ToList(),

                RecentExpenses = data
                    .OrderByDescending(x => x.Date)
                    .Take(5)
                    .Select(x => new RecentExpenseDto
                    {
                        Title = x.Title,
                        Amount = x.Amount,
                        Date = x.Date,
                        CategoryName = x.Category.Name
                    }).ToList()
            };
        }
    }
}
