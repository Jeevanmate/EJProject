using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EJProject.Server.Migrations
{
    /// <inheritdoc />
    public partial class ProfileEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "fa3ccfe1-b7c8-4dc5-9c40-c5fb61a8a4e4", "1fd76bd6-83cb-4ecc-9838-925320e905c5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "457c24f4-5c91-484a-9a3b-2e85ae72cc01", "07149918-6d0d-4dab-b97c-117cf405dfb4" });
        }
    }
}
