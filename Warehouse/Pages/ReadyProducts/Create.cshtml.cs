using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.ViewModels;

namespace Warehouse.Web.Pages.ReadyProducts
{
    public class CreateModel : PageModel
    {
        private readonly MainDbContext _dbContext;

        public CreateModel(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public ReadyProductViewModel ReadyProduct { get; set; }

        public IActionResult OnGetAsync()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _dbContext.ReadyProducts.Add(new ReadyProduct());
            entry.CurrentValues.SetValues(ReadyProduct);
            await _dbContext.SaveChangesAsync();

            return Redirect("Index");
        }
    }
}
