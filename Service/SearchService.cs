using Home_Sewa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Service
{
    public class SearchService
    {
        private readonly HomeSewaDbContext _dbContext;
        public SearchService(HomeSewaDbContext dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
