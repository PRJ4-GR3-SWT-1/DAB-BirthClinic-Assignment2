using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BirthClinicLibrary.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BirthId = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Birth",
                columns: table => new
                {
                    BirthId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChildPersonId = table.Column<int>(type: "int", nullable: true),
                    BirthRoomRoomId = table.Column<int>(type: "int", nullable: true),
                    BirthRoomReservationStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BirthRoomReservationEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlannedStartTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Birth", x => x.BirthId);
                    table.ForeignKey(
                        name: "FK_Birth_Person_ChildPersonId",
                        column: x => x.ChildPersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Birth_Rooms_BirthRoomRoomId",
                        column: x => x.BirthRoomRoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Birth_BirthRoomRoomId",
                table: "Birth",
                column: "BirthRoomRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_Birth_ChildPersonId",
                table: "Birth",
                column: "ChildPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_BirthId",
                table: "Person",
                column: "BirthId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_RoomId",
                table: "Person",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Birth_BirthId",
                table: "Person",
                column: "BirthId",
                principalTable: "Birth",
                principalColumn: "BirthId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Birth_Person_ChildPersonId",
                table: "Birth");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Birth");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
