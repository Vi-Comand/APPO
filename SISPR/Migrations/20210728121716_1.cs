using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SISPR.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Forma_obuchen",
                columns: table => new
                {
                    forma_obuchen_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forma_obuchen", x => x.forma_obuchen_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Type_training_load",
                columns: table => new
                {
                    type_training_load_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    number_hours = table.Column<float>(type: "float", nullable: false),
                    number_groups = table.Column<float>(type: "float", nullable: false),
                    number_subgroups = table.Column<float>(type: "float", nullable: false),
                    number_control_forms = table.Column<float>(type: "float", nullable: false),
                    number_listeners = table.Column<float>(type: "float", nullable: false),
                    volume_hours = table.Column<float>(type: "float", nullable: false),
                    type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Type_training_load", x => x.type_training_load_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UTP_type_training_load",
                columns: table => new
                {
                    utp_type_training_load_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    utp_id = table.Column<int>(type: "int", nullable: false),
                    type_training_load_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UTP_type_training_load", x => x.utp_type_training_load_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UTPs",
                columns: table => new
                {
                    utp_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    hour = table.Column<float>(type: "float", nullable: false),
                    kol_groups = table.Column<int>(type: "int", nullable: false),
                    kol_slushatel_v_group = table.Column<int>(type: "int", nullable: false),
                    kol_subgroups = table.Column<int>(type: "int", nullable: false),
                    rejim_zanyati = table.Column<int>(type: "int", nullable: false),
                    forma_obuchen_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UTPs", x => x.utp_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forma_obuchen");

            migrationBuilder.DropTable(
                name: "Type_training_load");

            migrationBuilder.DropTable(
                name: "UTP_type_training_load");

            migrationBuilder.DropTable(
                name: "UTPs");
        }
    }
}
