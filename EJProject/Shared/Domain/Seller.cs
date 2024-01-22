using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJProject.Shared.Domain
{
    public class Seller : BaseDomainModel
    {
        public int SellerID { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public virtual List<Product>?Products { get; set; }
    }
}
