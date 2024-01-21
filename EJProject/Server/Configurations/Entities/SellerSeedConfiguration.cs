using EJProject.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EJProject.Server.Configurations.Entities
{
    public class SellerSeedConfiguration : IEntityTypeConfiguration<Seller>
    {
        public void Configure(EntityTypeBuilder<Seller> builder)
        {
            builder.HasData(
                 new Seller
                 {
                     SellerID = 1,
                     Name = "Smith",
                     PhoneNumber = "89998765",
                     Email = "Smith@gmail.com"

                 },
                 new Seller
                 {
                     SellerID = 2,
                     Name = "Dickson",
                     PhoneNumber = "88001133",
                     Email = "Dickson@gmail.com"
                 }
                 );
        }
    }
}