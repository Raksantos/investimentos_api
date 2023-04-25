using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InvestimentosApi.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Acoes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    NomeCurto = table.Column<string>(type: "text", nullable: false),
                    NomeLongo = table.Column<string>(type: "text", nullable: false),
                    MoedaUsada = table.Column<string>(type: "text", nullable: false),
                    PrecoMercado = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Acoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    CPF = table.Column<string>(type: "text", nullable: false),
                    SaldoDisponivel = table.Column<double>(type: "double precision", nullable: false),
                    SaldoInvestido = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Criptos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    MoedaUsada = table.Column<string>(type: "text", nullable: false),
                    PrecoMercado = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criptos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FundosImobiliarios",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    NomeCurto = table.Column<string>(type: "text", nullable: false),
                    NomeLongo = table.Column<string>(type: "text", nullable: false),
                    MoedaUsada = table.Column<string>(type: "text", nullable: false),
                    PrecoMercado = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FundosImobiliarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TesouroDiretos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    NomeCurto = table.Column<string>(type: "text", nullable: false),
                    NomeLongo = table.Column<string>(type: "text", nullable: false),
                    MoedaUsada = table.Column<string>(type: "text", nullable: false),
                    PrecoMercado = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TesouroDiretos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Acoes");

            migrationBuilder.DropTable(
                name: "Contas");

            migrationBuilder.DropTable(
                name: "Criptos");

            migrationBuilder.DropTable(
                name: "FundosImobiliarios");

            migrationBuilder.DropTable(
                name: "TesouroDiretos");
        }
    }
}
