using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SharpDesktop.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desktops",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    IconPath = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desktops", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Launchers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 20, nullable: false),
                    Path = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    BackgroundPath = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DesktopId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Launchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Launchers_Desktops_DesktopId",
                        column: x => x.DesktopId,
                        principalTable: "Desktops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Launchers_DesktopId",
                table: "Launchers",
                column: "DesktopId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Launchers");

            migrationBuilder.DropTable(
                name: "Desktops");
        }
    }
}
