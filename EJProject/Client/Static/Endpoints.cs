using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJProject.Client.Static
{
    public static class Endpoints
    {
        private static readonly string Prefix = "api";

        public static readonly string BuyersEndpoint = $"{Prefix}/buyers";
        public static readonly string ProductsEndpoint = $"{Prefix}/products";
        public static readonly string SellersEndpoint = $"{Prefix}/sellers";
        public static readonly string StaffsEndpoint = $"{Prefix}/staffs";
        public static readonly string TradesEndpoint = $"{Prefix}/trades";
        public static readonly string ProfilesEndpoint = $"{Prefix}/profiles";

    }
}




