using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Barber.Data.Migrations
{
    /// <inheritdoc />
    public partial class inittblspermitions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "premitions",
                columns: table => new
                {
                    PremitionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ParentId = table.Column<int>(type: "int", nullable: true),
                    RoleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_premitions", x => x.PremitionId);
                    table.ForeignKey(
                        name: "FK_premitions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId");
                    table.ForeignKey(
                        name: "FK_premitions_premitions_ParentId",
                        column: x => x.ParentId,
                        principalTable: "premitions",
                        principalColumn: "PremitionId");
                });

            migrationBuilder.CreateTable(
                name: "rolePremitions",
                columns: table => new
                {
                    RP_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    PremitionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_rolePremitions", x => x.RP_id);
                    table.ForeignKey(
                        name: "FK_rolePremitions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_premitions_ParentId",
                table: "premitions",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_premitions_RoleId",
                table: "premitions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_rolePremitions_RoleId",
                table: "rolePremitions",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "premitions");

            migrationBuilder.DropTable(
                name: "rolePremitions");
        }
    }
}
