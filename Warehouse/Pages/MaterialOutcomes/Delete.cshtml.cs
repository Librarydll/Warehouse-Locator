using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;

namespace Warehouse.Web.Pages.MaterialOutcomes
{
    public class DeleteModel : PageModel
    {
		private readonly MainDbContext _mainDbContext;
		public DeleteModel(MainDbContext mainDbContext)
		{
			_mainDbContext = mainDbContext;
		}
		[BindProperty]
		public Outcome? Outcome { get; set; }
		public async Task OnGetAsync(int id)
		{
			Outcome = await _mainDbContext.Outcomes.AsNoTracking().Include(f => f.OutcomeItems).ThenInclude(f => f.Material).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IActionResult> OnPostAsync(int id)
		{
			var outcome = await _mainDbContext.Outcomes.Include(x => x.OutcomeItems).FirstOrDefaultAsync(x => x.Id == id);
			if (outcome == null)
			{
				return NotFound();
			}

			foreach (var grouped in outcome.OutcomeItems!.GroupBy(i => i.MaterialId))
			{
				var warehouse = await _mainDbContext.MaterialWarehouses.FirstOrDefaultAsync(x => x.MaterialId == grouped.Key);

				foreach (var item in grouped)
				{
					warehouse.Count += item.Count;
				}
				_mainDbContext.Entry(warehouse).State = EntityState.Modified;
			}

			_mainDbContext.Remove(outcome);
			await _mainDbContext.SaveChangesAsync();

			return RedirectToPage("Index");
		}
	}
}
