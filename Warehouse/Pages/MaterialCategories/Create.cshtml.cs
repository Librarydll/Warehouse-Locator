using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.ViewModels;

namespace Warehouse.Web.Pages.MaterialCategories
{
    public class CreateModel : PageModel
    {
        private readonly MainDbContext _dbContext;

        public CreateModel(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public MaterialCategoryViewModel Category { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var entry = _dbContext.MaterialCategories.Add(new MaterialCategory());
            entry.CurrentValues.SetValues(Category);
            await _dbContext.SaveChangesAsync();

            return Redirect("Index");
        }
    }
}
