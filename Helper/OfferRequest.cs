using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Helper
{
    public class OfferRequest
    {
        public int VendorId { get; set; }
        public DateTime ValidDate { get; set; }
        public string OfferImage { get; set; }
        public string OfferDescription { get; set; }
    }

}

