﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merancea.Migrations
{
    /// <inheritdoc />
    public partial class buttonupdate1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Buttons",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Buttons");
        }
    }
}
