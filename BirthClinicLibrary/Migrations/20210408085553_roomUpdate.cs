using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicLibrary.Migrations
{
    public partial class roomUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Room_RoomId",
                table: "Person");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Person",
                newName: "RestingRoomRoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_RoomId",
                table: "Person",
                newName: "IX_Person_RestingRoomRoomId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Room",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RoomName",
                table: "Room",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ActualBirthTime",
                table: "Person",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BirthId1",
                table: "Person",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ChildPersonId",
                table: "Person",
                type: "int",
                nullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "MotherPersonId",
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
                name: "BirthRoomRoomId1",
                table: "Birth",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Person_BirthId1",
                table: "Person",
                column: "BirthId1");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ChildPersonId",
                table: "Person",
                column: "ChildPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_MaternityRoomRoomId",
                table: "Person",
                column: "MaternityRoomRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_MotherPersonId",
                table: "Person",
                column: "MotherPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Birth_BirthRoomRoomId1",
                table: "Birth",
                column: "BirthRoomRoomId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Birth_Room_BirthRoomRoomId1",
                table: "Birth",
                column: "BirthRoomRoomId1",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Birth_BirthId1",
                table: "Person",
                column: "BirthId1",
                principalTable: "Birth",
                principalColumn: "BirthId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_ChildPersonId",
                table: "Person",
                column: "ChildPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Person_MotherPersonId",
                table: "Person",
                column: "MotherPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Birth_Room_BirthRoomRoomId1",
                table: "Birth");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Birth_BirthId1",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_ChildPersonId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Person_MotherPersonId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Room_MaternityRoomRoomId",
                table: "Person");

            migrationBuilder.DropForeignKey(
                name: "FK_Person_Room_RestingRoomRoomId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_BirthId1",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_ChildPersonId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_MaternityRoomRoomId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Person_MotherPersonId",
                table: "Person");

            migrationBuilder.DropIndex(
                name: "IX_Birth_BirthRoomRoomId1",
                table: "Birth");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "RoomName",
                table: "Room");

            migrationBuilder.DropColumn(
                name: "ActualBirthTime",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "BirthId1",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "ChildPersonId",
                table: "Person");

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
                name: "MotherPersonId",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "RestingRoomReservationEnd",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "RestingRoomReservationStart",
                table: "Person");

            migrationBuilder.DropColumn(
                name: "BirthRoomRoomId1",
                table: "Birth");

            migrationBuilder.RenameColumn(
                name: "RestingRoomRoomId",
                table: "Person",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Person_RestingRoomRoomId",
                table: "Person",
                newName: "IX_Person_RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Room_RoomId",
                table: "Person",
                column: "RoomId",
                principalTable: "Room",
                principalColumn: "RoomId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
