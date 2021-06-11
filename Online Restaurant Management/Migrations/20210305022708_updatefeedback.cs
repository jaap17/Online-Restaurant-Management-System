using Microsoft.EntityFrameworkCore.Migrations;

namespace sdp2.Migrations
{
    public partial class updatefeedback : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeedBackId",
                table: "feedbacks",
                newName: "FeedbackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FeedbackId",
                table: "feedbacks",
                newName: "FeedBackId");
        }
    }
}
