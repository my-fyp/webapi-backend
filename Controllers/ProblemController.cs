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
        [Route("PostProblemRequest")]
        public IActionResult PostProblemRequest([FromBody] ProblemRequest problemRequest)
        {
            return Ok(problemService.PostProblem(problemRequest));
        }

        [HttpDelete]
        [Route("DeleteProblem/{ProblemId}")]

        public IActionResult DeleteProblem(int ProblemId) 
        {
            return Ok(problemService.DeleteProblem(ProblemId));

        }
        [HttpPatch]
        [Route("UpdateProblem/{problemId}")]
        public IActionResult UpdateProblem(int problemId, [FromBody] ProblemRequest newDetails)
        {
            return Ok(problemService.UpdateProblem(problemId, newDetails));

        }

}
}
