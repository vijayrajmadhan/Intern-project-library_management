using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YtBookStore.Migrations
{
    /// <inheritdoc />
    public partial class three : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Numberofbook",
                table: "Book",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Numberofbook",
                table: "Book");
        }
    }
}
