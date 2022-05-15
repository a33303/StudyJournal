using Microsoft.EntityFrameworkCore.Migrations;

namespace StudyRowi.Migrations
{
    public partial class Hogwards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyPlans",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speciality = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Discipline = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Semestr = table.Column<int>(type: "int", nullable: false),
                    StudyTime = table.Column<int>(type: "int", nullable: false),
                    FormExam = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyPlans", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Patronymic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReceipt = table.Column<int>(type: "int", nullable: false),
                    FormStudy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GroupeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyJournals",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    StudyPlanId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyJournals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyJournals_Students_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Students",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyJournals_StudyPlans_StudyPlanId",
                        column: x => x.StudyPlanId,
                        principalTable: "StudyPlans",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_GroupeId",
                table: "Students",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyJournals_StudentId",
                table: "StudyJournals",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyJournals_StudyPlanId",
                table: "StudyJournals",
                column: "StudyPlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyJournals");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "StudyPlans");

            migrationBuilder.DropTable(
                name: "Groupes");
        }
    }
}
