using Microsoft.EntityFrameworkCore.Migrations;

namespace End_Project.Migrations
{
    public partial class DeleteCommentColumntoContacttable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comment",
                table: "Contacts");

            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Contacts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Subject",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "Comment",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
