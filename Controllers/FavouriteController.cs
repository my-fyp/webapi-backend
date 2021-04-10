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
    public class FavouriteController : ControllerBase
    {
        public readonly FavouriteService favService;
        public FavouriteController(HomeSewaDbContext DbContext)
        {
            favService = new FavouriteService(DbContext);
        }
        [HttpGet]
        [Route("GetFavorites/{userId}")]
        public IActionResult GetFavorites(int userId)
        {
            return Ok(favService.GetAllFavourites(userId));
        }
        [HttpPost]
        public IActionResult AddFavourites([FromBody] FavouriteRequest favouriteRequest)
        {
            return Ok(favService.AddFavourites(favouriteRequest));
        }
        [HttpDelete]
        [Route("DeleteFavourites/{FavouriteId}")]
        public IActionResult DeleteFavourites(int FavouriteId)
        {
            return Ok(favService.DeleteFavourites(FavouriteId));        
        }
    }
}




