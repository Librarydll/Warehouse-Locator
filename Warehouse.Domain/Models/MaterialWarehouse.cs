using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Domain.Models
{
    public class MaterialWarehouse : BaseEntity
    {
        public double Count { get; set; }
        public int MaterialId { get; set; }
        public Material? Material { get; set; }
        public decimal CurrentSelfPrice { get; set; }
        public decimal LastSelfPrice { get; set; }
    }
}
