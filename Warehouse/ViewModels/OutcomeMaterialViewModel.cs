using System.ComponentModel.DataAnnotations;

namespace Warehouse.Web.ViewModels
{
    public class OutcomeMaterialViewModel
    {
        public int Id { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public DateTime OutcomeDate { get; set; } = DateTime.Now;
    }
    public class OutcomeItemMaterialViewModel : IItem
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public double Count { get; set; }
        public decimal Price { get; set; }
    }
}
