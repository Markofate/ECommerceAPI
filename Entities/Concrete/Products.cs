using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Products : BaseEntity
    {
        [Key]
        public int  ProductId { get; set; }
        public string Product { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? Stock { get; set; }
        public string? Currency { get; set; }
        
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public int Sales { get; set; }
    }   
}
