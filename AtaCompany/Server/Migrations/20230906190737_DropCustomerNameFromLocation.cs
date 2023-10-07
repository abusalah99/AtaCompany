using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtaCompany.Migrations
{
    /// <inheritdoc />
    public partial class DropCustomerNameFromLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CustomerName",
                table: "Location",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Location",
                newName: "CustomerName");
        }
    }
}
