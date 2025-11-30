using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RainbowSix.Common.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    SessionId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaskedPhone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PlatformType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ticket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorAuthenticationTicket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProfileId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NameOnPlatform = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Environment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Expiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SpaceId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientIp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClientIpCountry = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServerTime = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RememberMeTicket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeGenerationPreference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeCommunicationPreference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.SessionId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessions");
        }
    }
}
