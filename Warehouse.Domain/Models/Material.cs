namespace Warehouse.Domain.Models
{
    public class Material : BaseEntity
    {
        public string? Title { get; set; }
        public decimal SelfPrice { get; set; }

        public int MaterialCategoryId { get; set; }
        public MaterialCategory? MaterialCategory { get; set; }
    }
}
