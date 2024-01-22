using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EJProject.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedHash : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6b1f44a-02cd-4229-a231-127a089935e5", "AQAAAAIAAYagAAAAECsGxJWVv/su9BCLxj/23bCRXfQ45SR8XvrlVYZzCoLz0JMKGFiX89IKd7uFPaA58g==", "d6440bd2-689a-41a2-be10-798c1e309088" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1adcd0e2-3420-4c17-aef6-7896d1df3355", null, "08193f1e-6b35-4523-afc9-0eb1511aad8e" });
        }
    }
}
