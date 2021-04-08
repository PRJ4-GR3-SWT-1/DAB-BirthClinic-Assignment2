using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicLibrary.Migrations
{
    public partial class clinicianDBset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Birth_Rooms_BirthRoomRoomId",
                table: "Birth");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Rooms_RoomId",
                table: "Person");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms");

            migrationBuilder.RenameTable(
                name: "Rooms",
                newName: "Room");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Person",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ClinicianPersonId",
                table: "Birth",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Room",
                table: "Room",
                column: "RoomId");

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
                name: "FK_Birth_Room_BirthRoomRoomId",
                table: "Birth",
                column: "BirthRoomRoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Room_RoomId",
                table: "Person",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Birth_Person_ClinicianPersonId",
                table: "Birth");

            migrationBuilder.DropForeignKey(
                name: "FK_Birth_Room_BirthRoomRoomId",
                table: "Birth");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Room_RoomId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Birth_ClinicianPersonId",
                table: "Birth");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Room",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ClinicianPersonId",
                table: "Birth");

            migrationBuilder.RenameTable(
                name: "Room",
                newName: "Rooms");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Rooms",
                table: "Rooms",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Birth_Rooms_BirthRoomRoomId",
                table: "Birth",
                column: "BirthRoomRoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Rooms_RoomId",
                table: "Person",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
