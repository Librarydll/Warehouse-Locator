using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.Domain.Models
{
    public class Outcome : BaseEntity
    {
        public DateTime OutcomeDate { get; set; }
        public string? Title { get; set; }

        public ICollection<OutcomeItem>? OutcomeItems { get; set; }
        public string UserId { get; set; }
        public ApplicationUser? User { get; set; }
    }
}
