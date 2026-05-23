using System.ComponentModel.DataAnnotations;

namespace PersonalExpenseTracker.Web.ViewModels.Category
{
    public class CategoryCreateVM
    {
        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(300)]
        public string? Description { get; set; }
    }
}
