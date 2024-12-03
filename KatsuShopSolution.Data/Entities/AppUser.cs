﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KatsuShopSolution.Data.Entities
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FullName { get; set; }
        public DateTime Dob { get; set; }
        public List<Cart> Carts { get; set; }
        public List<Order> Orders { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
