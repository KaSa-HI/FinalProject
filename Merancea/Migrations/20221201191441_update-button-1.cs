using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Merancea.Migrations
{
    /// <inheritdoc />
    public partial class updatebutton1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DestinationPageId",
                table: "Buttons",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Buttons_DestinationPageId",
                table: "Buttons",
                column: "DestinationPageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Buttons_Pages_DestinationPageId",
                table: "Buttons",
                column: "DestinationPageId",
                principalTable: "Pages",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Buttons_Pages_DestinationPageId",
                table: "Buttons");

            migrationBuilder.DropIndex(
                name: "IX_Buttons_DestinationPageId",
                table: "Buttons");

            migrationBuilder.DropColumn(
                name: "DestinationPageId",
                table: "Buttons");
        }
    }
}
