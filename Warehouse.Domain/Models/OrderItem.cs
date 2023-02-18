using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Domain.Models
{
    public class OrderItem : BaseEntity
    {
        public decimal Price { get; set; }
        public double UsingCount { get; set; }
        public double ReturnCount { get; set; }
        public double DefectCount { get; set; }
        public Material? Material { get; set; }
        public int MaterialId { get; set; }
        public int OrderId { get; set; }
        public Order? Order { get; set; }
    }
}
