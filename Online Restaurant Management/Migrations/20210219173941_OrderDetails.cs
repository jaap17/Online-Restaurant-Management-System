using Microsoft.EntityFrameworkCore.Migrations;

namespace sdp2.Migrations
{
    public partial class OrderDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Country",
                table: "Orderrs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Orderrs");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Orderrs");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Orderrs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine1",
                table: "OrderDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AddressLine2",
                table: "OrderDetails",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "OrderTotal",
                table: "OrderDetails",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Orderrs");

            migrationBuilder.DropColumn(
                name: "AddressLine1",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "AddressLine2",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "OrderTotal",
                table: "OrderDetails");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Orderrs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Orderrs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Orderrs",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true);
        }
    }
}
