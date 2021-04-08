using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicLibrary.Migrations
{
    public partial class mother : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_ChildPersonId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_ChildPersonId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ChildPersonId",
                table: "Person");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChildPersonId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_ChildPersonId",
                table: "Person",
                column: "ChildPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_ChildPersonId",
                table: "Person",
                column: "ChildPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
