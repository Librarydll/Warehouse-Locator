namespace Warehouse.Domain.Models
{
    public class BaseEntity
    {
        public DateTime LastUpdatedAt { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Id { get; set; }
    }
}
