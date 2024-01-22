using EJProject.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EJProject.Server.Configurations.Entities
{
    public class ProductSeedConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasData(
                new Product
                {
                    ProductID = 1,
                    ProductName = "Ipad Air",
                    Category = "Electronics",
                    Price = 69.7F,
                    Condition = "Good",
                    Description = "Brand new ipad",
                    SellerID = 1


                },
                new Product
                {
                    ProductID = 2,
                    ProductName = "Ralph Lauren Shirt",
                    Category = "Clothes",
                    Price = 220,
                    Condition = "Excellent",
                    Description = "Brand new shirt",
                    SellerID = 2
                }
                );
        }
    }
}