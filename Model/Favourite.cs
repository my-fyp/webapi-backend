using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Model
{
    public class Favourite
    {
        [Key]
        public int FavouriteId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Vendor Vendor { get; set; }

    }
}
