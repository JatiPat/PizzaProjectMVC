using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PizzaProject.Migrations
{
    /// <inheritdoc />
    public partial class addedStyleinModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PizzaStyleId",
                table: "Pizzas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 1,
                column: "PizzaStyleId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 2,
                column: "PizzaStyleId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Pizzas",
                keyColumn: "Id",
                keyValue: 3,
                column: "PizzaStyleId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Pizzas_PizzaStyleId",
                table: "Pizzas",
                column: "PizzaStyleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pizzas_PizzaStyles_PizzaStyleId",
                table: "Pizzas",
                column: "PizzaStyleId",
                principalTable: "PizzaStyles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pizzas_PizzaStyles_PizzaStyleId",
                table: "Pizzas");

            migrationBuilder.DropIndex(
                name: "IX_Pizzas_PizzaStyleId",
                table: "Pizzas");

            migrationBuilder.DropColumn(
                name: "PizzaStyleId",
                table: "Pizzas");
        }
    }
}
