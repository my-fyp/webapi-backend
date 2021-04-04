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
    public class ProblemController : ControllerBase
    {
        private readonly ProblemService problemService;

        public ProblemController(HomeSewaDbContext DbContext)
        {
            problemService = new ProblemService(DbContext);
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(problemService.GetAllProblems());

        }
        [HttpPost]
        [Route("PostProblems")]

        public IActionResult PostProblems([FromBody] ProblemRequests problemRequests)
        {
            return Ok();//problemService.PostProblems(problemRequests));
        }
        [HttpPatch]
        [Route("UpdateProblems/{ProblemId}")]


    }
}
