using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Domain.Models
{
    public class Order : BaseEntity
    {
        public string? BatchNumber { get; set; }
        public decimal SelfPrice { get; set; }
        public int ReadyProductId { get; set; }
        public ReadyProduct? ReadyProduct { get; set; }
        public double Count { get; set; }
        public ICollection<Brigade>? Brigades { get; set; }
        public ICollection<MaterialExpense>? MaterialExpenses { get; set; }
        public ICollection<AnotherExpense>? AnotherExpenses { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
