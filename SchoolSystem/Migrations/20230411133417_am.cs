using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class am : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
               name: "Status",
               table: "Holidays",
               type: "int",
               nullable: false,
               oldClrType: typeof(string),
               oldType: "nvarchar(max)");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
               name: "Status",
               table: "Holidays",
               type: "nvarchar(max)",
               nullable: false,
               oldClrType: typeof(int),
               oldType: "int");

        }
    }
}
