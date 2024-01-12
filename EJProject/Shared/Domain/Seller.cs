﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJProject.Shared.Domain
{
    public class Seller :BaseDomainModel
    {
        public int SellerId { get; set; }
        
        public int PhoneNumber { get; set; }

        public string? Email { get; set; }

        public virtual List<Product>? Products { get; set; }

    }
}
