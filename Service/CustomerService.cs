using Home_Sewa.Data;
using Home_Sewa.Helper;
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
            try
            {
                var result = _dbContext.Customers;
                return Response.ApiResponse(true, "All Customers", result);
            }
            catch (Exception ex)
            {
                return Response.ApiResponse(false, "Failed to get data", ex.Message);
            }
        }
    }
}

