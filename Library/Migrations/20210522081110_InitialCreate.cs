using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Library.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenID = table.Column<int>(type: "INT", nullable: false),
                    GenTitle = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenID);
                });

            migrationBuilder.CreateTable(
                name: "Positions",
                columns: table => new
                {
                    PositionID = table.Column<int>(type: "INT", nullable: false),
                    PositionTitle = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Salary = table.Column<double>(type: "FLOAT", nullable: false),
                    Duties = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Demands = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Positions", x => x.PositionID);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    PubID = table.Column<int>(type: "INT", nullable: false),
                    PublicistTitle = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    City = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.PubID);
                });

            migrationBuilder.CreateTable(
                name: "Reader",
                columns: table => new
                {
                    ReadID = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Phone = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    PassportData = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reader", x => x.ReadID);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmpID = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    Gender = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Phone = table.Column<string>(type: "NVARCHAR(11)", nullable: false),
                    passportData = table.Column<string>(type: "NVARCHAR(10)", nullable: false),
                    PositionID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmpID);
                    table.ForeignKey(
                        name: "FK_Employee_Positions_PositionID",
                        column: x => x.PositionID,
                        principalTable: "Positions",
                        principalColumn: "PositionID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<int>(type: "INT", nullable: false),
                    BookTitle = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Author = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    PubYear = table.Column<DateTime>(type: "DATE", nullable: false),
                    GenID = table.Column<int>(type: "INT", nullable: false),
                    PubID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                    table.ForeignKey(
                        name: "FK_Books_Genres_GenID",
                        column: x => x.GenID,
                        principalTable: "Genres",
                        principalColumn: "GenID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Books_Publisher_PubID",
                        column: x => x.PubID,
                        principalTable: "Publisher",
                        principalColumn: "PubID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IssuedBooks",
                columns: table => new
                {
                    IssueDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "DATE", nullable: false),
                    ReturnMark = table.Column<DateTime>(type: "DATE", nullable: false),
                    EmpID = table.Column<int>(type: "INT", nullable: false),
                    ReadID = table.Column<int>(type: "INT", nullable: false),
                    BookID = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_IssuedBooks_Books_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "BookID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssuedBooks_Employee_EmpID",
                        column: x => x.EmpID,
                        principalTable: "Employee",
                        principalColumn: "EmpID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_IssuedBooks_Reader_ReadID",
                        column: x => x.ReadID,
                        principalTable: "Reader",
                        principalColumn: "ReadID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_GenID",
                table: "Books",
                column: "GenID");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PubID",
                table: "Books",
                column: "PubID");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PositionID",
                table: "Employee",
                column: "PositionID");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedBooks_BookID",
                table: "IssuedBooks",
                column: "BookID");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedBooks_EmpID",
                table: "IssuedBooks",
                column: "EmpID");

            migrationBuilder.CreateIndex(
                name: "IX_IssuedBooks_ReadID",
                table: "IssuedBooks",
                column: "ReadID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssuedBooks");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Reader");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "Positions");
        }
    }
}
