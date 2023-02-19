namespace Warehouse.Web.Dtos
{
	public class MaterialReadyProductDto
	{
		public decimal Price { get; set; }
		public double Count { get; set; }
		public string? MaterialTitle { get; set; }
		public int MaterialId { get; set; }
		public string CategoryTitle { get; set; }
	}
}
