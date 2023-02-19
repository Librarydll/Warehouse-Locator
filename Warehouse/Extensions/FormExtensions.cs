using Warehouse.Web.ViewModels;

namespace Warehouse.Web.Extensions
{
	public static class FormExtensions
	{
		public static IEnumerable<IItem> MapItemsFromForm(this IFormCollection form)
		{
			for (int i = 0; i < form["MaterialId"].Count; i++)
			{
				if (!int.TryParse(form["MaterialId"][i], out int materialId))
				{
					continue;
				}
				if (!decimal.TryParse(form["Price"][i], out decimal price))
				{
					continue;
				}
				if (!double.TryParse(form["Count"][i], out double count))
				{
					continue;
				}
				if (materialId == 0 || count <= 0 || price < 0)
				{
					continue;
				}
				int id = 0;
				if (form["Id"].Count > 0)
				{
					if (!int.TryParse(form["Id"][i], out id))
					{
					}
				}
				
				yield return new Item
				{
					Count = count,
					MaterialId = materialId,
					Price = price,
					Id = id
				};
			}
		}
	}
}
