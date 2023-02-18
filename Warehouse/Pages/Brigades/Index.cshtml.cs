using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.ViewModels;

namespace Warehouse.Web.Pages.Brigades
{
    public class IndexModel : PageModel
    {
        private readonly MainDbContext _dbContext;

        public IndexModel(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IList<Brigade> Brigades { get; set; }

        public string SearchingString { get; set; }
        public async Task OnGetAsync()
        {
            var query = from q in _dbContext.Brigades
                        select q;

            if (!string.IsNullOrWhiteSpace(SearchingString))
            {
                query = query.Where(x => x.Title.Contains(SearchingString, StringComparison.OrdinalIgnoreCase));
            }

            Brigades = await query.AsNoTracking().ToListAsync();
        }

    }
}
