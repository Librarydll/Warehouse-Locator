using System.ComponentModel.DataAnnotations;

namespace Warehouse.Web.ViewModels
{
    public class BrigadeViewModel
    {
        [Required]
        [Display(Name = "Brigade name")]
        public string? Title { get; set; }
        public int Id { get; set; }
    }
}
