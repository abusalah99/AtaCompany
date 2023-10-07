using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtaCompany.Migrations
{
    /// <inheritdoc />
    public partial class ChangeLocationOfSupplierToAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Supplier",
                newName: "Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Supplier",
                newName: "Location");
        }
    }
}
