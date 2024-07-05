using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;

namespace Entities.Concrete
{
    public class Carts : BaseEntity
    {
        [Key]
        public int CartId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
    }
}
