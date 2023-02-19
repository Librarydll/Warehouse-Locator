using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.Extensions;
using Warehouse.Web.ViewModels;

namespace Warehouse.Web.Pages.MaterialOutcomes
{
    [Authorize]
    public class CreateModel : PageModel
    {
		private readonly MainDbContext _mainDbContext;
		private readonly UserManager<ApplicationUser> _userManager;

		public CreateModel(MainDbContext mainDbContext,
			UserManager<ApplicationUser> userManager)
		{
			_mainDbContext = mainDbContext;
			_userManager = userManager;
		}
		public List<SelectListItem> Options { get; set; }
		[BindProperty]
		public OutcomeMaterialViewModel Outcome { get; set; }

		public async Task OnGetAsync()
		{
			Options = await _mainDbContext.Materials.Where(x=>!x.IsDeleted).Select(f => new SelectListItem
			{
				Text = f.Title,
				Value = f.Id.ToString()
			}).ToListAsync();

		}

		public async Task<IActionResult> OnPostAsync()
		{
			var incomeItemViewModels = Request.Form.MapItemsFromForm();
			var outcome = new Outcome()
			{
				OutcomeDate = Outcome.OutcomeDate,
				Title = Outcome.Title,
				OutcomeItems = new List<OutcomeItem>()
			};
			foreach (var grouped in incomeItemViewModels.GroupBy(x => x.MaterialId))
			{
				var wareHouse = await _mainDbContext.MaterialWarehouses.FirstOrDefaultAsync(x => x.MaterialId == grouped.Key);
				var price = grouped.FirstOrDefault().Price;
				var count = grouped.Sum(x => x.Count);
				if (wareHouse == null)
				{
					wareHouse = new Domain.Models.MaterialWarehouse()
					{
						CurrentSelfPrice = price,
						MaterialId = grouped.Key,
						LastSelfPrice = price,
						Count = count * (-1)
					};
					_mainDbContext.MaterialWarehouses.Add(wareHouse);
				}
				else
				{
					wareHouse.Count -= count;
					_mainDbContext.Entry(wareHouse).State = EntityState.Modified;
				}
				outcome.OutcomeItems.Add(new OutcomeItem
				{
					Count = count,
					MaterialId = grouped.Key,
					Price = grouped.Key,
				});
			}

			var applicationUser = await _userManager.GetUserAsync(HttpContext.User);
			outcome.UserId = applicationUser.Id;
			_mainDbContext.Outcomes.Add(outcome);

			await _mainDbContext.SaveChangesAsync();
			return Redirect("Index");
		}
	}
}
