using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.Models;

namespace Warehouse.Web.Pages.MaterialOutcomes
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
        public PaginatedList<Outcome> Outcomes { get; set; }
        public IConfiguration Configuration { get; }

        public async Task<IActionResult> OnGetAsync(string searchingString, int? pageIndex)
        {
            var outcomes = from m in _dbContext.Outcomes
                                         select m;
            if (!string.IsNullOrWhiteSpace(searchingString))
            {
                outcomes = outcomes.Where(x => x.Title.Contains(searchingString, StringComparison.OrdinalIgnoreCase));
            }
            outcomes = outcomes.Include(f => f.User);
            var pageSize = Configuration.GetValue<int>("PageSize");
            Outcomes = await PaginatedList<Outcome>.CreateAsync(outcomes.OrderByDescending(f => f.OutcomeDate).AsNoTracking(), pageIndex ?? 1, pageSize);

            return Page();
        }
    }
}
