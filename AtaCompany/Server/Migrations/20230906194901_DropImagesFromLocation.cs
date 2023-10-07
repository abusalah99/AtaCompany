using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtaCompany.Migrations
{
    /// <inheritdoc />
    public partial class DropImagesFromLocation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Location");

            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Location",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Location");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Location",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
