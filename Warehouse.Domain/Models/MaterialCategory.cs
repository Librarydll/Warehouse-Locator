namespace Warehouse.Domain.Models
{
    public class MaterialCategory : BaseEntity
    {
        public string? Title { get; set; }
        public ICollection<Material>? Materials { get; set; }
    }
}
