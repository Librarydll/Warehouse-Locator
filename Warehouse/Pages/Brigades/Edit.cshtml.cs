using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.ViewModels;

namespace Warehouse.Web.Pages.Brigades
{
    public class EditModel : PageModel
    {
        private readonly MainDbContext _dbContext;

        public EditModel(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public BrigadeViewModel? Brigade { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Brigade = await _dbContext.Brigades.AsNoTracking()
                .Select(x=> new BrigadeViewModel
                {
                    Id = x.Id,
                    Title = x.Title,
                })
                .FirstOrDefaultAsync(x => x.Id == id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var brigade = await _dbContext.Brigades.FindAsync(id);

            if (brigade == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Brigade>(
                brigade,
                "Brigade",
                s => s.Title))
            {
                await _dbContext.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
