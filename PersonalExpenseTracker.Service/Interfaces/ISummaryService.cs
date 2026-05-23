using PersonalExpenseTracker.Service.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.Service.Interfaces
{
    public interface ISummaryService
    {
        Task<SummaryDto> GetSummaryAsync();
    }
}
