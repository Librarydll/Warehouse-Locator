using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;

namespace Warehouse.Web.Pages.MaterialCategories
{
    public class DeleteModel : PageModel
    {
        private readonly MainDbContext _dbContext;
        public DeleteModel(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public MaterialCategory? Category { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Category = await _dbContext.MaterialCategories.AsNoTracking()
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

            _dbContext.MaterialCategories.Remove(category);
            await _dbContext.SaveChangesAsync();

            return Redirect("Index");
        }
    }
}
