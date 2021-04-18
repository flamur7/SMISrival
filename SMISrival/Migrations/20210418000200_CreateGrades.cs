using Microsoft.EntityFrameworkCore.Migrations;

namespace SMISrival.Migrations
{
    public partial class CreateGrades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CreateGrades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonalId = table.Column<string>(nullable: false),
                    CodeTeacher = table.Column<string>(nullable: false),
                    Subjects = table.Column<string>(nullable: false),
                    Grade = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CreateGrades", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CreateGrades");
        }
    }
}
