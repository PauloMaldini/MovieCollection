using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MovieCollection.Core.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Author = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    RowVersion = table.Column<byte[]>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProducerRefId = table.Column<long>(nullable: false),
                    YearOfIssue = table.Column<int>(nullable: false),
                    PosterFileName = table.Column<string>(nullable: true)
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
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "1", 0, "aa04567c-552f-44a4-a335-aacce689f21c", null, false, false, null, null, "USER1", "AQAAAAEAACcQAAAAECrE5NOp5nDc3kYd5M+lz02CXZ5CReTikJPORCAGtRxEmc7MNpu8XCE6AE/IlxbS0Q==", null, false, "d86c8c49-abde-4815-a256-5340c6efbe1d", false, "user1" },
                    { "2", 0, "905ac45d-386e-4986-b74f-f39644cffae7", null, false, false, null, null, "USER2", "AQAAAAEAACcQAAAAEOSP5tEbUIhIatbyvv7+nIa7HuyoEGvoYcwWEpYx19krTn98HxoTLl9zzKxj6IbGVA==", null, false, "abd6583c-77b8-4016-9982-e7f64c27ec93", false, "user2" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "Id", "Author", "Code", "Deleted", "Description", "Name", "RowVersion" },
                values: new object[,]
                {
                    { 1L, null, null, false, null, "Россия", null },
                    { 2L, null, null, false, null, "США", null },
                    { 3L, null, null, false, null, "Великобритания", null },
                    { 4L, null, null, false, null, "Испания", null },
                    { 5L, null, null, false, null, "Германия", null },
                    { 6L, null, null, false, null, "Франция", null }
                });

            migrationBuilder.InsertData(
                table: "Producers",
                columns: new[] { "Id", "Author", "CountryRefId", "DateOfBirth", "Deleted", "FirstName", "LastName", "MiddleName", "RowVersion" },
                values: new object[,]
                {
                    { 1L, null, 2L, new DateTime(1963, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Квентино", "Тарантино", null, null },
                    { 2L, null, 2L, new DateTime(1946, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Стивен", "Спилберг", null, null },
                    { 3L, null, 6L, new DateTime(1959, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Фрэнк", "Дарабонт", null, null },
                    { 4L, null, 6L, new DateTime(1974, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Кристиан", "Альварт", null, null },
                    { 5L, null, 6L, new DateTime(1954, 8, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), false, "Джеймс", "Кэмерон", null, null }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Author", "Deleted", "Description", "Name", "PosterFileName", "ProducerRefId", "RowVersion", "YearOfIssue" },
                values: new object[,]
                {
                    { 1L, "user1", false, "", "Джанго освобожденный", "85157a5959894d3092f8a1cfb30cfcb5.png", 1L, null, 2012 },
                    { 2L, "user1", false, "", "Криминальное чтиво", "315d7e86ce92407886629fcec8e18fab.jpg", 1L, null, 1994 },
                    { 3L, "user2", false, "", "Бесславные ублюдки", "acdd66d16b944e25bfdd33249790ed2d.jpg", 1L, null, 2009 },
                    { 5L, "user1", false, "", "Спасти рядового Райана", "fc7c8ae1d2c942d79958882086735ccd.png", 2L, null, 1998 },
                    { 6L, "user1", false, "", "Инопланетянин", "b119a9c2ead8460f958106540b1fecbe.jpg", 2L, null, 1982 },
                    { 4L, "user2", false, "", "Побег из шоушенка", "ed952073c9f24e49a80f6cceb3cc9ba.jpg", 3L, null, 1994 },
                    { 7L, "user1", false, "", "Пандорум", "ffcd5ad118c74dafaac7b137607147d5.jpg", 4L, null, 2009 },
                    { 8L, "user2", false, "", "Терминатор", "9fadd792f1e94344a9138edf058ce9ab.jpg", 5L, null, 1984 },
                    { 9L, "user2", false, "", "Чужие", "274b54c8be6c42b5a39afad70b43b6c1.jpg", 5L, null, 1986 },
                    { 10L, "user1", false, "", "Терминатор 2: Судный день", "1a3a4c6c458c43a1bdf42da31932e789.jpg", 5L, null, 1991 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

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
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Producers");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
