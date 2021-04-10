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
    public class ProblemService
    {
        private readonly HomeSewaDbContext _dbContext;
        public ProblemService(HomeSewaDbContext prob)
        {
            _dbContext = prob;
        }
        internal object GetAllProblems()
        {
            return _dbContext.Problems.Where(p => p.Status == false).OrderByDescending(d => d.CreatedAt);
        }
        internal object PostProblem(ProblemRequest problemRequest)
        {
            try
            {
                Problem new_Problem = new Problem
                {
                    CustomerId = problemRequest.CustomerId,
                    Description = problemRequest.Description,
                    ProblemImage = problemRequest.ProblemImage,
                    CreatedAt = DateTime.Now,
                    Status = false
                };
                _dbContext.Problems.Add(new_Problem);
                _dbContext.SaveChanges();
                return Response.ApiResponse(true, "Problem posted Sucessfully", new_Problem);
            }
            catch (Exception ex)
            {
                return Response.ApiResponse(false, "Something went wrong", ex.Message);
            }
            throw new NotImplementedException();
        }
        internal object DeleteProblem(int ProblemId)
        {
            try
            {
                Problem problem = _dbContext.Problems.Find(ProblemId);
                if (problem != null)
                {
                    _dbContext.Problems.Remove(problem);
                    _dbContext.SaveChanges();
                    return Response.ApiResponse(true, "Problem deleted", problem);
                }
                else
                {
                    return Response.ApiResponse(false, "Problem not found", null);
                }
            }
            catch (Exception ex)
            {
                return Response.ApiResponse(false, "Something went wrong", ex.Message);
            }
            throw new NotImplementedException();
        }
        internal object UpdateProblem(int ProblemId, ProblemRequest newDetails)
        {
            try
            {
                Problem old_problem = _dbContext.Problems.Find(ProblemId);
                if (old_problem != null)
                {
                    old_problem.Description = newDetails.Description;
                    old_problem.ProblemImage = newDetails.ProblemImage;
                    old_problem.Status = newDetails.Status;
                    _dbContext.Entry(old_problem).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return Response.ApiResponse(true, "Booking Updated sucessfully", old_problem);
                }
                else
                {
                    return Response.ApiResponse(false, "No Such Problem found", null);
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

