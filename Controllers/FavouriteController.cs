﻿using Home_Sewa.Data;
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
        public IActionResult Get()
        {
            return Ok(favService.GetAllFavourites());

        }

    }
}




