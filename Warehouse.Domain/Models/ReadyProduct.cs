namespace Warehouse.Domain.Models
{
    public class ReadyProduct : BaseEntity
    {
        public bool IsDeleted { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }

    }
}
