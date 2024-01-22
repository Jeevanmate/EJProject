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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e61750d-7735-4459-932d-9f31f284aabd", "AQAAAAIAAYagAAAAEGyugwv42mSorMn1lk97EWW14r2WMn9Mbh7BxYC5Eg3KPhLaAQ7yFMJIcB+gg38j+w==", "8d953b71-9441-4f0e-8c27-6c0527e5879f" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f6b1f44a-02cd-4229-a231-127a089935e5", "AQAAAAIAAYagAAAAECsGxJWVv/su9BCLxj/23bCRXfQ45SR8XvrlVYZzCoLz0JMKGFiX89IKd7uFPaA58g==", "d6440bd2-689a-41a2-be10-798c1e309088" });

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
    }
}
