namespace Warehouse.Domain.Models
{
    public class IncomeItem : BaseEntity
    {
        public decimal Price { get; set; }
        public double Count { get; set; }
        public Material? Material { get; set; }
        public int MaterialId { get; set; }
        public int IncomeId { get; set; }
        public Income Income { get; set; }
    }
}
