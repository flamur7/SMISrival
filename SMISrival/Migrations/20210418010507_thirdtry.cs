using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMISrival.Migrations
{
    public partial class thirdtry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Teachers",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Teachers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "Students",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Students",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UpdatedDate",
                table: "Students");
        }
    }
}
