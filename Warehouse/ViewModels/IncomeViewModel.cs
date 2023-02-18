using Microsoft.Build.Framework;

namespace Warehouse.Web.ViewModels
{
    public class IncomeViewModel
    {
        public int Id  { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public DateTime IncomeDate { get; set; } = DateTime.Now;
    }

    public class IncomeItemViewModel
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public double Count { get; set; }
        public decimal Price { get; set; }
    }
}
