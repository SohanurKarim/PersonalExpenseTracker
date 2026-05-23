namespace PersonalExpenseTracker.Web.ViewModels.Expense
{
    public class ExpenseEditVM : ExpenseCreateVM
    {
        public int Id { get; set; }

        public string? ExistingReceiptFileName { get; set; }
    }
}
