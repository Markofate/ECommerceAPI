using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Conrete
{
    public class Orders
    {
        public int OrderId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; }
        public decimal TotalAmount { get; set; }
        public string Currency{ get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool isActive { get; set; } = true;
        public bool isDeleted { get; set; } = false;
    }
}
