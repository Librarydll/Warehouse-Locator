namespace Warehouse.Domain.Models
{
    public class Income : BaseEntity
    {
        public DateTime IncomeDate { get; set; }
        public string? Title { get; set; }
        public ICollection<IncomeItem>? IncomeItems { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
