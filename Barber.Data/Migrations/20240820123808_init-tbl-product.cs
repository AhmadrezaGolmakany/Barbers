using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barber.Data.Migrations
{
    /// <inheritdoc />
    public partial class inittblproduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_premitions_Roles_RoleId",
                table: "premitions");

            migrationBuilder.DropForeignKey(
                name: "FK_rolePremitions_Roles_RoleId",
                table: "rolePremitions");

            migrationBuilder.DropIndex(
                name: "IX_rolePremitions_RoleId",
                table: "rolePremitions");

            migrationBuilder.DropIndex(
                name: "IX_premitions_RoleId",
                table: "premitions");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "premitions");

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dscription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<double>(type: "float", maxLength: 25, nullable: false),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "products");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "premitions",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_rolePremitions_RoleId",
                table: "rolePremitions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_premitions_RoleId",
                table: "premitions",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_premitions_Roles_RoleId",
                table: "premitions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_rolePremitions_Roles_RoleId",
                table: "rolePremitions",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
