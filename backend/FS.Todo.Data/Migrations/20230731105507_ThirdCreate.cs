using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FS.Todo.Data.Migrations
{
    public partial class ThirdCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Todos",
                table: "Todos");

            migrationBuilder.RenameTable(
                name: "Todos",
                newName: "Todo");

            migrationBuilder.AlterColumn<bool>(
                name: "IsCompleted",
                table: "Todo",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Todo",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "Id",
                table: "Todo",
                type: "uuid",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "Date",
                table: "Todo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsResponsible",
                table: "Todo",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Module",
                table: "Todo",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "Todo",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Request",
                table: "Todo",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Requesttype",
                table: "Todo",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "System",
                table: "Todo",
                type: "text",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todo",
                table: "Todo",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Todo",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "IsResponsible",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "Module",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "Request",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "Requesttype",
                table: "Todo");

            migrationBuilder.DropColumn(
                name: "System",
                table: "Todo");

            migrationBuilder.RenameTable(
                name: "Todo",
                newName: "Todos");

            migrationBuilder.AlterColumn<int>(
                name: "IsCompleted",
                table: "Todos",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Todos",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "Todos",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Todos",
                table: "Todos",
                column: "Id");
        }
    }
}
