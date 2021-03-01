using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Model
{
    public class VendorProfession
    {
        [Key]
        public int VendorProfessionId { get; set; }
        [ForeignKey("Vendor")]
        public int VendorId { get; set; }
        [ForeignKey("Profession")]
        public int ProfessionId { get; set; }

        public virtual Vendor Vendor { get; set; }
        public virtual Profession Profession { get; set; }
    }
   

}
