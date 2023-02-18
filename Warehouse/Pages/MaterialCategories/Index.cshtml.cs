using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.Models;

namespace Warehouse.Web.Pages.MaterialCategories
{
    public class IndexModel : PageModel
    {
        private readonly MainDbContext _dbContext;
        private readonly IConfiguration Configuration;
        public IndexModel(MainDbContext mainDbContext, IConfiguration configuration)
        {
            _dbContext = mainDbContext;
            Configuration = configuration;
        }
        [BindProperty]
        public PaginatedList<MaterialCategory> Categories { get; set; }
        public async Task<IActionResult> OnGetAsync(string searchingString, int? pageIndex)
        {
            var query = from q in _dbContext.MaterialCategories
                       select q;

            if (!string.IsNullOrWhiteSpace(searchingString))
            {
                query = query.Where(x => x.Title.Contains(searchingString, StringComparison.OrdinalIgnoreCase));
            }
            var pageSize = Configuration.GetValue<int>("PageSize");

            Categories = await PaginatedList<MaterialCategory>.CreateAsync(query.OrderBy(f => f.Title).AsNoTracking(), pageIndex ?? 1, pageSize);

            return Page();
        }
    }
}
