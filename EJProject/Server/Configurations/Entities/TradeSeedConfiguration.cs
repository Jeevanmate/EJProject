using EJProject.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EJProject.Server.Configurations.Entities
{
    public class TradeSeedConfiguration : IEntityTypeConfiguration<Trade>
    {
        public void Configure(EntityTypeBuilder<Trade> builder)
        {
            builder.HasData(
                new Trade
                {
                    TradeID = 1,
                    TradeName = "Ipad",
                    Location = "Tampines",
                    Quantity = 21,
                    PaymentMethod = "Cash",
                    BuyerID = 1

                },
                new Trade
                {
                    TradeID = 2,
                    TradeName = "Shirt",
                    Location = "Bedok",
                    Quantity = 17,
                    PaymentMethod = "Nets",
                    BuyerID = 2
                }
                );
        }
    }
}