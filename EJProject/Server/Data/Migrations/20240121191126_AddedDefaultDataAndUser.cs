using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EJProject.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", null, "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "df3a7f04-767f-4767-869a-61ccc202ad07", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", null, null, false, "01653923-619d-45db-9d2d-0538258f23c1", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "Buyers",
                columns: new[] { "BuyerID", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Jeevan@gmail.com", "Black", "88928586" },
                    { 2, "John@gmail.com", "John", "84601857" }
                });

            migrationBuilder.InsertData(
                table: "Sellers",
                columns: new[] { "SellerID", "Email", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Smith@gmail.com", "Smith", "89998765" },
                    { 2, "Dickson@gmail.com", "Dickson", "88001133" }
                });

            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "StaffID", "Gender", "Name", "Position" },
                values: new object[,]
                {
                    { 1, "Male", "Kala", "Manager" },
                    { 2, "Female", "Jeff", "Clerk" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductID", "Category", "Condition", "Description", "Price", "ProductName", "SellerID" },
                values: new object[,]
                {
                    { 1, "Electronics", "Good", "Brand new ipad", 69.7f, "Ipad Air", 1 },
                    { 2, "Clothes", "Excellent", "Brand new shirt", 220f, "Ralph Lauren Shirt", 2 }
                });

            migrationBuilder.InsertData(
                table: "Trades",
                columns: new[] { "TradeID", "BuyerID", "Location", "PaymentMethod", "Quantity", "TradeName" },
                values: new object[,]
                {
                    { 1, 1, "Tampines", "Cash", 21, "Ipad" },
                    { 2, 2, "Bedok", "Nets", 17, "Shirt" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "StaffID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Trades",
                keyColumn: "TradeID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Trades",
                keyColumn: "TradeID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");

            migrationBuilder.DeleteData(
                table: "Buyers",
                keyColumn: "BuyerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Buyers",
                keyColumn: "BuyerID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "SellerID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sellers",
                keyColumn: "SellerID",
                keyValue: 2);
        }
    }
}
