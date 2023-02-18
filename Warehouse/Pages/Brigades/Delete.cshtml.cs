using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;

namespace Warehouse.Web.Pages.Brigades
{
    public class DeleteModel : PageModel
    {
        private readonly MainDbContext _dbContext;
        public DeleteModel(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public Brigade? Brigade { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Brigade = await _dbContext.Brigades.AsNoTracking()
                                               .FirstOrDefaultAsync(x => x.Id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {

            var brigade = await _dbContext.Brigades.FindAsync(id);

            if (brigade == null)
            {
                return NotFound();
            }

             _dbContext.Brigades.Remove(brigade);
            await _dbContext.SaveChangesAsync();

            return Redirect("Index");
        }
    }
}
