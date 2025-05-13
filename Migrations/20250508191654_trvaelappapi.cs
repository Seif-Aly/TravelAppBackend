using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class trvaelappapi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "end_date",
                table: "tours");

            migrationBuilder.DropColumn(
                name: "start_date",
                table: "tours");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "tours",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "tours",
                newName: "weather_state");

            migrationBuilder.AddColumn<string>(
                name: "country",
                table: "tours",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "distance_km",
                table: "tours",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "duration_days",
                table: "tours",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "image_url",
                table: "tours",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "rating_count",
                table: "tours",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<double>(
                name: "rating_value",
                table: "tours",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "temperature_c",
                table: "tours",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "title",
                table: "tours",
                type: "text",
                nullable: false,
                defaultValue: "");

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
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_users_UserId1",
                table: "bookings",
                column: "UserId1",
                principalTable: "users",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_tours_TourId1",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_users_UserId1",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_TourId1",
                table: "bookings");

            migrationBuilder.DropIndex(
                name: "IX_bookings_UserId1",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "country",
                table: "tours");

            migrationBuilder.DropColumn(
                name: "distance_km",
                table: "tours");

            migrationBuilder.DropColumn(
                name: "duration_days",
                table: "tours");

            migrationBuilder.DropColumn(
                name: "image_url",
                table: "tours");

            migrationBuilder.DropColumn(
                name: "rating_count",
                table: "tours");

            migrationBuilder.DropColumn(
                name: "rating_value",
                table: "tours");

            migrationBuilder.DropColumn(
                name: "temperature_c",
                table: "tours");

            migrationBuilder.DropColumn(
                name: "title",
                table: "tours");

            migrationBuilder.DropColumn(
                name: "TourId1",
                table: "bookings");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "bookings");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tours",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "weather_state",
                table: "tours",
                newName: "name");

            migrationBuilder.AddColumn<DateTime>(
                name: "end_date",
                table: "tours",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "start_date",
                table: "tours",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
