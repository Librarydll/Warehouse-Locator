namespace Warehouse.Web.ViewModels
{
    public interface IItem
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public double Count { get; set; }
        public decimal Price { get; set; }
    }

    public class Item : IItem
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public double Count { get; set; }
        public decimal Price { get; set; }
    }
}
