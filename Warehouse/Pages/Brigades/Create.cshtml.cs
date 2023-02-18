using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.ViewModels;

namespace Warehouse.Web.Pages.Brigades
{
    public class CreateModel : PageModel
    {
        private readonly MainDbContext _dbContext;

        public CreateModel(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public BrigadeViewModel Brigade { get; set; }
        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var entry = _dbContext.Brigades.Add(new Brigade());
            entry.CurrentValues.SetValues(Brigade);
            await _dbContext.SaveChangesAsync();
            
            return Redirect("Index");
        }
    }
}
