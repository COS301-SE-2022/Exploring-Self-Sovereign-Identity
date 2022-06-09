using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExploringSelfSovereignIdentityAPI.Migrations
{
    public partial class Migration_01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DefaultIdentityModel",
                columns: table => new
                {
                    IdentityName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HolderSignature = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DefaultIdentityModel", x => x.IdentityName);
                });

            migrationBuilder.CreateTable(
                name: "defaultSessionModel",
                columns: table => new
                {
                    SessionId = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    _identityIdentityName = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    otp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_defaultSessionModel", x => x.SessionId);
                    table.ForeignKey(
                        name: "FK_defaultSessionModel_DefaultIdentityModel__identityIdentityName",
                        column: x => x._identityIdentityName,
                        principalTable: "DefaultIdentityModel",
                        principalColumn: "IdentityName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_defaultSessionModel__identityIdentityName",
                table: "defaultSessionModel",
                column: "_identityIdentityName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "defaultSessionModel");

            migrationBuilder.DropTable(
                name: "DefaultIdentityModel");
        }
    }
}
