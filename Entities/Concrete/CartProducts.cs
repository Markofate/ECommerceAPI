using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class CartProducts : BaseEntity
    {
        [Key]
        public int CartProductId { get; set; }
        [ForeignKey("CartId")]
        public int CartId { get; set; }
        [ForeignKey("ProductId")] 
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
