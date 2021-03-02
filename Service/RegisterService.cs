using Home_Sewa.Data;
using Home_Sewa.Helper;
using Home_Sewa.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Service
{
    public class RegisterService
    {
        private readonly HomeSewaDbContext _dbContext;
        public RegisterService(HomeSewaDbContext dbcontext)
        {
            _dbContext = dbcontext;
        }

        internal object RegisterUser(RegisterUser user_model)
        {
            try
            {
                var old_user = _dbContext.Users.Where(u => u.Username.Equals(user_model.Username)).FirstOrDefault();
                if (old_user == null)
                {
                    User new_user = new User
                    {
                        Username = user_model.Username,
                        Password = user_model.Password,
                        UserType = user_model.UserType
                    };

                    _dbContext.Users.Add(new_user);
                    _dbContext.SaveChanges();
                    if (user_model.UserType == Constants.CUSTOMER)
                    {
                        Customer new_customer = new Customer
                        {
                            UserId = new_user.UserId,
                            Name = user_model.Name,
                            Gender = user_model.Gender,
                            Address = user_model.Address,
                            PhoneNo = user_model.PhoneNo,
                            ProfileImage = null
                        };
                        _dbContext.Customers.Add(new_customer);
                    }
                    else
                    {
                        Vendor new_vendor = new Vendor
                        {
                            UserId = new_user.UserId,
                            Name = user_model.Name,
                            Gender = user_model.Gender,
                            Address = user_model.Address,
                            PhoneNo = user_model.PhoneNo,
                            ProfileImage = null
                        };
                        _dbContext.Vendors.Add(new_vendor);
                    }
                    _dbContext.SaveChanges();
                    dynamic user_details;
                    if (user_model.UserType == Constants.CUSTOMER)
                    {
                        user_details = _dbContext.Customers.Select(c => new
                        {
                            c.User.Username,
                            c.UserId,
                            c.Name,
                            c.PhoneNo,
                            c.Address,
                            c.User.UserType
                        })
                        .Where(u => u.UserId == new_user.UserId)
                        .FirstOrDefault();
                    }
                    else
                    {
                        user_details = _dbContext.Vendors.Select(c => new
                        {
                            c.User.Username,
                            c.UserId,
                            c.Name,
                            c.PhoneNo,
                            c.Address,
                            c.User.UserType
                        })
                        .Where(u => u.UserId == new_user.UserId)
                        .FirstOrDefault();
                    }
                    return Response.ApiResonse(true, "Logged in successful.", user_details);
                }
                else
                {
                    return Response.ApiResonse(false, "User already exists", null);
                }
            }
            catch (Exception ex)
            {
                return Response.ApiResonse(false, "Something went wrong.", ex);
            }
        }
    }
}
