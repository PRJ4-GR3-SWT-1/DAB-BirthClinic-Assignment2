using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicLibrary.Migrations
{
    public partial class AddedMidWifeToContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildPersonId",
                table: "Birth",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Birth_ChildPersonId",
                table: "Birth",
                column: "ChildPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Birth_Person_ChildPersonId",
                table: "Birth",
                column: "ChildPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Birth_Person_ChildPersonId",
                table: "Birth");

            migrationBuilder.DropIndex(
                name: "IX_Birth_ChildPersonId",
                table: "Birth");

            migrationBuilder.DropColumn(
                name: "ChildPersonId",
                table: "Birth");
        }
    }
}
