using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Infrastructure.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BenefitPolicies",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeCostPerYear = table.Column<double>(nullable: false),
                    DependentCostPerYear = table.Column<double>(nullable: false),
                    LetterToDiscount = table.Column<string>(nullable: false),
                    DiscountAmount = table.Column<double>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    ChecksPerYear = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BenefitPolicies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    Salary = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Dependents",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    Relationship = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependents", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Dependents_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Paychecks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BaseSalary = table.Column<double>(nullable: false),
                    SalaryAfterDeductions = table.Column<double>(nullable: false),
                    EmployeeID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paychecks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Paychecks_Employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "BenefitPolicies",
                columns: new[] { "ID", "ChecksPerYear", "DependentCostPerYear", "DiscountAmount", "EmployeeCostPerYear", "IsActive", "LetterToDiscount" },
                values: new object[] { 1, 0, 500.0, 0.10000000000000001, 1000.0, false, "A" });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID", "FirstName", "LastName", "Salary" },
                values: new object[] { 1, "Johnny", "Donuts", 2000.0 });

            migrationBuilder.CreateIndex(
                name: "IX_Dependents_EmployeeID",
                table: "Dependents",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Paychecks_EmployeeID",
                table: "Paychecks",
                column: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BenefitPolicies");

            migrationBuilder.DropTable(
                name: "Dependents");

            migrationBuilder.DropTable(
                name: "Paychecks");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
