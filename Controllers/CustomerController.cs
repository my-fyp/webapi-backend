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
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService customer_service;
        public CustomerController(HomeSewaDbContext dbContext)
        {
            customer_service = new CustomerService(dbContext);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(customer_service.GetAllCustomer());
        }
        /*[HttpPost]
        public IActionResult Post() 
        { 
        
        }*/

    }
}
