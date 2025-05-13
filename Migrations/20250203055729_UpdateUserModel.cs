using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TravelAppBackend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tours_TourId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Tours",
                table: "Tours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Tours",
                newName: "tours");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "bookings");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "users",
                newName: "email");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "users",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PasswordHash",
                table: "users",
                newName: "password_hash");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "users",
                newName: "last_name");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                table: "users",
                newName: "first_name");

            migrationBuilder.RenameIndex(
                name: "IX_Users_Email",
                table: "users",
                newName: "IX_users_email");

            migrationBuilder.RenameColumn(
                name: "Price",
                table: "tours",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "tours",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "tours",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "tours",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "tours",
                newName: "start_date");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "tours",
                newName: "end_date");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "bookings",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "bookings",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "TourId",
                table: "bookings",
                newName: "tour_id");

            migrationBuilder.RenameColumn(
                name: "BookingDate",
                table: "bookings",
                newName: "booking_date");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_UserId",
                table: "bookings",
                newName: "IX_bookings_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TourId",
                table: "bookings",
                newName: "IX_bookings_tour_id");

            migrationBuilder.AlterColumn<string>(
                name: "last_name",
                table: "users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "first_name",
                table: "users",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tours",
                table: "tours",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookings",
                table: "bookings",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_tours_tour_id",
                table: "bookings",
                column: "tour_id",
                principalTable: "tours",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_bookings_users_user_id",
                table: "bookings",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookings_tours_tour_id",
                table: "bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_bookings_users_user_id",
                table: "bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tours",
                table: "tours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookings",
                table: "bookings");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "tours",
                newName: "Tours");

            migrationBuilder.RenameTable(
                name: "bookings",
                newName: "Bookings");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Users",
                newName: "Email");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Users",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "password_hash",
                table: "Users",
                newName: "PasswordHash");

            migrationBuilder.RenameColumn(
                name: "last_name",
                table: "Users",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "first_name",
                table: "Users",
                newName: "FirstName");

            migrationBuilder.RenameIndex(
                name: "IX_users_email",
                table: "Users",
                newName: "IX_Users_Email");

            migrationBuilder.RenameColumn(
                name: "price",
                table: "Tours",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Tours",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Tours",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tours",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "start_date",
                table: "Tours",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "end_date",
                table: "Tours",
                newName: "EndDate");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Bookings",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "Bookings",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "tour_id",
                table: "Bookings",
                newName: "TourId");

            migrationBuilder.RenameColumn(
                name: "booking_date",
                table: "Bookings",
                newName: "BookingDate");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_user_id",
                table: "Bookings",
                newName: "IX_Bookings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_bookings_tour_id",
                table: "Bookings",
                newName: "IX_Bookings_TourId");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Tours",
                table: "Tours",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tours_TourId",
                table: "Bookings",
                column: "TourId",
                principalTable: "Tours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Users_UserId",
                table: "Bookings",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
