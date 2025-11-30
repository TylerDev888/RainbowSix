using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RainbowSix.Common.Database.Migrations
{
    /// <inheritdoc />
    public partial class _2025_09_27_SessionAddsUsername : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Username",
                table: "Sessions",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Username",
                table: "Sessions");
        }
    }
}
