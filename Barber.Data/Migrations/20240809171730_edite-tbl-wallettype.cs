using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barber.Data.Migrations
{
    /// <inheritdoc />
    public partial class editetblwallettype : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bedehkar",
                table: "WalletTypes");

            migrationBuilder.RenameColumn(
                name: "Bestankar",
                table: "WalletTypes",
                newName: "TypeName");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TypeName",
                table: "WalletTypes",
                newName: "Bestankar");

            migrationBuilder.AddColumn<string>(
                name: "Bedehkar",
                table: "WalletTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
