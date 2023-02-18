using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Data;
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
            List<IncomeItem> incomeItemViewModels = new List<IncomeItem>();
            for (int i = 0; i < Request.Form["MaterialId"].Count; i++)
            {
                if (!int.TryParse(Request.Form["MaterialId"][i],out int materialId))
                {
                    continue;
                }
				if (!decimal.TryParse(Request.Form["Price"][i], out decimal price))
				{
					continue;
				}
				if (!double.TryParse(Request.Form["Count"][i], out double count))
				{
					continue;
				}

				if (materialId == 0 || count <= 0 || price < 0)
                {
                    continue;
                }
                incomeItemViewModels.Add(new IncomeItem
				{
                    Count = count,
                    MaterialId = materialId,
                    Price = price,
                });
            }
            var applicationUser = await _userManager.GetUserAsync(HttpContext.User);

            _mainDbContext.Incomes.Add(new Income
			{
                IncomeDate = Income.IncomeDate,
                Title = Income.Title,
                UserId = applicationUser!.Id,
                IncomeItems = incomeItemViewModels
			});

            await _mainDbContext.SaveChangesAsync();
            return Page();
        }
    }
}
