using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicLibrary.Migrations
{
    public partial class birthclinician : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Birth_Person_ClinicianPersonId",
                table: "Birth");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Birth_BirthId1",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Birth_ClinicianPersonId",
                table: "Birth");

            migrationBuilder.DropColumn(
                name: "ClinicianPersonId",
                table: "Birth");

            migrationBuilder.RenameColumn(
                name: "BirthId1",
                table: "Person",
                newName: "FatherPersonId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_BirthId1",
                table: "Person",
                newName: "IX_Person_FatherPersonId");

            migrationBuilder.CreateTable(
                name: "ClinicianBirth",
                columns: table => new
                {
                    ClinicianBirthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BirthId = table.Column<int>(type: "int", nullable: true),
                    ClinicianPersonId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClinicianBirth", x => x.ClinicianBirthId);
                    table.ForeignKey(
                        name: "FK_ClinicianBirth_Birth_BirthId",
                        column: x => x.BirthId,
                        principalTable: "Birth",
                        principalColumn: "BirthId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClinicianBirth_Person_ClinicianPersonId",
                        column: x => x.ClinicianPersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClinicianBirth_BirthId",
                table: "ClinicianBirth",
                column: "BirthId");

            migrationBuilder.CreateIndex(
                name: "IX_ClinicianBirth_ClinicianPersonId",
                table: "ClinicianBirth",
                column: "ClinicianPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_FatherPersonId",
                table: "Person",
                column: "FatherPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_FatherPersonId",
                table: "Person");

            migrationBuilder.DropTable(
                name: "ClinicianBirth");

            migrationBuilder.RenameColumn(
                name: "FatherPersonId",
                table: "Person",
                newName: "BirthId1");

            migrationBuilder.RenameIndex(
                name: "IX_Person_FatherPersonId",
                table: "Person",
                newName: "IX_Person_BirthId1");

            migrationBuilder.AddColumn<int>(
                name: "ClinicianPersonId",
                table: "Birth",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Birth_ClinicianPersonId",
                table: "Birth",
                column: "ClinicianPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Birth_Person_ClinicianPersonId",
                table: "Birth",
                column: "ClinicianPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Birth_BirthId1",
                table: "Person",
                column: "BirthId1",
                principalTable: "Birth",
                principalColumn: "BirthId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
