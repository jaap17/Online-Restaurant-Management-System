using Microsoft.EntityFrameworkCore.Migrations;

namespace sdp2.Migrations
{
    public partial class addreplyinfeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Reply",
                table: "feedbacks",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Reply",
                table: "feedbacks");
        }
    }
}
