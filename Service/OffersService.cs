using Home_Sewa.Data;
using Home_Sewa.Helper;
using Home_Sewa.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Service
{
    public class OffersService
    {
        private readonly HomeSewaDbContext _dbContext;
        public OffersService(HomeSewaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        internal object GetAllOffers()
        {
            return _dbContext.Offers
                .Where(o => o.ValidDate > DateTime.Now)
                .OrderByDescending(d => d.CreatedAt);
        }

        internal object PostOffers(OfferRequest offerRequest)
        {
            try
            {
                Offer new_Offer = new Offer
                {
                    VendorId = offerRequest.VendorId,
                    ValidDate = offerRequest.ValidDate,
                    OfferImage = offerRequest.OfferImage,
                    Description = offerRequest.OfferDescription,
                    CreatedAt = DateTime.Now
                };
                _dbContext.Offers.Add(new_Offer);
                _dbContext.SaveChanges();
                return Response.ApiResponse(true, "Offers Added Sucessfully", new_Offer);

            }
            catch (Exception ex)
            {
                return Response.ApiResponse(false, "Something went wrong", ex.Message);
            }
            throw new NotImplementedException();
        }
        internal object DeleteOffer(int OfferId)
        {
            try
            {
                Offer offer = _dbContext.Offers.Find(OfferId);
                if (offer != null)
                {
                    _dbContext.Offers.Remove(offer);
                    _dbContext.SaveChanges();
                    return Response.ApiResponse(true, "Offer Removed Sucessfully", offer);
                }
                else
                {
                    return Response.ApiResponse(false, "Offer not found", null);
                }

            }
            catch (Exception ex)
            {
                return Response.ApiResponse(false, "Something went wrong", ex.Message);
            }
            throw new NotImplementedException();
        }

        internal object UpdateOffer(int OfferId, OfferRequest newDetails)
        {
            try
            {
                Offer old_offer = _dbContext.Offers.Find(OfferId);
                if (old_offer != null)
                {
                    old_offer.ValidDate = newDetails.ValidDate;
                    old_offer.OfferImage = newDetails.OfferImage;
                    old_offer.Description = newDetails.OfferDescription;

                    _dbContext.Entry(old_offer).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return Response.ApiResponse(true, "Offer Updated SucessFully", old_offer);
                }
                else
                {
                    return Response.ApiResponse(false, "Offer not found", null);
                }
            }
            catch (Exception ex)
            {
                return Response.ApiResponse(false, "Something went wrong", ex.Message);
            }
            throw new NotImplementedException();
        }

    }
}
