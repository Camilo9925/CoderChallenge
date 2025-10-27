using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoderChallenge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "unidadeAltura",
                table: "PatosPrimordiais",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "unidadePeso",
                table: "PatosPrimordiais",
                type: "varchar(10)",
                maxLength: 10,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "unidadeAltura",
                table: "PatosPrimordiais");

            migrationBuilder.DropColumn(
                name: "unidadePeso",
                table: "PatosPrimordiais");
        }
    }
}
