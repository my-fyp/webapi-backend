using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Helper
{
    public class BookingRequest
    {
        public int CustomerId { get; set; }
        public int VendorId { get; set; }
        public DateTime ServiceDate { get; set; }
        public string ProblemDescription { get; set; }
        public string ServiceAddress { get; set; }
        public string ServiceType { get; set; }
        public double TotalPrice { get; set; }
        public double Discount { get; set; }
        public bool CompletedStatus { get; set; }
        public bool PaidStatus { get; set; }
        public string BookedBy { get; set; }
    }
}
