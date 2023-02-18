using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.Models;

namespace Warehouse.Web.Pages.Incomes
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
        public PaginatedList<Income> Incomes { get; set; }
        public IConfiguration Configuration { get; }

        public async Task<IActionResult> OnGetAsync(string searchingString, int? pageIndex)
        {
			IQueryable<Income> incomes = from m in _dbContext.Incomes
                            select m;
            if (!string.IsNullOrWhiteSpace(searchingString))
            {
				incomes = incomes.Where(x => x.Title.Contains(searchingString, StringComparison.OrdinalIgnoreCase));
            }
            incomes = incomes.Include(f => f.User);
			var pageSize = Configuration.GetValue<int>("PageSize");
            Incomes = await PaginatedList<Income>.CreateAsync(incomes.OrderByDescending(f => f.IncomeDate).AsNoTracking(), pageIndex ?? 1, pageSize);

            return Page();
        }
    }
}
