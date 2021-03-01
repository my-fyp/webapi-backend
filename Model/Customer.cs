﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Model
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        public string Address { get; set; }
        [StringLength(10)]
        public string PhoneNo { get; set; }
        public string ProfileImage { get; set; }

        public virtual ICollection<Problem> Problems { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

    }
}