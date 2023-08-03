using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FS.Todo.Data.Migrations
{
    public partial class _6Mig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Pending = table.Column<string>(type: "text", nullable: true),
                    Indevelopment = table.Column<string>(type: "text", nullable: true),
                    Testing = table.Column<string>(type: "text", nullable: true),
                    Closed = table.Column<string>(type: "text", nullable: true),
                    Classification = table.Column<int>(type: "integer", nullable: false),
                    Analytics = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Status");
        }
    }
}
