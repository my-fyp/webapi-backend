using Home_Sewa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Service
{
    public class UsersService
    {
        private readonly HomeSewaDbContext _dbContext;
        public UsersService(HomeSewaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        internal object GetAllUsers()
        {
            //New Change
            return _dbContext.Users;
        }
    }
}
