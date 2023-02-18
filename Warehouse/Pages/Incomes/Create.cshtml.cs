using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
using Warehouse.Web.Extensions;
using Warehouse.Web.ViewModels;

namespace Warehouse.Web.Pages.Incomes
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
        public IncomeViewModel Income { get; set; }
       
        public async Task OnGetAsync()
        {
            Options = await _mainDbContext.Materials.Select(f => new SelectListItem
            {
                Text = f.Title,
                Value = f.Id.ToString()
            }).ToListAsync();

        }

        public async Task<IActionResult> OnPostAsync()
        {
            var incomeItemViewModels = Request.Form.MapIncomeItemFromForm();
            var income = new Income()
            {
                IncomeDate = Income.IncomeDate,
                Title = Income.Title,
                IncomeItems = new List<IncomeItem>()
            };
            foreach (var grouped in incomeItemViewModels.GroupBy(x=>x.MaterialId))
            {
				var wareHouse = await _mainDbContext.MaterialWarehouses.FirstOrDefaultAsync(x => x.MaterialId == grouped.Key);
                var price = grouped.FirstOrDefault().Price;
                var count = grouped.Sum(x => x.Count);
				if (wareHouse == null)
				{
					wareHouse = new MaterialWarehouse()
					{
						CurrentSelfPrice = price,
						MaterialId = grouped.Key,
						LastSelfPrice = price,
						Count = count
					};
					_mainDbContext.MaterialWarehouses.Add(wareHouse);
				}
				else
				{
					wareHouse.Count += count;
					_mainDbContext.Entry(wareHouse).State = EntityState.Modified;
				}
				income.IncomeItems.Add(new IncomeItem
				{
					Count = count,
					MaterialId = grouped.Key,
					Price = grouped.Key,
				});
			}
			
            var applicationUser = await _userManager.GetUserAsync(HttpContext.User);
            income.UserId = applicationUser.Id;
			_mainDbContext.Incomes.Add(income);

            await _mainDbContext.SaveChangesAsync();
            return Redirect("Index");
        }
    }
}
