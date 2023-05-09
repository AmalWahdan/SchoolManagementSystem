using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolSystem.Migrations
{
    /// <inheritdoc />
    public partial class Addrelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userID_fk",
                table: "Holidays",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userID_fk",
                table: "Feedbacks",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "levelID_fk",
                table: "Classes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "userID_fk",
                table: "Attendances",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "classID_fk",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "levelID_fk",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Holidays_userID_fk",
                table: "Holidays",
                column: "userID_fk");

            migrationBuilder.CreateIndex(
                name: "IX_Feedbacks_userID_fk",
                table: "Feedbacks",
                column: "userID_fk");

            migrationBuilder.CreateIndex(
                name: "IX_Classes_levelID_fk",
                table: "Classes",
                column: "levelID_fk");

            migrationBuilder.CreateIndex(
                name: "IX_Attendances_userID_fk",
                table: "Attendances",
                column: "userID_fk");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_classID_fk",
                table: "AspNetUsers",
                column: "classID_fk");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_levelID_fk",
                table: "AspNetUsers",
                column: "levelID_fk");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Classes_classID_fk",
                table: "AspNetUsers",
                column: "classID_fk",
                principalTable: "Classes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Levels_levelID_fk",
                table: "AspNetUsers",
                column: "levelID_fk",
                principalTable: "Levels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Attendances_AspNetUsers_userID_fk",
                table: "Attendances",
                column: "userID_fk",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Classes_Levels_levelID_fk",
                table: "Classes",
                column: "levelID_fk",
                principalTable: "Levels",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Feedbacks_AspNetUsers_userID_fk",
                table: "Feedbacks",
                column: "userID_fk",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Holidays_AspNetUsers_userID_fk",
                table: "Holidays",
                column: "userID_fk",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Classes_classID_fk",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Levels_levelID_fk",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Attendances_AspNetUsers_userID_fk",
                table: "Attendances");

            migrationBuilder.DropForeignKey(
                name: "FK_Classes_Levels_levelID_fk",
                table: "Classes");

            migrationBuilder.DropForeignKey(
                name: "FK_Feedbacks_AspNetUsers_userID_fk",
                table: "Feedbacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Holidays_AspNetUsers_userID_fk",
                table: "Holidays");

            migrationBuilder.DropIndex(
                name: "IX_Holidays_userID_fk",
                table: "Holidays");

            migrationBuilder.DropIndex(
                name: "IX_Feedbacks_userID_fk",
                table: "Feedbacks");

            migrationBuilder.DropIndex(
                name: "IX_Classes_levelID_fk",
                table: "Classes");

            migrationBuilder.DropIndex(
                name: "IX_Attendances_userID_fk",
                table: "Attendances");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_classID_fk",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_levelID_fk",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "userID_fk",
                table: "Holidays");

            migrationBuilder.DropColumn(
                name: "userID_fk",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "levelID_fk",
                table: "Classes");

            migrationBuilder.DropColumn(
                name: "userID_fk",
                table: "Attendances");

            migrationBuilder.DropColumn(
                name: "classID_fk",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "levelID_fk",
                table: "AspNetUsers");
        }
    }
}
