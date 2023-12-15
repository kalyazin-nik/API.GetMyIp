using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Database.Migrations
{
    /// <inheritdoc />
    public partial class Initialization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "api");

            migrationBuilder.CreateTable(
                name: "users",
                schema: "api",
                columns: table => new
                {
                    guid = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.guid);
                });

            migrationBuilder.CreateTable(
                name: "ip_infos",
                schema: "api",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    ip = table.Column<string>(type: "text", nullable: false),
                    city = table.Column<string>(type: "text", nullable: false),
                    region = table.Column<string>(type: "text", nullable: false),
                    country = table.Column<string>(type: "text", nullable: false),
                    loc = table.Column<string>(type: "text", nullable: false),
                    org = table.Column<string>(type: "text", nullable: false),
                    zip = table.Column<string>(type: "text", nullable: false),
                    timezone = table.Column<string>(type: "text", nullable: false),
                    readme = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ip_infos", x => x.user_id);
                    table.ForeignKey(
                        name: "FK_ip_infos_users_user_id",
                        column: x => x.user_id,
                        principalSchema: "api",
                        principalTable: "users",
                        principalColumn: "guid",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ip_infos_user_id",
                schema: "api",
                table: "ip_infos",
                column: "user_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_guid",
                schema: "api",
                table: "users",
                column: "guid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ip_infos",
                schema: "api");

            migrationBuilder.DropTable(
                name: "users",
                schema: "api");
        }
    }
}
