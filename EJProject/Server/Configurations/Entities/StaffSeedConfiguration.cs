using EJProject.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EJProject.Server.Configurations.Entities
{
    public class StaffSeedConfiguration : IEntityTypeConfiguration<Staff>
    {
        public void Configure(EntityTypeBuilder<Staff> builder)
        {
            builder.HasData(
                new Staff
                {
                    StaffID = 1,
                    Name = "Kala",
                    Gender = "Male",
                    Position = "Manager"

                },
                new Staff
                {
                    StaffID = 2,
                    Name = "Jeff",
                    Gender = "Female",
                    Position = "Clerk"
                }
                );
        }
    }
}