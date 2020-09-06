using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCollection.Core.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    MiddleName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CountryRefId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Producers_Country_CountryRefId",
                        column: x => x.CountryRefId,
                        principalTable: "Country",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Author = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProducerRefId = table.Column<long>(nullable: false),
                    YearOfIssue = table.Column<int>(nullable: false),
                    Poster = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Producers_ProducerRefId",
                        column: x => x.ProducerRefId,
                        principalTable: "Producers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "RowVersion" },
                values: new object[] { 1L, null, null, false, null, "Россия", null });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "RowVersion" },
                values: new object[] { 2L, null, null, false, null, "США", null });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "RowVersion" },
                values: new object[] { 3L, null, null, false, null, "Великобритания", null });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "RowVersion" },
                values: new object[] { 4L, null, null, false, null, "Испания", null });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "RowVersion" },
                values: new object[] { 5L, null, null, false, null, "Германия", null });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "RowVersion" },
                values: new object[] { 6L, null, null, false, null, "Франция", null });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "Author", "CountryRefId", "DateOfBirth", "Deleted", "FirstName", "LastName", "MiddleName", "RowVersion" },
                values: new object[] { 1L, null, 2L, new DateTime(1963, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Квентино", "Тарантино", null, null });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Author", "Deleted", "Description", "Name", "Poster", "ProducerRefId", "RowVersion", "YearOfIssue" },
                values: new object[] { 1L, null, false, "", "Джанго освобожденный", "", 1L, null, 2012 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Author", "Deleted", "Description", "Name", "Poster", "ProducerRefId", "RowVersion", "YearOfIssue" },
                values: new object[] { 2L, null, false, "", "Криминальное чтиво", "", 1L, null, 1994 });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Author", "Deleted", "Description", "Name", "Poster", "ProducerRefId", "RowVersion", "YearOfIssue" },
                values: new object[] { 3L, null, false, "", "Бесславные ублюдки", "", 1L, null, 2009 });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_ProducerRefId",
                table: "Movies",
                column: "ProducerRefId");

            migrationBuilder.CreateIndex(
                name: "IX_Producers_CountryRefId",
                table: "Producers",
                column: "CountryRefId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
