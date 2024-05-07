using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class setup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "RentalData");

            migrationBuilder.DropColumn(
                name: "CVV",
                table: "RentalData");

            migrationBuilder.DropColumn(
                name: "City",
                table: "RentalData");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "RentalData");

            migrationBuilder.DropColumn(
                name: "CreditCard",
                table: "RentalData");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "RentalData");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "RentalData");

            migrationBuilder.DropColumn(
                name: "ExpMonth",
                table: "RentalData");

            migrationBuilder.DropColumn(
                name: "ExpYear",
                table: "RentalData");

            migrationBuilder.DropColumn(
                name: "FullName",
                table: "RentalData");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                table: "RentalData");

            migrationBuilder.DropColumn(
                name: "State",
                table: "RentalData");

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditCard = table.Column<int>(type: "int", nullable: false),
                    ExpMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CVV = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "RentalData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CVV",
                table: "RentalData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "RentalData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "RentalData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreditCard",
                table: "RentalData",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "RentalData",
                type: "nvarchar(13)",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "RentalData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpMonth",
                table: "RentalData",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExpYear",
                table: "RentalData",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "RentalData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                table: "RentalData",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "RentalData",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
