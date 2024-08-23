using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace test_dotnet_app.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AvatarUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetPasswordToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResetPasswordTokenExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1903), "Sales", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1913) },
                    { 2, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1916), "Marketing", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1916) },
                    { 3, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1917), "Engineering", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1918) },
                    { 4, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1919), "Finance", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1919) },
                    { 5, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1920), "HR", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1920) },
                    { 6, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1921), "IT", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1921) },
                    { 7, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1922), "Operations", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1922) },
                    { 8, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1923), "Product Management", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1924) },
                    { 9, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1924), "Quality Assurance", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1925) },
                    { 10, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1926), "R&D", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1926) },
                    { 11, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1930), "Sales Support", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1930) },
                    { 12, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1931), "Training & Development", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1932) }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "CreatedAt", "DepartmentId", "FirstName", "LastName", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2346), 1, "John", "Doe", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2348) },
                    { 2, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2351), 2, "Jane", "Smith", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2351) },
                    { 3, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2352), 3, "Mike", "Johnson", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2352) },
                    { 4, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2353), 4, "Sarah", "Wilson", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2354) },
                    { 5, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2390), 5, "Michael", "Davis", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2391) },
                    { 6, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2392), 6, "Emily", "Thompson", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2392) },
                    { 7, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2393), 7, "Daniel", "Brown", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2393) },
                    { 8, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2394), 8, "Sarah", "Evans", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2394) },
                    { 9, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2395), 9, "Max", "Evans", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2396) },
                    { 10, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2396), 10, "Emily", "Evans", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2397) },
                    { 11, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2398), 11, "Micky", "Evans", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2398) },
                    { 12, new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2399), 12, "Kyle", "Evans", new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2399) }
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
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");
        }

        /// <inheritdoc />
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
                name: "Employees");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
