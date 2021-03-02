using Home_Sewa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Service
{
    public class FavouriteService
    {
        public readonly HomeSewaDbContext DbContext;

        public FavouriteService(HomeSewaDbContext dbContext)
        {
            DbContext = dbContext; 
        }
        internal object GetAllFavourites() 
        {
            return DbContext.Favourites;

        }

    }
}
