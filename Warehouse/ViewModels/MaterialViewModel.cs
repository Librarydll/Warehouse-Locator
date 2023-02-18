

using System.ComponentModel.DataAnnotations;

namespace Warehouse.Web.ViewModels
{
    public class MaterialViewModel
    {
        [Required]
        public string? Title { get; set; }
        public decimal SelfPrice { get; set; }
        public int MaterialCategoryId { get; set; }
        
    }
}
