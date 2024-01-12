using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EJProject.Shared.Domain
{
    public class Trade
    {
        public int TradeID { get; set; }
        public string? Location { get; set; }

        public int? Quantity { get; set; }

        public string? PaymentMethod { get; set; }



    }
}
