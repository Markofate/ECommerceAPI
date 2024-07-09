using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Orders : BaseEntity
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public DateTime? Date { get; set; }
        public string? Status { get; set; }
        public decimal? TotalAmount { get; set; }
        public string? Currency { get; set; }
    }
}
