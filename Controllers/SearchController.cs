using Home_Sewa.Data;
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
    public class SearchController : ControllerBase
    {
        private readonly SearchService _searchService;
        public SearchController(HomeSewaDbContext dbContext)
        {
            _searchService = new SearchService(dbContext);
        }

        [HttpGet]
        public IActionResult Get(string searchItem)
        {
            return Ok(_searchService.GetSearvices(searchItem));
        }

        [HttpGet]
        [Route("GetSpecialist/{slug}")]
        public IActionResult GetSpecialist(string slug)
        {
            return Ok(_searchService.GetSpecialist(slug));
        }
    }
}
