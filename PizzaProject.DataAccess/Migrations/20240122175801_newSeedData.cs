using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PizzaProject.Migrations
{
    /// <inheritdoc />
    public partial class newSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Pizzas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "Veggie",
                table: "Pizzas",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "PizzaStyles",
                columns: new[] { "Id", "DisplayOrder", "Name" },
                values: new object[,]
                {
                    { 4, 4, "Neapolitan" },
                    { 5, 5, "Sicilian" },
                    { 6, 6, "Greek" },
                    { 7, 7, "California" },
                    { 8, 8, "St. Louis" }
                });

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Ingredients", "Veggie" },
                values: new object[] { "Large, foldable slices with a thin crust with five different cheeses", "Mozzarella, Feta, Parmesan, Cheddar, Ricotta", true });

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Ingredients", "PizzaStyleId", "Veggie" },
                values: new object[] { "Rising crust slices with three different veggie options", "Green Pepper, Black Olives, and Sun Dried Tomatoes", 1, true });

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "Ingredients", "PizzaStyleId", "Veggie" },
                values: new object[] { "A quick dessert with three different ice cream options", "Homemade Ice Cream with Chocolate, Vanilla, or Strawberry options", 4, true });

            migrationBuilder.InsertData(
                table: "Pizzas",
                columns: new[] { "Id", "Description", "ImageURL", "Ingredients", "Name", "PizzaStyleId", "Price", "Veggie" },
                values: new object[,]
                {
                    { 5, "Deep-dish pizza known for its thick, buttery crust", "", "Tomato Sauce, Mozzarella Cheese, Sausage", "Classic Chicago", 2, 19.989999999999998, false },
                    { 6, " Large, foldable slices with a thin crust.", "", "Tomato Sauce, Mozzarella Cheese, Pepperoni", "Classic New York", 1, 20.989999999999998, false },
                    { 8, " Rectangular pizza with a thick, crispy crust", "", "Tomato Sauce, Brick Cheese, Pepperoni", "Classic Detroit Pizza", 3, 21.989999999999998, false },
                    { 4, "Traditional Italian pizza with a thin, soft crust", "", "Tomato Sauce, Mozzarella Cheese, Basil", "Classic Neapolitan", 4, 17.989999999999998, true },
                    { 7, "Square-shaped pizza with a thick crust", "", "Tomato Sauce, Mozzarella Cheese, Olives", "Classic Sicilian", 5, 19.199999999999999, true }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PizzaStyles",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PizzaStyles",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PizzaStyles",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PizzaStyles",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PizzaStyles",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "Veggie",
                table: "Pizzas");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1,
                column: "Description",
                value: " Mozzarella , Feta, Parmesan, Cheddar, and Ricotta");

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "PizzaStyleId" },
                values: new object[] { " Green Pepper, Black Olives, and Sun Dried Tomatoes", 2 });

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Description", "PizzaStyleId" },
                values: new object[] { "Chocolate, Vanilla, or Strawberry", 1 });
        }
    }
}
