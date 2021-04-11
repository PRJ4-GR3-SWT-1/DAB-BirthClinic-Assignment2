using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicLibrary.Migrations
{
    public partial class ListFamilyMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_FatherPersonId",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "FatherPersonId",
                table: "Person",
                newName: "ChildPersonId");

            migrationBuilder.RenameColumn(
                name: "ActualBirthTime",
                table: "Person",
                newName: "Birthday");

            migrationBuilder.RenameIndex(
                name: "IX_Person_FatherPersonId",
                table: "Person",
                newName: "IX_Person_ChildPersonId");

            migrationBuilder.AddColumn<string>(
                name: "Relation",
                table: "Person",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_ChildPersonId",
                table: "Person",
                column: "ChildPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_ChildPersonId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "Relation",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "ChildPersonId",
                table: "Person",
                newName: "FatherPersonId");

            migrationBuilder.RenameColumn(
                name: "Birthday",
                table: "Person",
                newName: "ActualBirthTime");

            migrationBuilder.RenameIndex(
                name: "IX_Person_ChildPersonId",
                table: "Person",
                newName: "IX_Person_FatherPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_FatherPersonId",
                table: "Person",
                column: "FatherPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
