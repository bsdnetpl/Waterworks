using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Waterworks.Migrations
{
    /// <inheritdoc />
    public partial class addIsPayed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isPayed",
                table: "customersPayments",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isPayed",
                table: "customersPayments");
        }
    }
}
