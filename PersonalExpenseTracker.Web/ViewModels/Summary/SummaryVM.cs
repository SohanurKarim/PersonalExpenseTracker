namespace PersonalExpenseTracker.Web.ViewModels.Summary
{
    public class SummaryVM
    {
        public decimal CurrentMonthTotal { get; set; }

        public List<CategoryTotalVM> CategoryTotals { get; set; }
            = new();

        public List<RecentExpenseVM> RecentExpenses { get; set; }
            = new();
    }
}
