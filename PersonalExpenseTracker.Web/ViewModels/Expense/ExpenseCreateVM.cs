using System.ComponentModel.DataAnnotations;

namespace PersonalExpenseTracker.Web.ViewModels.Expense
{

    public class ExpenseCreateVM
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than 0")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public string? Notes { get; set; }

        public IFormFile? ReceiptFile { get; set; }
    }
}
