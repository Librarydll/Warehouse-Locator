using System.ComponentModel.DataAnnotations;

namespace Warehouse.Web.ViewModels
{
    public class MaterialCategoryViewModel
    {
        [Required]
        [Display(Name = "Category name")]
        public string? Title { get; set; }
        public int Id { get; set; }
    }
}
