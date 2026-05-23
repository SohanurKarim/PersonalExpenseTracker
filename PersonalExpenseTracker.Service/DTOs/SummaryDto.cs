using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.Service.DTOs
{
    public class SummaryDto
    {
        public decimal CurrentMonthTotal { get; set; }

        public List<CategoryTotalDto> CategoryTotals { get; set; } = new();

        public List<RecentExpenseDto> RecentExpenses { get; set; } = new();
    }
}
