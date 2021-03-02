using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Model
{
    public class Problem
    {
        [Key]
        public int ProblemId { get; set; }
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ProblemImage { get; set; }
        [Required]
        public DateTime AddedDate { get; set; }
        [Required]
        public bool Status { get; set; }

        public  virtual Customer Customers { get; set; }//every unique id customers will have different 
        //problems with their own unique values
    }
}
