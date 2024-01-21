using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJProject.Shared.Domain
{
    public class Buyer : BaseDomainModel
    {
        public int BuyerID { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}", ErrorMessage = "Contact Number is not a valid phone number")]
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }

        public virtual Seller? Seller { get; set; }
        public int SellerID { get; set; }

        public virtual List<Product>? Products { get; set; }
        public virtual List<Trade>? Trades { get; set; }


     
    }
}
