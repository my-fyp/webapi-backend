using Home_Sewa.Data;
using Home_Sewa.Helper;
using Home_Sewa.Model;
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
        internal object GetAllFavourites(int userId)
        {
            return DbContext.Favourites
                .Where(i => i.CustomerId == userId)
                .OrderByDescending(d => d.CreatedAt)
                .Select(s => new
                {
                    s.FavouriteId,
                    s.CustomerId,
                    s.Vendor.VendorId,
                    s.Vendor.Name,
                    s.Vendor.ProfileImage
                });
        }
        internal object AddFavourites(FavouriteRequest favouriteRequest)
        {
            try
            {
                Favourite new_favourite = new Favourite
                {
                    CustomerId = favouriteRequest.CustomerId,
                    VendorId = favouriteRequest.VendorId,
                    CreatedAt = DateTime.Now
                };
                DbContext.Favourites.Add(new_favourite);
                DbContext.SaveChanges();
                return Response.ApiResponse(true, "New favourites Added Sucessfully", new_favourite);
            }
            catch (Exception ex)
            {
                return Response.ApiResponse(false, "Something went wrong", ex.Message);
            }
            throw new NotFiniteNumberException();

        }
        internal object DeleteFavourites(int FavouritesId)
        {
            try
            {
                Favourite favorites = DbContext.Favourites.Find(FavouritesId);
                if (favorites != null)
                {
                    DbContext.Favourites.Remove(favorites);
                    DbContext.SaveChanges();
                    return Response.ApiResponse(true, "Favourites Removed Sucessfully", favorites);
                }
                else
                {
                    return Response.ApiResponse(false, "favourites not found", null);
                }

            }
            catch (Exception ex)
            {
                return Response.ApiResponse(false, "Something went Wrong", ex.Message);
            }
        }


    }
}
