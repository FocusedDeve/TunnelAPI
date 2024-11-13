using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TunnelAPI.Migrations
{
    /// <inheritdoc />
    public partial class BigMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RendezVous",
                table: "RendezVous");

            migrationBuilder.AlterColumn<string>(
                name: "CodeClient",
                table: "RendezVous",
                type: "varchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(255)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "RendezVousId",
                table: "RendezVous",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_RendezVous",
                table: "RendezVous",
                column: "RendezVousId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_RendezVous",
                table: "RendezVous");

            migrationBuilder.DropColumn(
                name: "RendezVousId",
                table: "RendezVous");

            migrationBuilder.AlterColumn<string>(
                name: "CodeClient",
                table: "RendezVous",
                type: "varchar(255)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(10)",
                oldMaxLength: 10)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RendezVous",
                table: "RendezVous",
                column: "CodeClient");
        }
    }
}
