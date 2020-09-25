using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace InventorySystem.Migrations
{
    public partial class InitialCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    id = table.Column<int>(type: "int(10)", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(30)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                        .Annotation("MySql:Collation", "utf8mb4_general_ci"),
                    quantity = table.Column<int>(type: "int(10)", nullable: false),
                    is_discontinued = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "is_discontinued", "name", "quantity" },
                values: new object[] { -1, false, "Renberget", 5 });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "is_discontinued", "name", "quantity" },
                values: new object[] { -2, false, "Loberget", 0 });

            migrationBuilder.InsertData(
                table: "product",
                columns: new[] { "id", "is_discontinued", "name", "quantity" },
                values: new object[] { -3, true, "Loberget", 0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product");
        }
    }
}
