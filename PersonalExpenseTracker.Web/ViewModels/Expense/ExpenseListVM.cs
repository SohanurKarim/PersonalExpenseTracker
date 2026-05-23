namespace PersonalExpenseTracker.Web.ViewModels.Expense
{
    public class ExpenseListVM
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string CategoryName { get; set; } = string.Empty;

        public bool HasReceipt { get; set; }
    }
}
