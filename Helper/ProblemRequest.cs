using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Helper
{
    public class ProblemRequest
    {
        public int CustomerId { get; set; }
        public string Description { get; set; }
        public string ProblemImage { get; set; }
        public DateTime AddedDate { get; set; }
        public bool Status { get; set; }

    }
}
