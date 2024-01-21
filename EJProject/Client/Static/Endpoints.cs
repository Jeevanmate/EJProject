
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJProject.Client.Static
{
    public class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string BuyerEndpoint = $"{Prefix}/buyer";
        public static readonly string ProductEndpoint = $"{Prefix}/product";
        public static readonly string SellerEndpoint = $"{Prefix}/seller";
        public static readonly string StaffEndpoint = $"{Prefix}/staff";
        public static readonly string TradeEndpoint = $"{Prefix}/trade";
    }
}




