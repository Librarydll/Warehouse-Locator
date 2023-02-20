using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.Dtos;
using Warehouse.Web.Models;

namespace Warehouse.Web.Pages.ReadyProductsWarehouse
{
    public class IndexModel : PageModel
    {
        private readonly MainDbContext _dbContext;

        public IndexModel(MainDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            Configuration = configuration;
        }

        [BindProperty]
        public PaginatedList<ReadyProductWarehouseDto> Warehouses { get; set; }
        public IConfiguration Configuration { get; }

        public async Task<IActionResult> OnGetAsync(string
            searchingString, int? pageIndex)
        {
            var warehouses = from m in _dbContext.ReadyProductWarehouses
                             select m;
            if (!string.IsNullOrWhiteSpace(searchingString))
            {
                warehouses = warehouses.Where(x => x.ReadyProduct.Title.Contains(searchingString, StringComparison.OrdinalIgnoreCase));
            }


            var query = warehouses.Select(x => new ReadyProductWarehouseDto
            {
                Count = x.Count,
                Id = x.Id,
                ReadyProductId = x.ReadyProductId,
                ReadyProductTitle = x.ReadyProduct.Title,
                BatchNumber = x.BatchNumber
            });

            var pageSize = Configuration.GetValue<int>("PageSize");
            Warehouses = await PaginatedList<ReadyProductWarehouseDto>.CreateAsync(query.OrderByDescending(f => f.ReadyProductTitle).AsNoTracking(), pageIndex ?? 1, pageSize);

            return Page();
        }
    }
}
