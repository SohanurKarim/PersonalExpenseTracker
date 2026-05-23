namespace PersonalExpenseTracker.Web.ViewModels.Summary
{

    public class RecentExpenseVM
    {
        public string Title { get; set; } = string.Empty;

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public string CategoryName { get; set; } = string.Empty;
    }
}
