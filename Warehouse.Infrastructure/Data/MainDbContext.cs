using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Warehouse.Domain.Models;
using Warehouse.Infrastructure.Helpers;
using Warehouse.Infrastructure.Options;

namespace Warehouse.Infrastructure.Data
{
    public class MainDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly string _connectionString;
        public MainDbContext(DbContextOptions dbContextOptions) :base(dbContextOptions)
        {

        }
        public MainDbContext(MainDbContextOptions options)
        {
            _connectionString = options.ConnectionString ?? ConnectionStrings.LocalMain;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (options.IsConfigured)
                return;

            DbContextHelpers.ConfigureMySql(_connectionString, options);

        }
        public DbSet<AnotherExpense> AnotherExpenses { get; set; }
        public DbSet<Brigade> Brigades { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<IncomeItem> IncomeItems { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialCategory> MaterialCategories { get; set; }
        public DbSet<MaterialExpense> MaterialExpenses { get; set; }
        public DbSet<MaterialWarehouse> MaterialWarehouses { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Outcome> Outcomes { get; set; }
        public DbSet<OutcomeItem> OutcomeItems { get; set; }
        public DbSet<ReadyProduct> ReadyProducts { get; set; }
        public DbSet<ReadyProductWarehouse> ReadyProductWarehouses { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeItem> RecipeItems { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
			foreach (var property in modelBuilder.Model.GetEntityTypes()
													  .SelectMany(t => t.GetProperties())
													  .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
			{

				property.SetPrecision(10);
				property.SetScale(2);
			}

             base.OnModelCreating(modelBuilder);
		}

	}
   
}
