namespace Warehouse.Domain.Models
{
    public class MaterialExpense : BaseEntity
    {
        public double Count { get; set; }
        public decimal Price { get; set; }
        public Material? Material { get; set; }
        public int MaterialId { get; set; }
        /// <summary>
        /// Доп
        /// </summary>
        public bool IsAdditional { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
