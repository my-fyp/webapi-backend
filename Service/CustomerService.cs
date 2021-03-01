using Home_Sewa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Service
{
    public class CustomerService
    {
        private readonly HomeSewaDbContext _dbContext;

        public CustomerService(HomeSewaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        internal object GetAllCustomer()
        {
            return _dbContext.Customers;
        } 
    }
}

