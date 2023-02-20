namespace Warehouse.Web.Dtos
{
    public class ReadyProductWarehouseDto
    {
        public int Id { get; set; }
        public double Count { get; set; }
        public string? ReadyProductTitle { get; set; }
        public int ReadyProductId { get; set; }
        public string? BatchNumber { get; set; }
    }
}
