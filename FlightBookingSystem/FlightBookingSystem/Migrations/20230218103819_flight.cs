using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FlightBookingSystem.Migrations
{
    public partial class flight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flights",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Flight = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    To = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    From = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateAndTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fare = table.Column<float>(type: "real", nullable: false),
                    seatAvailable = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flights", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "registrations",
                columns: table => new
                {
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registrations", x => x.Email);
                });

            migrationBuilder.CreateTable(
                name: "bookings",
                columns: table => new
                {
                    Booking_id = table.Column<int>(type: "int", nullable: false),
                    Passenger_Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    City = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Country = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Passport_No = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    ReferenceNo = table.Column<int>(type: "int", nullable: false),
                    Flight_Id = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bookings", x => x.Booking_id);
                    table.ForeignKey(
                        name: "FK_bookings_Flights_Booking_id",
                        column: x => x.Booking_id,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_bookings_Flights_Flight_Id",
                        column: x => x.Flight_Id,
                        principalTable: "Flights",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_bookings_registrations_Email",
                        column: x => x.Email,
                        principalTable: "registrations",
                        principalColumn: "Email",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "checkins",
                columns: table => new
                {
                    Booking_id = table.Column<int>(type: "int", nullable: false),
                    CheckInId = table.Column<int>(type: "int", nullable: false),
                    Seat_Allocation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_checkins", x => x.Booking_id);
                    table.ForeignKey(
                        name: "FK_checkins_bookings_Booking_id",
                        column: x => x.Booking_id,
                        principalTable: "bookings",
                        principalColumn: "Booking_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bookings_Email",
                table: "bookings",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_bookings_Flight_Id",
                table: "bookings",
                column: "Flight_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "checkins");

            migrationBuilder.DropTable(
                name: "bookings");

            migrationBuilder.DropTable(
                name: "Flights");

            migrationBuilder.DropTable(
                name: "registrations");
        }
    }
}
