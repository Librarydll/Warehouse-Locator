using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;

namespace Warehouse.Web.Pages.Materials
{
    public class DeleteModel : PageModel
    {
        private readonly MainDbContext _dbContext;

        public DeleteModel(MainDbContext mainDbContext)
        {
            _dbContext = mainDbContext;
        }
        [BindProperty]
        public Material? Material { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Material = await _dbContext.Materials.Include(f => f.MaterialCategory).FirstOrDefaultAsync(x => x.Id == id);
            if (Material == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var materail = await _dbContext.Materials.FindAsync(id);
            if (materail == null)
            {
                return NotFound();
            }
            materail.IsDeleted = true;
            _dbContext.Entry(materail).State = EntityState.Modified;
            var warehouse = await _dbContext.MaterialWarehouses.FirstOrDefaultAsync(x => x.MaterialId == id);

            await _dbContext.SaveChangesAsync();
            return Redirect("Index");
        }
    }
}
