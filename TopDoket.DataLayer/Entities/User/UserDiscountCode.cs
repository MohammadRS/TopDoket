﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TopDoket.DataLayer.Entities.Order;

namespace TopDoket.DataLayer.Entities.User
{
    public class UserDiscountCode
    {
        [Key]
        public int UD_Id { get; set; }
        public int UserId { get; set; }
        public int DiscountId { get; set; }


        public User User { get; set; }
        public Discount Discount { get; set; }
    }
}
