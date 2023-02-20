using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.Dtos;
using Warehouse.Web.Models;

namespace Warehouse.Web.Pages.MaterialsWarehouse
{
	public class IndexModel : PageModel
	{
		private readonly MainDbContext _dbContext;

		public IndexModel(MainDbContext dbContext,IConfiguration configuration)
		{
			_dbContext = dbContext;
			Configuration = configuration;
		}

		[BindProperty]
		public PaginatedList<MaterialReadyProductDto> Warehouses { get; set; }
		public IConfiguration Configuration { get; }

		public async Task<IActionResult> OnGetAsync(string
			searchingString, int? pageIndex, int categoryId = 0)
		{
			var warehouses = from m in _dbContext.MaterialWarehouses
										 select m;
			if (!string.IsNullOrWhiteSpace(searchingString))
			{
				warehouses = warehouses.Where(x => x.Material.Title.Contains(searchingString, StringComparison.OrdinalIgnoreCase));
			}
			if (categoryId != 0)
			{
				warehouses = warehouses.Where(x => x.Material.MaterialCategoryId == categoryId);
			}

			var query = warehouses.Select(x => new MaterialReadyProductDto
			{
				Count = x.Count,
				MaterialId = x.MaterialId,
				MaterialTitle = x.Material.Title,
				Price = x.CurrentSelfPrice,
				CategoryTitle = x.Material.MaterialCategory.Title
			});

			var pageSize = Configuration.GetValue<int>("PageSize");
			Warehouses = await PaginatedList<MaterialReadyProductDto>.CreateAsync(query.OrderByDescending(f => f.MaterialTitle).AsNoTracking(), pageIndex ?? 1, pageSize);

			return Page();
		}
	}
}
