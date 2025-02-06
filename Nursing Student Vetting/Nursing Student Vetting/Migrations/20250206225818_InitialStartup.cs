using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Nursing_Student_Vetting.Migrations
{
    /// <inheritdoc />
    public partial class InitialStartup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClassCategories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryPrefix = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassCategories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    EvaluationScore = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    GraduationDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentID);
                });

            migrationBuilder.CreateTable(
                name: "Tests",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TestName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GradingScale = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tests", x => x.TestID);
                });

            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreditHours = table.Column<int>(type: "int", nullable: false),
                    IsRequired = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => new { x.ClassID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_Classes_ClassCategories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "ClassCategories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StudentTests",
                columns: table => new
                {
                    TestID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    AttemptNumber = table.Column<int>(type: "int", nullable: false),
                    Score = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTests", x => new { x.TestID, x.AttemptNumber, x.StudentID });
                    table.ForeignKey(
                        name: "FK_StudentTests_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTests_Tests_TestID",
                        column: x => x.TestID,
                        principalTable: "Tests",
                        principalColumn: "TestID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentClasses",
                columns: table => new
                {
                    ClassID = table.Column<int>(type: "int", nullable: false),
                    CategoryID = table.Column<int>(type: "int", nullable: false),
                    StudentID = table.Column<int>(type: "int", nullable: false),
                    LetterGrade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentClasses", x => new { x.ClassID, x.CategoryID, x.StudentID });
                    table.ForeignKey(
                        name: "FK_StudentClasses_Classes_ClassID_CategoryID",
                        columns: x => new { x.ClassID, x.CategoryID },
                        principalTable: "Classes",
                        principalColumns: new[] { "ClassID", "CategoryID" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentClasses_Students_StudentID",
                        column: x => x.StudentID,
                        principalTable: "Students",
                        principalColumn: "StudentID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ClassCategories",
                columns: new[] { "CategoryID", "CategoryName", "CategoryPrefix" },
                values: new object[,]
                {
                    { 1, "Accounting", "ACCT" },
                    { 2, "Agriculture", "AGRI" },
                    { 3, "Agriculture", "AGRM" },
                    { 4, "Anthropology", "ANTH" },
                    { 5, "Art", "ART" },
                    { 6, "Art Performance", "ARTP" },
                    { 7, "Astronomy", "ASTR" },
                    { 8, "Biology", "BIOL" },
                    { 9, "Business", "BUSN" },
                    { 10, "Chemistry", "CHEM" },
                    { 11, "Communications", "COMM" },
                    { 12, "Computer Info Tech", "CITC" },
                    { 13, "Computer Science", "CISP" },
                    { 14, "Criminal Justice", "CRMJ" },
                    { 15, "Culinary Arts", "CULA" },
                    { 16, "Digital Media", "DIGM" },
                    { 17, "Early Childhood Education", "ECED" },
                    { 18, "Economics", "ECON" },
                    { 19, "Education", "EDUC" },
                    { 20, "Electrical Engin Tech", "EETC" },
                    { 21, "Emergency Med Serv Para", "EMSP" },
                    { 22, "Emergency Med Service", "EMSA" },
                    { 23, "Emergency Med Service", "EMSB" },
                    { 24, "Engineering", "ENGR" },
                    { 25, "Engineering Systems Tech", "ENST" },
                    { 26, "Engineering Technology", "EGRT" },
                    { 27, "English", "ENGL" },
                    { 28, "Fire Science", "FIRE" },
                    { 29, "French", "FREN" },
                    { 30, "Geography", "GEOG" },
                    { 31, "Geology", "GEOL" },
                    { 32, "Health", "HLTH" },
                    { 33, "Health Information Management", "HIMT" },
                    { 34, "History", "HIST" },
                    { 35, "Hospitality Management", "HGMT" },
                    { 36, "Humanities", "HUM" },
                    { 37, "Information Systems", "INFS" },
                    { 38, "Mathematics", "MATH" },
                    { 39, "Music", "MUS" },
                    { 40, "Nursing", "NRSG" },
                    { 41, "Occupational Thrpy Asst", "OTAP" },
                    { 42, "Paralegal", "LEGL" },
                    { 43, "Pharmacy Technician", "PHRX" },
                    { 44, "Philosophy", "PHIL" },
                    { 45, "Physical Education", "PHED" },
                    { 46, "Physical Science", "PSCI" },
                    { 47, "Physical Therapist Asst", "PTAT" },
                    { 48, "Physics", "PHYS" },
                    { 49, "Political Science", "POLS" },
                    { 50, "Psychology", "PSYC" },
                    { 51, "Reading", "READ" },
                    { 52, "Religion", "RELS" },
                    { 53, "Respiratory Care", "RESP" },
                    { 54, "Social Work", "SWRK" },
                    { 55, "Sociology", "SOCI" },
                    { 56, "Spanish", "SPAN" },
                    { 57, "Special Education", "SPED" },
                    { 58, "Surgical Technology", "SURG" },
                    { 59, "Theatre", "THEA" },
                    { 60, "Women/Gender Studies", "WGST" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentID", "Address", "DateOfBirth", "Email", "EvaluationScore", "FirstName", "Gender", "GraduationDate", "LastName", "StartDate" },
                values: new object[,]
                {
                    { 1001, "123 Example St", new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "john.doe@example.com", 0, "John", "Male", new DateTime(2024, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Doe", new DateTime(2020, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1002, "456 Example Ave", new DateTime(1999, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "jane.smith@example.com", 0, "Jane", "Female", null, "Smith", new DateTime(2021, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Tests",
                columns: new[] { "TestID", "GradingScale", "TestName" },
                values: new object[,]
                {
                    { 1, 36, "ACT" },
                    { 2, 100, "Designated Test" }
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "CategoryID", "ClassID", "ClassName", "CreditHours", "IsRequired" },
                values: new object[,]
                {
                    { 1, 1010, "Principles of Accounting I", 3, false },
                    { 8, 2010, "Human Anatomy and Physiology I", 3, true }
                });

            migrationBuilder.InsertData(
                table: "StudentTests",
                columns: new[] { "AttemptNumber", "StudentID", "TestID", "Score" },
                values: new object[,]
                {
                    { 1, 1001, 1, 22 },
                    { 1, 1001, 2, 74 },
                    { 1, 1002, 2, 92 },
                    { 2, 1001, 2, 94 }
                });

            migrationBuilder.InsertData(
                table: "StudentClasses",
                columns: new[] { "CategoryID", "ClassID", "StudentID", "LetterGrade" },
                values: new object[,]
                {
                    { 1, 1010, 1001, "A" },
                    { 1, 1010, 1002, "A" },
                    { 8, 2010, 1001, "B" },
                    { 8, 2010, 1002, "C" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Classes_CategoryID",
                table: "Classes",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentClasses_StudentID",
                table: "StudentClasses",
                column: "StudentID");

            migrationBuilder.CreateIndex(
                name: "IX_StudentTests_StudentID",
                table: "StudentTests",
                column: "StudentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentClasses");

            migrationBuilder.DropTable(
                name: "StudentTests");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Tests");

            migrationBuilder.DropTable(
                name: "ClassCategories");
        }
    }
}
