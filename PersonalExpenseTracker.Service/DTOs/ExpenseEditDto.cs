using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.Service.DTOs
{
    public class ExpenseEditDto : ExpenseCreateDto
    {
        public int Id { get; set; }
    }
}
