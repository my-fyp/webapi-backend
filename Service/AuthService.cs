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

        internal object AuthorizeCustomer(AuthModel authModel)
        {
            try
            {
                var valid_user = _dbContext.Customers
                    .Where(c => c.Username == authModel.Username && c.Password == authModel.Password)
                    .Select(cus => new
                    {
                        cus.CustomerId,
                        cus.Username,
                        cus.Name,
                        cus.PhoneNo,
                        cus.Gender,
                        cus.Address,
                        cus.ProfileImage
                    }).FirstOrDefault();

                if (valid_user != null)
                {
                    return Response.ApiResonse(true, "Logged in successful.", valid_user);
                }
                else
                {
                    return Response.ApiResonse(false, "Invalid Creadentials", null);
                }
            }
            catch (Exception ex)
            {
                return Response.ApiResonse(false, "Something went wrong", ex.Message);
            }
        }

        internal object AuthorizeVendor(AuthModel authModel)
        {
            try
            {
                var valid_user = _dbContext.Vendors
                                    .Where(c => c.Username == authModel.Username && c.Password == authModel.Password)
                                    .Select(cus => new
                                    {
                                        cus.VendorId,
                                        cus.Username,
                                        cus.Name,
                                        cus.PhoneNo,
                                        cus.Gender,
                                        cus.Address,
                                        cus.ProfileImage
                                    }).FirstOrDefault();

                if (valid_user != null)
                {
                    return Response.ApiResonse(true, "Logged in successful.", valid_user);
                }
                else
                {
                    return Response.ApiResonse(false, "Invalid Creadentials", null);
                }
            }
            catch(Exception ex)
            {
                return Response.ApiResonse(false, "Something went wrong", ex.Message);
            }
        }
    }
}
