using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalExpenseTracker.Service.DTOs
{
    public class ServiceResult
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;

        public static ServiceResult Ok(string msg = "") =>
            new() { Success = true, Message = msg };

        public static ServiceResult Fail(string msg) =>
            new() { Success = false, Message = msg };
    }
}
