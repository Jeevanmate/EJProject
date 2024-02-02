using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJProject.Shared.Domain
{
    public class Trade
    {
        public int TradeID { get; set; }

        public string? TradeName { get; set; } // not required

        
        public string? Location { get; set; } //not required as could be contactless

        [Required]
        public int? Quantity { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Payment Method does not meet the length requirements")]
        public string? PaymentMethod { get; set; }

        public int? BuyerID { get; set; }

        public virtual Buyer? Buyer { get; set; }

    }
}
