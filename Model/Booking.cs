using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Model
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ProblemDescription { get; set; }
        public string ServiceType { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        public bool CompletedStatus { get; set; }
        public bool PaidStatus { get; set; }

        public virtual Customer Customers { get; set; }
        public virtual Vendor Vendors { get; set; }

    }
}
