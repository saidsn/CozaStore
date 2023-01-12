using Microsoft.EntityFrameworkCore.Migrations;

namespace End_Project.Migrations
{
    public partial class addBrenIdColumnToProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brends_BrendId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "BrendId",
                table: "Products",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brends_BrendId",
                table: "Products",
                column: "BrendId",
                principalTable: "Brends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brends_BrendId",
                table: "Products");

            migrationBuilder.AlterColumn<int>(
                name: "BrendId",
                table: "Products",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brends_BrendId",
                table: "Products",
                column: "BrendId",
                principalTable: "Brends",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
