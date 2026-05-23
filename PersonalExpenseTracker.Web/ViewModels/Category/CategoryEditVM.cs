using System.ComponentModel.DataAnnotations;

namespace PersonalExpenseTracker.Web.ViewModels.Category
{
    public class CategoryEditVM
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(300)]
        public string? Description { get; set; }
    }
}
