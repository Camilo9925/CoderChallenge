using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CoderChallenge.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Precisoes",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    valor = table.Column<float>(type: "float", nullable: false),
                    unidadeOriginal = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    valorEmMetros = table.Column<float>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precisoes", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Superpoderes",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    nome = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    descricao = table.Column<string>(type: "text", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    classificacoes = table.Column<string>(type: "json", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Superpoderes", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Localizacoes",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cidade = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pais = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    latitude = table.Column<double>(type: "double", nullable: false),
                    longitude = table.Column<double>(type: "double", nullable: false),
                    precisao_id = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    pontoReferenciaConhecido = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localizacoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Localizacoes_Precisoes_precisao_id",
                        column: x => x.precisao_id,
                        principalTable: "Precisoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Drones",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    numeroSerie = table.Column<string>(type: "varchar(64)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    marca = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    fabricante = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    paisOrigem = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    localizacao_id = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ativo = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: true),
                    dataCriacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    dataDestruicao = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drones", x => x.id);
                    table.ForeignKey(
                        name: "FK_Drones_Localizacoes_localizacao_id",
                        column: x => x.localizacao_id,
                        principalTable: "Localizacoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PatosPrimordiais",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    alturaCm = table.Column<float>(type: "float", nullable: false),
                    pesoG = table.Column<float>(type: "float", nullable: false),
                    quantidadeMutacoes = table.Column<int>(type: "int", nullable: false),
                    statusHibernacao = table.Column<string>(type: "varchar(50)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    batimentosCardiacosBpm = table.Column<int>(type: "int", nullable: true),
                    superpoder_id = table.Column<string>(type: "varchar(36)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    localizacao_id = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    droneOrigem_id = table.Column<string>(type: "varchar(36)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    dataCatalogacao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatosPrimordiais", x => x.id);
                    table.ForeignKey(
                        name: "FK_PatosPrimordiais_Drones_droneOrigem_id",
                        column: x => x.droneOrigem_id,
                        principalTable: "Drones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PatosPrimordiais_Localizacoes_localizacao_id",
                        column: x => x.localizacao_id,
                        principalTable: "Localizacoes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatosPrimordiais_Superpoderes_superpoder_id",
                        column: x => x.superpoder_id,
                        principalTable: "Superpoderes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "idx_drones_ativo",
                table: "Drones",
                column: "ativo");

            migrationBuilder.CreateIndex(
                name: "idx_drones_numeroSerie",
                table: "Drones",
                column: "numeroSerie",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_drones_paisOrigem",
                table: "Drones",
                column: "paisOrigem");

            migrationBuilder.CreateIndex(
                name: "IX_Drones_localizacao_id",
                table: "Drones",
                column: "localizacao_id");

            migrationBuilder.CreateIndex(
                name: "idx_localizacoes_coordenadas",
                table: "Localizacoes",
                columns: new[] { "latitude", "longitude" });

            migrationBuilder.CreateIndex(
                name: "idx_localizacoes_pais",
                table: "Localizacoes",
                column: "pais");

            migrationBuilder.CreateIndex(
                name: "IX_Localizacoes_precisao_id",
                table: "Localizacoes",
                column: "precisao_id");

            migrationBuilder.CreateIndex(
                name: "idx_patos_droneOrigem",
                table: "PatosPrimordiais",
                column: "droneOrigem_id");

            migrationBuilder.CreateIndex(
                name: "idx_patos_quantidadeMutacoes",
                table: "PatosPrimordiais",
                column: "quantidadeMutacoes");

            migrationBuilder.CreateIndex(
                name: "idx_patos_statusHibernacao",
                table: "PatosPrimordiais",
                column: "statusHibernacao");

            migrationBuilder.CreateIndex(
                name: "IX_PatosPrimordiais_localizacao_id",
                table: "PatosPrimordiais",
                column: "localizacao_id");

            migrationBuilder.CreateIndex(
                name: "IX_PatosPrimordiais_superpoder_id",
                table: "PatosPrimordiais",
                column: "superpoder_id");

            migrationBuilder.CreateIndex(
                name: "idx_valorEmMetros",
                table: "Precisoes",
                column: "valorEmMetros");

            migrationBuilder.CreateIndex(
                name: "idx_superpoderes_nome",
                table: "Superpoderes",
                column: "nome");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatosPrimordiais");

            migrationBuilder.DropTable(
                name: "Drones");

            migrationBuilder.DropTable(
                name: "Superpoderes");

            migrationBuilder.DropTable(
                name: "Localizacoes");

            migrationBuilder.DropTable(
                name: "Precisoes");
        }
    }
}
