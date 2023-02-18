using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;

namespace Warehouse.Web.Pages.Incomes
{
    public class DeleteModel : PageModel
    {
		private readonly MainDbContext _mainDbContext;

		public DeleteModel(MainDbContext mainDbContext)
		{
			_mainDbContext = mainDbContext;
		}
		[BindProperty]
		public Income? Income { get; set; }
		public async Task OnGetAsync(int id)
		{
			Income = await _mainDbContext.Incomes.AsNoTracking().Include(f => f.IncomeItems).ThenInclude(f => f.Material).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IActionResult> OnPostAsync(int id)
		{
			var income = await _mainDbContext.Incomes.Include(x=>x.IncomeItems).FirstOrDefaultAsync(x=>x.Id == id);
			if (income == null)
			{
				return NotFound();
			}

			foreach (var item in income.IncomeItems!)
			{
				var warehouse = await _mainDbContext.MaterialWarehouses.FirstOrDefaultAsync(x => x.MaterialId == item.MaterialId);

				warehouse.Count -= item.Count;
				warehouse.CurrentSelfPrice = warehouse.LastSelfPrice;

				_mainDbContext.Entry(warehouse).State = EntityState.Modified;
			}

			_mainDbContext.Remove(income);
			await _mainDbContext.SaveChangesAsync();

			return RedirectToPage("Index");
		}
	}
}
