using Home_Sewa.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Service
{
    public class ProblemService
    {
        private readonly HomeSewaDbContext _dbContext;

        public ProblemService(HomeSewaDbContext prob)
        {
            _dbContext = prob;
            
        }
        internal object GetAllProblems()
        {
            return _dbContext.Problems;
        }
        internal object PostProblems() 
        {
            return _dbContext.Problems;
        }




    }
}
