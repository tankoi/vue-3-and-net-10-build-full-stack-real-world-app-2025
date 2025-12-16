using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MangoFusion_API.Migrations
{
    /// <inheritdoc />
    public partial class SeedMenuItems2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MenuItems",
                columns: new[] { "Id", "Category", "Description", "Image", "Name", "Price", "SpecialTag" },
                values: new object[,]
                {
                    { 1, "Appetizer", "A crispy and savory Indian snack filled with spiced potatoes and peas.", "", "Samosa", 1.99, "Vegetarian" },
                    { 2, "Appetizer", "Chunks of paneer marinated in spices and grilled to perfection.", "", "Paneer Tikka", 3.9900000000000002, "Vegetarian" },
                    { 3, "Main Course", "A flavorful curry made with tender chicken pieces simmered in a rich tomato-based sauce.", "", "Chicken Curry", 7.9900000000000002, "" },
                    { 4, "Bread", "Soft and fluffy Indian bread topped with garlic and butter.", "", "Garlic Naan", 1.49, "Vegetarian" },
                    { 5, "Beverage", "A refreshing yogurt-based drink blended with ripe mangoes and a hint of cardamom.", "", "Mango Lassi", 2.9900000000000002, "Vegetarian" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MenuItems",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
