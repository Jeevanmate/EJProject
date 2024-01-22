using EJProject.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Drawing;

namespace EJProject.Server.Configurations.Entities
{
    public class BuyerSeedConfiguration : IEntityTypeConfiguration<Buyer>
    {
        public void Configure(EntityTypeBuilder<Buyer> builder)
        {
            builder.HasData(
                new Buyer
                {
                    BuyerID = 1,
                    Name = "Black",
                    PhoneNumber = "88928586",
                    Email = "Jeevan@gmail.com"

                },
                new Buyer
                {
                    BuyerID = 2,
                    Name = "John",
                    PhoneNumber = "84601857",
                    Email = "John@gmail.com"
                }
                );
        }
    }
}