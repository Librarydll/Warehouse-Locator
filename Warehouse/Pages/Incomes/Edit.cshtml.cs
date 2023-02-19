using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.Extensions;
using Warehouse.Web.ViewModels;

namespace Warehouse.Web.Pages.Incomes
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
		public Income? Income { get; set; }
		public async Task OnGetAsync(int id)
		{
			Options = await _mainDbContext.Materials.Where(x=>!x.IsDeleted).Select(f => new SelectListItem
			{
				Text = f.Title,
				Value = f.Id.ToString()
			}).ToListAsync();
			Income = await _mainDbContext.Incomes.AsNoTracking().Include(f=>f.IncomeItems).ThenInclude(f=>f.Material).FirstOrDefaultAsync(x => x.Id == id);
		}

		public async Task<IActionResult> OnPostAsync(int id)
		{
			var incomeItems = Request.Form.MapItemsFromForm();
			var income = await _mainDbContext.Incomes.FindAsync(id);
			foreach (var grouped in incomeItems.GroupBy(x => x.MaterialId))
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
					var existed = await _mainDbContext.IncomeItems.FirstOrDefaultAsync(x => x.Id == item.Id);
					if (existed == null)
					{
						_mainDbContext.IncomeItems.Add(new IncomeItem
						{
							Count = item.Count,
							IncomeId = id,
							MaterialId = grouped.Key,
							Price = item.Price,
						});
						wareHouse.Count += item.Count;
					}
					else
					{
						wareHouse.Count -= existed.Count;
						wareHouse.Count += item.Count;
						existed.Count = item.Count;
						_mainDbContext.Entry(existed).State = EntityState.Modified;
					}

					wareHouse.LastSelfPrice = wareHouse.LastSelfPrice;
					wareHouse.CurrentSelfPrice = item.Price;
					_mainDbContext.Entry(wareHouse).State = EntityState.Modified;
				}
			}
			income.IncomeDate = Income.IncomeDate;
			income.Title = Income.Title;
			_mainDbContext.Entry(income).State = EntityState.Modified;
			await _mainDbContext.SaveChangesAsync();

			return RedirectToPage("Index");
		}

		public async Task<IActionResult> OnPostDeleteAsync(int id)
		{
			var incomeItem = await _mainDbContext.IncomeItems.FindAsync(id);
			if (incomeItem ==null)
			{
				return NotFound();
			}
			_mainDbContext.IncomeItems.Remove(incomeItem);
			var wareHouse = await _mainDbContext.MaterialWarehouses.FirstOrDefaultAsync(x => x.MaterialId == incomeItem.MaterialId);
			wareHouse.Count -= incomeItem.Count;
			//wareHouse.CurrentSelfPrice = wareHouse.LastSelfPrice;
			_mainDbContext.Entry(wareHouse).Property(f => f.Count).IsModified = true;
			//_mainDbContext.Entry(wareHouse).Property(f => f.CurrentSelfPrice).IsModified = true;
			await _mainDbContext.SaveChangesAsync();
			return RedirectToPage(new { id = incomeItem.IncomeId });
		}
	}
}
