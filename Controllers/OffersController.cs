using Home_Sewa.Data;
using Home_Sewa.Helper;
using Home_Sewa.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        private readonly OffersService offerServices;
        public OffersController(HomeSewaDbContext dbContext)
        {
            offerServices = new OffersService(dbContext);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(offerServices.GetAllOffers());
        }
        [HttpPost]
        public IActionResult PostOffers([FromBody] OfferRequest offerRequest)
        {
            return Ok(offerServices.PostOffers(offerRequest));
        }
        [HttpDelete]
        [Route("DeleteOffer/{OfferId}")]
        public IActionResult DeleteOffer(int OfferId)
        {
            return Ok(offerServices.DeleteOffer(OfferId));
        }
        [HttpPatch]
        [Route("UpdateOffer/{OfferId}")]

        public IActionResult UpdateOffer(int OfferId, [FromBody] OfferRequest newDetails)
        {
            return Ok(offerServices.UpdateOffer(OfferId, newDetails));
        }

    }
}

