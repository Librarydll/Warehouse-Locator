using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.ViewModels;

namespace Warehouse.Web.Pages.ReadyProducts
{
    public class EditModel : PageModel
    {
        private readonly MainDbContext _dbContext;
        public EditModel(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public ReadyProductViewModel ReadyProduct { get; set; }


        public async Task<IActionResult> OnGetAsync(int id)
        {
         
            var readyProduct = await _dbContext.ReadyProducts.FindAsync(id);

            if (readyProduct == null)
            {
                return NotFound();
            }

            ReadyProduct = new ReadyProductViewModel
            {
                Id = readyProduct.Id,
                Title = readyProduct.Title,
                Description = readyProduct.Description
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var readyProduct = await _dbContext.ReadyProducts.FindAsync(id);

            if (readyProduct == null)
            {
                return NotFound();
            }
            if (await TryUpdateModelAsync(readyProduct))
            {
                await _dbContext.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
