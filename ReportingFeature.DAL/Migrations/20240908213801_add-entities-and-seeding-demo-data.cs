using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ReportingFeature.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addentitiesandseedingdemodata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    BookingId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookingTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.BookingId);
                    table.ForeignKey(
                        name: "FK_Bookings_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookings_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BookingServices",
                columns: table => new
                {
                    BookingServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingServices", x => x.BookingServiceId);
                    table.ForeignKey(
                        name: "FK_BookingServices_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookingServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Bookings_BookingId",
                        column: x => x.BookingId,
                        principalTable: "Bookings",
                        principalColumn: "BookingId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "Address", "City", "Country", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Assuit Egypt", "Assuit", "Egypt", "Branch One", "01000000007" },
                    { 2, "Cairo Egypt", "Cairo", "Egypt", "Branch Two", "01000000003" },
                    { 3, "Alex Egypt", "Alex", "Egypt", "Branch Three", "01000000003" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "Address", "Birthdate", "City", "Country", "Email", "FirstName", "Gender", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "Assuit Egypt", new DateTime(1997, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Assuit", "Egypt", "Abdelazizahmed@gmail.com", "Abdelaziz", "Male", "Ahmed", "01000592507" },
                    { 2, "Cairo Egypt", new DateTime(1996, 10, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cairo", "Egypt", "KhaledMohamed@gmail.com", "Khaled", "Male", "Mohamed", "01200592507" },
                    { 3, "Alex Egypt", new DateTime(1995, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Alex", "Egypt", "TarekHassen@gmail.com", "Tarek", "Male", "Hassen", "01100592507" },
                    { 4, "Cairo Egypt", new DateTime(1993, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cairo", "Egypt", "MidoMoahmed@gmail.com", "Mido", "Male", "Moahmed", "01110592500" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ServiceId", "Description", "Duration", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Game Device per day Service Introduce For Client", 1, "Game Device", 5000m },
                    { 2, "Pool Service per day Introduce For Client", 1, "Pool", 10000m },
                    { 3, "Gym Service per day Introduce For Client", 1, "Gym", 8000m },
                    { 4, "Food Service per week Introduce For Client", 7, "Food", 20000m }
                });

            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "BookingDate", "BookingTime", "BranchId", "ClientId", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 12, 0, 0, 0), 1, 1, "Confirmed" },
                    { 2, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 11, 0, 0, 0), 2, 2, "Confirmed" },
                    { 3, new DateTime(2024, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 8, 0, 0, 0), 1, 3, "Confirmed" },
                    { 4, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 10, 0, 0, 0), 1, 4, "Confirmed" }
                });

            migrationBuilder.InsertData(
                table: "BookingServices",
                columns: new[] { "BookingServiceId", "BookingId", "Price", "ServiceId" },
                values: new object[,]
                {
                    { 1, 1, 20000m, 4 },
                    { 2, 1, 8000m, 3 },
                    { 3, 2, 8000m, 3 },
                    { 4, 2, 10000m, 2 },
                    { 5, 3, 5000m, 1 },
                    { 6, 3, 8000m, 3 },
                    { 7, 4, 20000m, 1 },
                    { 8, 4, 10000m, 2 }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "TransactionId", "Amount", "BookingId", "PaymentDate", "PaymentMethod" },
                values: new object[,]
                {
                    { 1, 28000m, 1, new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cash" },
                    { 2, 18000m, 2, new DateTime(2024, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visa" },
                    { 3, 13000m, 3, new DateTime(2024, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visa" },
                    { 4, 30000m, 4, new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Visa" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_BranchId",
                table: "Bookings",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ClientId",
                table: "Bookings",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingServices_BookingId",
                table: "BookingServices",
                column: "BookingId");

            migrationBuilder.CreateIndex(
                name: "IX_BookingServices_ServiceId",
                table: "BookingServices",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_BookingId",
                table: "Transactions",
                column: "BookingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingServices");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Branches");

            migrationBuilder.DropTable(
                name: "Clients");
        }
    }
}
