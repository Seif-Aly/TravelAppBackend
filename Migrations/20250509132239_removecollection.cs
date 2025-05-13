using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class removecollection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomTypeTour");

            migrationBuilder.DropTable(
                name: "ServiceTour");

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

            migrationBuilder.CreateIndex(
                name: "IX_services_TourId",
                table: "services",
                column: "TourId");

            migrationBuilder.CreateIndex(
                name: "IX_room_types_TourId",
                table: "room_types",
                column: "TourId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "services");

            migrationBuilder.DropColumn(
                name: "TourId",
                table: "room_types");

            migrationBuilder.CreateTable(
                name: "RoomTypeTour",
                columns: table => new
                {
                    RoomsId = table.Column<int>(type: "integer", nullable: false),
                    ToursId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypeTour", x => new { x.RoomsId, x.ToursId });
                    table.ForeignKey(
                        name: "FK_RoomTypeTour_room_types_RoomsId",
                        column: x => x.RoomsId,
                        principalTable: "room_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoomTypeTour_tours_ToursId",
                        column: x => x.ToursId,
                        principalTable: "tours",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTour",
                columns: table => new
                {
                    ServicesId = table.Column<int>(type: "integer", nullable: false),
                    ToursId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTour", x => new { x.ServicesId, x.ToursId });
                    table.ForeignKey(
                        name: "FK_ServiceTour_services_ServicesId",
                        column: x => x.ServicesId,
                        principalTable: "services",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServiceTour_tours_ToursId",
                        column: x => x.ToursId,
                        principalTable: "tours",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RoomTypeTour_ToursId",
                table: "RoomTypeTour",
                column: "ToursId");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTour_ToursId",
                table: "ServiceTour",
                column: "ToursId");
        }
    }
}
