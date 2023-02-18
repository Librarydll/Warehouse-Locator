using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.ViewModels;

namespace Warehouse.Web.Pages.Materials
{
    public class CreateModel : PageModel
    {
        private readonly MainDbContext _dbContext;

        public CreateModel(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public int MaterialCategoryId { get; set; }
        [BindProperty]
        public MaterialViewModel Material { get; set; }

        public List<SelectListItem> Options { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            Options = await _dbContext.MaterialCategories.Select(c => new SelectListItem
            {
                Text = c.Title,
                Value = c.Id.ToString(),

            }).ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || MaterialCategoryId <= 0)
            {
                return Page();
            }
           
            Material.MaterialCategoryId = MaterialCategoryId;
            var entry = _dbContext.Materials.Add(new Material());
            entry.CurrentValues.SetValues(Material);
            await _dbContext.SaveChangesAsync();

            return Redirect("Index");
        }
    }
}
