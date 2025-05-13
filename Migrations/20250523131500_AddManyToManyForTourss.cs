using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddManyToManyForTourss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_tours_TourId1",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_users_UserId1",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_room_types_tours_TourId",
                table: "room_types");

            migrationBuilder.DropForeignKey(
                name: "FK_services_tours_TourId",
                table: "services");

            migrationBuilder.DropIndex(
                name: "IX_services_TourId",
                table: "services");

            migrationBuilder.DropIndex(
                name: "IX_room_types_TourId",
                table: "room_types");

            migrationBuilder.DropIndex(
                name: "IX_bookings_TourId1",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_UserId1",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "room_types");

            migrationBuilder.DropColumn(
                name: "TourId1",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "bookings");

            migrationBuilder.CreateTable(
                name: "tour_room_types",
                columns: table => new
                {
                    RoomTypeId = table.Column<int>(type: "integer", nullable: false),
                    TourId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tour_room_types", x => new { x.RoomTypeId, x.TourId });
                    table.ForeignKey(
                        name: "FK_tour_room_types_room_types_RoomTypeId",
                        column: x => x.RoomTypeId,
                        principalTable: "room_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tour_room_types_tours_TourId",
                        column: x => x.TourId,
                        principalTable: "tours",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tour_services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "integer", nullable: false),
                    TourId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tour_services", x => new { x.ServiceId, x.TourId });
                    table.ForeignKey(
                        name: "FK_tour_services_services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tour_services_tours_TourId",
                        column: x => x.TourId,
                        principalTable: "tours",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tour_room_types_TourId",
                table: "tour_room_types",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_tour_services_TourId",
                table: "tour_services",
                column: "TourId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tour_room_types");

            migrationBuilder.DropTable(
                name: "tour_services");

            migrationBuilder.AddColumn<int>(
                name: "TourId",
                table: "services",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TourId",
                table: "room_types",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TourId1",
                table: "bookings",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "bookings",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_services_TourId",
                table: "services",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_room_types_TourId",
                table: "room_types",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_TourId1",
                table: "bookings",
                column: "TourId1");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_UserId1",
                table: "bookings",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_tours_TourId1",
                table: "bookings",
                column: "TourId1",
                principalTable: "tours",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_users_UserId1",
                table: "bookings",
                column: "UserId1",
                principalTable: "users",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_room_types_tours_TourId",
                table: "room_types",
                column: "TourId",
                principalTable: "tours",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_services_tours_TourId",
                table: "services",
                column: "TourId",
                principalTable: "tours",
                principalColumn: "id");
        }
    }
}
