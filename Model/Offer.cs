using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Model
{
    public class Offer
    {
        [Key]
        public int OfferId { get; set; }
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }
        public DateTime ValidDate { get; set; }
        public string OfferImage { get; set; }

        public virtual Vendor Vendor { get; set; }
    }

}



