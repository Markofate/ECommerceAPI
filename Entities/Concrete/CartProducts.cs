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
        public int CartProductID { get; set; }
        [ForeignKey("CartId")]
        public int CartId { get; set; }
        [ForeignKey("ProductId")] 
        public int ProductID { get; set; }
        public int Quantity { get; set; }
    }
}
