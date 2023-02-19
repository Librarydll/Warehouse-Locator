using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.Models;

namespace Warehouse.Web.Pages.ReadyProducts
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
        public PaginatedList<ReadyProduct> ReadyProducts { get; set; }
        public IConfiguration Configuration { get; }

        public async Task<IActionResult> OnGetAsync(string searchingString, int? pageIndex)
        {
            var readyProducts = from m in _dbContext.ReadyProducts
                                where !m.IsDeleted
                                select m;
            if (!string.IsNullOrWhiteSpace(searchingString))
            {
                readyProducts = readyProducts.Where(x => x.Title.Contains(searchingString, StringComparison.OrdinalIgnoreCase));
            }

            var pageSize = Configuration.GetValue<int>("PageSize");
            ReadyProducts = await PaginatedList<ReadyProduct>.CreateAsync(readyProducts.OrderBy(f => f.Title).AsNoTracking(), pageIndex ?? 1, pageSize);

            return Page();
        }
    }
}
