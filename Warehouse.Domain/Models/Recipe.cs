namespace Warehouse.Domain.Models
{
    public class Recipe : BaseEntity
    {
        public ReadyProduct? ReadyProduct { get; set; }
        public int ReadyProductId { get; set; }
        public ICollection<RecipeItem>? RecipeItems { get; set; }
    }
}
