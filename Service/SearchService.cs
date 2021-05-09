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

        internal object GetSearvices(string searchItem)
        {
            if (searchItem == "" || searchItem == null)
            {
                return _dbContext.Professions.Select(sl => new
                {
                    sl.ProfessionId,
                    sl.ProfessionName,
                    sl.ServiceIcon,
                    sl.Slug,
                });
            }
            else
            {
                return _dbContext.Professions.Where(s => s.ProfessionName.Contains(searchItem)).Select(sl => new
                {
                    sl.ProfessionId,
                    sl.ProfessionName,
                    sl.ServiceIcon,
                    sl.Slug,
                });
            }
        }

        internal object GetSpecialist(string slug)
        {
            var vendors = (from v in _dbContext.Vendors
                           select new
                           {
                               v.VendorId,
                               v.UserId,
                               v.User.Username,
                               v.Name,
                               v.ProfileImage,
                               v.PhoneNo,
                               v.Address,
                               Professions = (from p in v.VendorProfessions
                                              select new
                                              {
                                                  p.Profession.ProfessionId,
                                                  p.Profession.ProfessionName,
                                                  p.Profession.ServiceIcon,
                                                  p.Profession.Slug
                                              }).ToList()
                           }).Where(sp => sp.Professions.Where(pp => pp.Slug == slug).ToList().Count != 0);

            return vendors;
        }
    }
}
