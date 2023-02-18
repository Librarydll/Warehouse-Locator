namespace Warehouse.Domain.Models
{
    public class RecipeItem : BaseEntity
    {
        public Material? Material { get; set; }
        public int MaterialId { get; set; }
        public double Count { get; set; }
        public int RecipeId { get; set; }
        public Recipe? Recipe { get; set; }
    }
}
