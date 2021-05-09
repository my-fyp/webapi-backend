using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Model
{
    public class Profession
    {
        public int ProfessionId { get; set; }
        public string ProfessionName { get; set; }
        public string ServiceIcon { get; set; }
        public string  Slug { get; set; }
        public virtual ICollection<VendorProfession> VendorProfessions { get; set; }
    }
}
