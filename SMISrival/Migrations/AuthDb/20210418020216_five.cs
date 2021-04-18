using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SMISrival.Migrations.AuthDb
{
    public partial class five : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdateBy = table.Column<string>(nullable: true),
                    UpdatedDate = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    ParentName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: false),
                    Gender = table.Column<string>(nullable: false),
                    Branch = table.Column<string>(nullable: false),
                    PersonalId = table.Column<string>(nullable: false),
                    Semester = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}
