using Home_Sewa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Service
{
    public class OffersService
    {
        private readonly HomeSewaDbContext _dbContext;
        public OffersService(HomeSewaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        internal object GetAllOffers()
        {
            return _dbContext.Users;
        }
    }
}
