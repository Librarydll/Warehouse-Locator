using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.ViewModels;

namespace Warehouse.Web.Pages.Materials
{
    public class EditModel : PageModel
    {
        private readonly MainDbContext _dbContext;

        public EditModel(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public int MaterialCategoryId { get; set; }
        [BindProperty]
        public MaterialViewModel Material { get; set; }

        public List<SelectListItem> Options { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Options = await _dbContext.MaterialCategories.Select(c => new SelectListItem
            {
                Text = c.Title,
                Value = c.Id.ToString(),

            }).ToListAsync();

            var material = await _dbContext.Materials.FindAsync(id);

            if (material == null)
            {
                return NotFound();
            }

            MaterialCategoryId = material.MaterialCategoryId;

            Material = new MaterialViewModel
            {
                MaterialCategoryId = material.MaterialCategoryId,
                SelfPrice = material.SelfPrice,
                Title = material.Title,
            };

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var material = await _dbContext.Materials.FindAsync(id);

            if (material == null)
            {
                return NotFound();
            }
            material.MaterialCategoryId = MaterialCategoryId;
            if (await TryUpdateModelAsync(material))
            {
                await _dbContext.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            return Page();
        }
    }
}
