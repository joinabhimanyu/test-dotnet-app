using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test_dotnet_app.Migrations
{
    /// <inheritdoc />
    public partial class RemovedFullNameFromEmployeeEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6753), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6764) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6771), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6771) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6772), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6773) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6774), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6774) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6775), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6775) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6776), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6777) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6777), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6778) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6779), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6779) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6780), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6780) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6781), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6782) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6784), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6784) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6785), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(6785) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7208), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7210) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7212), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7213) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7214), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7214) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7215), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7216) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7217), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7217) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7218), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7218) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7219), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7220) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7220), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7221) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7222), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7222) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7223), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7224) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7225), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7225) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7226), new DateTime(2024, 8, 24, 10, 49, 45, 577, DateTimeKind.Local).AddTicks(7226) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1903), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1913) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1916), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1916) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1917), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1918) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1919), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1919) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1920), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1920) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1921), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1921) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1922), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1922) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1923), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1924) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1924), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1925) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1926), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1926) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1930), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1930) });

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1931), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(1932) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2346), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2348) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2351), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2351) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2352), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2352) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2353), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2354) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2390), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2391) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2392), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2392) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 7,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2393), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2393) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 8,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2394), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2394) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 9,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2395), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2396) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2396), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2397) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2398), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2398) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 12,
                columns: new[] { "CreatedAt", "UpdatedAt" },
                values: new object[] { new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2399), new DateTime(2024, 8, 23, 22, 47, 24, 797, DateTimeKind.Local).AddTicks(2399) });
        }
    }
}
