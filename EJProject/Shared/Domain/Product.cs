using System;
using System.Collections.Generic;
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

        public float Price { get; set; }

        public string? Condition { get; set; }
        public string? Description { get; set; }

        public int SellerID { get; set; }
        public virtual Seller? Seller { get; set; }

    }

}
