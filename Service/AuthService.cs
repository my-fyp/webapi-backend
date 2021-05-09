using Home_Sewa.Data;
using Home_Sewa.Helper;
using Home_Sewa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Service
{
    public class AuthService
    {
        private readonly HomeSewaDbContext _dbContext;
        public AuthService(HomeSewaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        internal object AuthorizeUser(AuthModel authModel)
        {
            try
            {
                var valid_user = _dbContext.Users
                    .Where(c => c.Username == authModel.Username && c.Password == authModel.Password)
                    .Select(cus => new
                    {
                        cus.UserId,
                        cus.Username,
                        cus.UserType,
                    }).FirstOrDefault();

                if (valid_user != null)
                {
                    dynamic user_details;
                    if (valid_user.UserType == Constants.CUSTOMER)
                    {
                        user_details = _dbContext.Customers.Select(c => new
                        {
                            c.User.Username,
                            c.UserId,
                            AccessId = c.CustomerId,
                            c.Name,
                            c.PhoneNo,
                            c.Address,
                            c.User.UserType
                        }).Where(u => u.UserId == valid_user.UserId).FirstOrDefault();
                    }
                    else
                    {
                        user_details = _dbContext.Vendors.Select(c => new
                        {
                            c.User.Username,
                            c.UserId,
                            AccessId = c.VendorId,
                            c.Name,
                            c.PhoneNo,
                            c.Address,
                            c.User.UserType
                        }).Where(u => u.UserId == valid_user.UserId).FirstOrDefault();
                    }
                    return Response.ApiResponse(true, "Logged in successful.", user_details);
                }
                else
                {
                    return Response.ApiResponse(false, "Invalid Creadentials", null);
                }
            }
            catch (Exception ex)
            {
                return Response.ApiResponse(false, "Something went wrong", ex.Message);
            }
        }
    }
}
