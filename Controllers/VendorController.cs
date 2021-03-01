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
    public class VendorController : ControllerBase
    {
        private readonly VendorServices vendorServices;
        public VendorController(HomeSewaDbContext dbContext)
        {
            vendorServices = new VendorServices(dbContext);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(vendorServices.GetAllVendors());
           
        }
    
    }
}
