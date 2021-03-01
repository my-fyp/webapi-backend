using Home_Sewa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Service
{
    public class VendorServices
    {
        private readonly HomeSewaDbContext _dbContext;
        public VendorServices(HomeSewaDbContext dbContext)
        {
            _dbContext = dbContext;

        }
        internal object GetAllVendors()
        {
            return _dbContext.Vendors;
        }
    }
}
