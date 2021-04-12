using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicLibrary.Migrations
{
    public partial class child_child_in_birth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Birth_BirthId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_BirthId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "BirthId",
                table: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BirthId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_BirthId",
                table: "Person",
                column: "BirthId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Birth_BirthId",
                table: "Person",
                column: "BirthId",
                principalTable: "Birth",
                principalColumn: "BirthId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
