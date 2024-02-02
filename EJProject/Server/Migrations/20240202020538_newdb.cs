using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EJProject.Server.Migrations
{
    /// <inheritdoc />
    public partial class newdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3c705b1a-e4ca-477f-b84c-1e87d097fb1d", "53f42e1f-4683-4568-83a4-d856bc2f2659" });
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
