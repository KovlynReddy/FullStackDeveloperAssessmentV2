using Microsoft.EntityFrameworkCore.Migrations;

namespace FullStackDeveloperAssessment.Migrations
{
    public partial class LocationsDBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImageModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    venueid = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    prefix = table.Column<string>(nullable: true),
                    suffix = table.Column<string>(nullable: true),
                    width = table.Column<string>(nullable: true),
                    height = table.Column<string>(nullable: true),
                    location = table.Column<string>(nullable: true),
                    meta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageModel", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "LocationModel",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    photoid = table.Column<string>(nullable: true),
                    lat = table.Column<string>(nullable: true),
                    lng = table.Column<string>(nullable: true),
                    meta = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationModel", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImageModel");

            migrationBuilder.DropTable(
                name: "LocationModel");
        }
    }
}
