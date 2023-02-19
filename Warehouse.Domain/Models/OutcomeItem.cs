namespace Warehouse.Domain.Models
{
    public class OutcomeItem : BaseEntity
    {
        public decimal Price { get; set; }
        public double Count { get; set; }
        public Material? Material { get; set; }
        public int MaterialId { get; set; }
        public int OutcomeId { get; set; }
        public Outcome Outcome { get; set; }
    }
}
