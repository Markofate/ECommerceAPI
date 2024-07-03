using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Conrete
{
    public class Products 
    {
        public int ProductId { get; set; }
        public string Product { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Currency { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy{ get; set; }
        public string DeletedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool isActive { get; set; } = true;
        public bool isDeleted { get; set; } = false;
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; } 
    }   
}
