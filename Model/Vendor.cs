﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Home_Sewa.Model
{
    public class Vendor
    {
        [Key]
        public int  VendorId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        public  string Name { get; set; }
        [StringLength(10)]
        public string PhoneNo { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public   string Gender { get; set; }
        public   string ProfileImage { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Offer> Offers { get; set; }
        public virtual ICollection<Favourite> Favourites { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<VendorProfession> VendorProfessions { get; set; }

    }
}
