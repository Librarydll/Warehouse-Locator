using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Domain.Models
{
    public class ReadyProductWarehouse : BaseEntity
    {
        public string? BatchNumber { get; set; }
        public double Count { get; set; }
        public int ReadyProductId { get; set; }
        public ReadyProduct? ReadyProduct { get; set; }
    }
}
