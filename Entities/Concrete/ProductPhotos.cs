using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class ProductPhotos : BaseEntity
    {
        [Key]
        public int PhotoId { get; set; }
        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public string PhotoUrl{ get; set; }
    }
}
