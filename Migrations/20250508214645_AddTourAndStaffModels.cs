using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace TravelAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddTourAndStaffModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tours",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "tours",
                newName: "price_per_child");

            migrationBuilder.AddColumn<decimal>(
                name: "price_per_adult",
                table: "tours",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "room_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    capacity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_room_types", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "services",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_services", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tour_dates",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tour_id = table.Column<int>(type: "integer", nullable: false),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tour_dates", x => x.id);
                    table.ForeignKey(
                        name: "FK_tour_dates_tours_tour_id",
                        column: x => x.tour_id,
                        principalTable: "tours",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_tour_dates_tour_id",
                table: "tour_dates",
                column: "tour_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RoomTypeTour");

            migrationBuilder.DropTable(
                name: "ServiceTour");

            migrationBuilder.DropTable(
                name: "tour_dates");

            migrationBuilder.DropTable(
                name: "room_types");

            migrationBuilder.DropTable(
                name: "services");

            migrationBuilder.DropColumn(
                name: "price_per_adult",
                table: "tours");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tours",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "price_per_child",
                table: "tours",
                newName: "price");
        }
    }
}
