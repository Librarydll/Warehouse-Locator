namespace Warehouse.Domain.Models
{
    public class Material : BaseEntity
    {
        public bool IsDeleted { get; set; }
        public string? Title { get; set; }
        public int MaterialCategoryId { get; set; }
        public MaterialCategory? MaterialCategory { get; set; }
    }
}
