﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJProject.Shared.Domain
{
    public class Product
    {
        public int ProductID { get; set; }
        public string? ProductName { get; set; }

        public string? Category { get; set; }

        public float? Price { get; set; }

        public string? Condition { get; set; }
        public string? Description { get; set; }

        public virtual Buyer? Buyer { get; set; }
        public int BuyerID { get; set; }

        [Required(ErrorMessage = "Please select an image.")]
        public IFormFile? Image { get; set; }


    }
}
