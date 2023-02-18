using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.ViewModels;

namespace Warehouse.Web.Pages.MaterialCategories
{
    public class EditModel : PageModel
    {
        private readonly MainDbContext _dbContext;

        public EditModel(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public MaterialCategoryViewModel? Category { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _dbContext.MaterialCategories.AsNoTracking()
                .Select(x=> new MaterialCategoryViewModel
                {
                    Title= x.Title,
                    Id = x.Id,
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
            var category = await _dbContext.MaterialCategories.FindAsync(id);

            if (category == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync(
                category,
                "Category",
                s => s.Title))
            {
                await _dbContext.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}   
