using Microsoft.EntityFrameworkCore.Migrations;

namespace sdp2.Migrations
{
    public partial class addfidinreplies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FeedbackId",
                table: "Reply",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FeedbackId",
                table: "Reply");
        }
    }
}
