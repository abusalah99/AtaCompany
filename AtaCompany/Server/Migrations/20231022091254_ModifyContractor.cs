using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtaCompany.Migrations
{
    /// <inheritdoc />
    public partial class ModifyContractor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_Contractor_ContractorId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_ContractorId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "DealBudget",
                table: "Contractor");

            migrationBuilder.DropColumn(
                name: "DealDate",
                table: "Contractor");

            migrationBuilder.DropColumn(
                name: "DealType",
                table: "Contractor");

            migrationBuilder.DropColumn(
                name: "Penalty",
                table: "Contractor");

            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Payment",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "DealBudget",
                table: "LocationContractor",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DealDate",
                table: "LocationContractor",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "DealType",
                table: "LocationContractor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Penalty",
                table: "LocationContractor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_LocationId_ContractorId",
                table: "Payment",
                columns: new[] { "LocationId", "ContractorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_LocationContractor_LocationId_ContractorId",
                table: "Payment",
                columns: new[] { "LocationId", "ContractorId" },
                principalTable: "LocationContractor",
                principalColumns: new[] { "LocationId", "ContractorId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Payment_LocationContractor_LocationId_ContractorId",
                table: "Payment");

            migrationBuilder.DropIndex(
                name: "IX_Payment_LocationId_ContractorId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Payment");

            migrationBuilder.DropColumn(
                name: "DealBudget",
                table: "LocationContractor");

            migrationBuilder.DropColumn(
                name: "DealDate",
                table: "LocationContractor");

            migrationBuilder.DropColumn(
                name: "DealType",
                table: "LocationContractor");

            migrationBuilder.DropColumn(
                name: "Penalty",
                table: "LocationContractor");

            migrationBuilder.AddColumn<string>(
                name: "DealBudget",
                table: "Contractor",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DealDate",
                table: "Contractor",
                type: "datetime2",
                nullable: false,
                defaultValueSql: "GETDATE()");

            migrationBuilder.AddColumn<string>(
                name: "DealType",
                table: "Contractor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Penalty",
                table: "Contractor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_ContractorId",
                table: "Payment",
                column: "ContractorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Payment_Contractor_ContractorId",
                table: "Payment",
                column: "ContractorId",
                principalTable: "Contractor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
