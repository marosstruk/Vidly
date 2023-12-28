﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vidly.Migrations
{
    /// <inheritdoc />
    public partial class PopulateMembershipTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MembershipType",
                columns: ["Id", "SignUpFee", "DurationInMonths", "DiscountRate"],
                values: new object[,]
                {
                    { 1, 0, 0, 0 },
                    { 2, 30, 1, 10 },
                    { 3, 90, 3, 15 },
                    { 4, 300, 12, 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MembershipType",
                keyColumn: "Id",
                keyValues: [1, 2, 3, 4]);
        }
    }
}
