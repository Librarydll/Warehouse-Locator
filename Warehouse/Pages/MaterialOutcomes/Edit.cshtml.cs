using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.Extensions;

namespace Warehouse.Web.Pages.MaterialOutcomes
{
    public class EditModel : PageModel
    {
		private readonly MainDbContext _mainDbContext;
		public EditModel(MainDbContext mainDbContext)
		{
			_mainDbContext = mainDbContext;
		}
		public List<SelectListItem> Options { get; set; }
		[BindProperty]
		public Outcome? Outcome { get; set; }
		public async Task OnGetAsync(int id)
		{
			Options = await _mainDbContext.Materials.Where(x => !x.IsDeleted).Select(f => new SelectListItem
			{
				Text = f.Title,
				Value = f.Id.ToString()
			}).ToListAsync();
			Outcome = await _mainDbContext.Outcomes.AsNoTracking().Include(f => f.OutcomeItems).ThenInclude(f => f.Material).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IActionResult> OnPostAsync(int id)
		{
			var outcomeItems = Request.Form.MapItemsFromForm();
			var outcome = await _mainDbContext.Outcomes.FindAsync(id);
			foreach (var grouped in outcomeItems.GroupBy(x => x.MaterialId))
			{
				var wareHouse = await _mainDbContext.MaterialWarehouses.FirstOrDefaultAsync(x => x.MaterialId == grouped.Key);
				if (wareHouse == null)
				{
					wareHouse = new Domain.Models.MaterialWarehouse()
					{
						CurrentSelfPrice = grouped.FirstOrDefault().Price,
						MaterialId = grouped.Key,
						LastSelfPrice = grouped.FirstOrDefault().Price,
					};
					_mainDbContext.MaterialWarehouses.Add(wareHouse);
					await _mainDbContext.SaveChangesAsync();
				}
				foreach (var item in grouped)
				{
					var existed = await _mainDbContext.OutcomeItems.FirstOrDefaultAsync(x => x.Id == item.Id);
					if (existed == null)
					{
						_mainDbContext.OutcomeItems.Add(new OutcomeItem
						{
							Count = item.Count,
							OutcomeId = id,
							MaterialId = grouped.Key,
							Price = item.Price,
						});
						wareHouse.Count -= item.Count;
					}
					else
					{
						wareHouse.Count += existed.Count;
						wareHouse.Count -= item.Count;
						existed.Count = item.Count;
						_mainDbContext.Entry(existed).State = EntityState.Modified;
					}

					wareHouse.LastSelfPrice = wareHouse.LastSelfPrice;
					wareHouse.CurrentSelfPrice = item.Price;
					_mainDbContext.Entry(wareHouse).State = EntityState.Modified;
				}
			}
			outcome.OutcomeDate = Outcome.OutcomeDate;
			outcome.Title = Outcome.Title;
			_mainDbContext.Entry(outcome).State = EntityState.Modified;
			await _mainDbContext.SaveChangesAsync();

			return RedirectToPage("Index");
		}

		public async Task<IActionResult> OnPostDeleteAsync(int id)
		{
			var outcomeItem = await _mainDbContext.OutcomeItems.FindAsync(id);
			if (outcomeItem == null)
			{
				return NotFound();
			}
			_mainDbContext.OutcomeItems.Remove(outcomeItem);
			var wareHouse = await _mainDbContext.MaterialWarehouses.FirstOrDefaultAsync(x => x.MaterialId == outcomeItem.MaterialId);
			wareHouse.Count += outcomeItem.Count;
			_mainDbContext.Entry(wareHouse).Property(f => f.Count).IsModified = true;
			await _mainDbContext.SaveChangesAsync();
			return RedirectToPage(new { id = outcomeItem.OutcomeId });
		}
	}
}
