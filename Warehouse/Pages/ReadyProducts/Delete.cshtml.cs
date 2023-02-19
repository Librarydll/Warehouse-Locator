using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;

namespace Warehouse.Web.Pages.ReadyProducts
{
    public class DeleteModel : PageModel
    {
        private readonly MainDbContext _dbContext;

        public DeleteModel(MainDbContext mainDbContext)
        {
            _dbContext = mainDbContext;
        }
        [BindProperty]
        public ReadyProduct? ReadyProduct { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            ReadyProduct = await _dbContext.ReadyProducts.FindAsync(id);
            if (ReadyProduct == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var readyProduct = await _dbContext.ReadyProducts.FindAsync(id);
            if (readyProduct == null)
            {
                return NotFound();
            }
            readyProduct.IsDeleted = true;
            _dbContext.Entry(readyProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return Redirect("Index");
        }
    }
}
