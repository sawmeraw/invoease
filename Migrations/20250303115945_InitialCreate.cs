using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace invoease.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameOnInvoice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ABN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdminEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactPersonName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsScheduled = table.Column<bool>(type: "bit", nullable: false),
                    ScheduledSendDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmailDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DueDate = table.Column<DateOnly>(type: "date", nullable: true),
                    IsDraft = table.Column<bool>(type: "bit", nullable: false),
                    Sent = table.Column<bool>(type: "bit", nullable: false),
                    TotalExcGST = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    TotalIncGST = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    IsRecurring = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Invoices_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ItemPrice = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Cancelled = table.Column<bool>(type: "bit", nullable: true),
                    IsMiscellaneous = table.Column<bool>(type: "bit", nullable: true),
                    ItemTotal = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IsRecurring = table.Column<bool>(type: "bit", nullable: true),
                    WorkDays = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceItems_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "ABN", "Email", "IsDeleted", "Name", "NameOnInvoice", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "12345678901", "alice.johnson@example.com", false, "Alice Johnson", "A. Johnson", "0412345678" },
                    { 2, "98765432109", "bob.smith@example.com", false, "Bob Smith", "B. Smith", "0498765432" },
                    { 3, "19283746509", "charlie.brown@example.com", false, "Charlie Brown", "C. Brown", "0423456789" },
                    { 4, "10293847567", "david.wilson@example.com", false, "David Wilson", "D. Wilson", "0434567890" },
                    { 5, "56473829102", "eve.white@example.com", false, "Eve White", "E. White", "0445678901" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "AdminEmail", "ContactPersonName", "Name", "PhoneNumber", "UserId" },
                values: new object[,]
                {
                    { 1, "clientA.admin@example.com", "John Doe", "Client A", "0456789012", 1 },
                    { 2, "clientB.admin@example.com", "Jane Smith", "Client B", "0467890123", 2 },
                    { 3, "clientC.admin@example.com", "Alice Green", "Client C", "0478901234", 3 },
                    { 4, "clientD.admin@example.com", "Michael Blue", "Client D", "0489012345", 4 },
                    { 5, "clientE.admin@example.com", "Eve Red", "Client E", "0490123456", 5 }
                });

            migrationBuilder.InsertData(
                table: "Invoices",
                columns: new[] { "Id", "ClientId", "CreatedAt", "Description", "DueDate", "EmailDescription", "InvoiceNumber", "IsDraft", "IsPaid", "IsRecurring", "IsScheduled", "IssueDate", "ScheduledSendDate", "Sent", "TotalExcGST", "TotalIncGST", "UserId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Invoice for client A", new DateOnly(2023, 1, 31), null, "INV001", false, false, false, false, new DateOnly(2023, 1, 1), null, true, 1000.00m, 1100.00m, 1 },
                    { 2, 2, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Invoice for client B", new DateOnly(2023, 1, 31), null, "INV002", false, false, false, false, new DateOnly(2023, 1, 1), null, true, 2000.00m, 2200.00m, 2 },
                    { 3, 3, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Invoice for client C", new DateOnly(2023, 1, 31), null, "INV003", false, false, false, false, new DateOnly(2023, 1, 1), null, true, 3000.00m, 3300.00m, 3 },
                    { 4, 4, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Invoice for client D", new DateOnly(2023, 1, 31), null, "INV004", false, false, false, false, new DateOnly(2023, 1, 1), null, true, 4000.00m, 4400.00m, 4 },
                    { 5, 5, new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Invoice for client E", new DateOnly(2023, 1, 31), null, "INV005", false, false, false, false, new DateOnly(2023, 1, 1), null, true, 5000.00m, 5500.00m, 5 }
                });

            migrationBuilder.InsertData(
                table: "InvoiceItems",
                columns: new[] { "Id", "Cancelled", "CreatedAt", "Description", "InvoiceId", "IsMiscellaneous", "IsRecurring", "ItemPrice", "ItemTotal", "Quantity", "WorkDays" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Item 1 for Invoice 1", 1, null, null, 100.00m, 100.00m, 1, "[]" },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Item 1 for Invoice 2", 2, null, null, 200.00m, 200.00m, 1, "[]" },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Item 1 for Invoice 3", 3, null, null, 300.00m, 300.00m, 1, "[]" },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Item 1 for Invoice 4", 4, null, null, 400.00m, 400.00m, 1, "[]" },
                    { 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Item 1 for Invoice 5", 5, null, null, 500.00m, 500.00m, 1, "[]" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItems_InvoiceId",
                table: "InvoiceItems",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_ClientId",
                table: "Invoices",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_UserId",
                table: "Invoices",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceItems");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
