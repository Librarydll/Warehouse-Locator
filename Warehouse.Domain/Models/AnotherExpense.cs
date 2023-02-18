namespace Warehouse.Domain.Models
{
    public class AnotherExpense : BaseEntity
    {
        public decimal Price { get; set; }
        public string? Title { get; set; }
        /// <summary>
        /// Доп
        /// </summary>
        public bool IsAdditional { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
