using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicLibrary.Migrations
{
    public partial class reservations4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Birth_Room_BirthRoomRoomId",
                table: "Birth");

            migrationBuilder.DropForeignKey(
                name: "FK_Birth_Room_BirthRoomRoomId1",
                table: "Birth");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Room_MaternityRoomRoomId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Room_RestingRoomRoomId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_MaternityRoomRoomId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_RestingRoomRoomId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Birth_BirthRoomRoomId",
                table: "Birth");

            migrationBuilder.DropIndex(
                name: "IX_Birth_BirthRoomRoomId1",
                table: "Birth");

            migrationBuilder.DropColumn(
                name: "MaternityRoomReservationEnd",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MaternityRoomReservationStart",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "MaternityRoomRoomId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "RestingRoomReservationEnd",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "RestingRoomReservationStart",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "RestingRoomRoomId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "BirthRoomReservationEnd",
                table: "Birth");

            migrationBuilder.DropColumn(
                name: "BirthRoomReservationStart",
                table: "Birth");

            migrationBuilder.DropColumn(
                name: "BirthRoomRoomId",
                table: "Birth");

            migrationBuilder.DropColumn(
                name: "BirthRoomRoomId1",
                table: "Birth");

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservedRoomRoomId = table.Column<int>(type: "int", nullable: true),
                    UserPersonId = table.Column<int>(type: "int", nullable: true),
                    ReservationStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReservationEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservation_Person_UserPersonId",
                        column: x => x.UserPersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_Room_ReservedRoomRoomId",
                        column: x => x.ReservedRoomRoomId,
                        principalTable: "Room",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ReservedRoomRoomId",
                table: "Reservation",
                column: "ReservedRoomRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserPersonId",
                table: "Reservation",
                column: "UserPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.AddColumn<DateTime>(
                name: "MaternityRoomReservationEnd",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "MaternityRoomReservationStart",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MaternityRoomRoomId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestingRoomReservationEnd",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RestingRoomReservationStart",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RestingRoomRoomId",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthRoomReservationEnd",
                table: "Birth",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthRoomReservationStart",
                table: "Birth",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "BirthRoomRoomId",
                table: "Birth",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BirthRoomRoomId1",
                table: "Birth",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_MaternityRoomRoomId",
                table: "Person",
                column: "MaternityRoomRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_RestingRoomRoomId",
                table: "Person",
                column: "RestingRoomRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Birth_BirthRoomRoomId",
                table: "Birth",
                column: "BirthRoomRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Birth_BirthRoomRoomId1",
                table: "Birth",
                column: "BirthRoomRoomId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Birth_Room_BirthRoomRoomId",
                table: "Birth",
                column: "BirthRoomRoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Birth_Room_BirthRoomRoomId1",
                table: "Birth",
                column: "BirthRoomRoomId1",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Room_MaternityRoomRoomId",
                table: "Person",
                column: "MaternityRoomRoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Room_RestingRoomRoomId",
                table: "Person",
                column: "RestingRoomRoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
