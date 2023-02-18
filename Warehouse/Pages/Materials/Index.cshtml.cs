using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.Models;

namespace Warehouse.Web.Pages.Materials
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
        public PaginatedList<Material> Materials { get; set; }
        public IConfiguration Configuration { get; }

        public async Task<IActionResult> OnGetAsync(string searchingString,int categoryId,int? pageIndex)
        {
            var materials = from m in _dbContext.Materials
                            select m;
            if (!string.IsNullOrWhiteSpace(searchingString))
            {
                materials = materials.Where(x => x.Title.Contains(searchingString, StringComparison.OrdinalIgnoreCase));
            }

            if (categoryId != 0)
            {
                materials = materials.Where(x => x.MaterialCategoryId == categoryId);
            }
            materials = materials.Include(f => f.MaterialCategory);
            var pageSize = Configuration.GetValue<int>("PageSize");
            Materials = await PaginatedList<Material>.CreateAsync(materials.OrderBy(f => f.Title).AsNoTracking(), pageIndex ?? 1, pageSize);

            return Page();
        }
    }
}
