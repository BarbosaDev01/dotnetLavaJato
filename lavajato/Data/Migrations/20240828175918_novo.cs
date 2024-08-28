using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace lavajato.Data.Migrations
{
    /// <inheritdoc />
    public partial class novo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    CodCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FoneCliente = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.CodCliente);
                });

            migrationBuilder.CreateTable(
                name: "TipoLavagem",
                columns: table => new
                {
                    CodTipoLav = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescTipoLav = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecoTipoLav = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoLavagem", x => x.CodTipoLav);
                });

            migrationBuilder.CreateTable(
                name: "Carro",
                columns: table => new
                {
                    CodCarro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ano = table.Column<int>(type: "int", nullable: false),
                    Placa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodCliente = table.Column<int>(type: "int", nullable: false),
                    ClienteCodCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carro", x => x.CodCarro);
                    table.ForeignKey(
                        name: "FK_Carro_Cliente_ClienteCodCliente",
                        column: x => x.ClienteCodCliente,
                        principalTable: "Cliente",
                        principalColumn: "CodCliente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Lavagem",
                columns: table => new
                {
                    CodLav = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataLav = table.Column<int>(type: "int", nullable: false),
                    ValorLav = table.Column<int>(type: "int", nullable: false),
                    CodCarro = table.Column<int>(type: "int", nullable: false),
                    CarroCodCarro = table.Column<int>(type: "int", nullable: false),
                    CodTipoLav = table.Column<int>(type: "int", nullable: false),
                    TipoLavagemCodTipoLav = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lavagem", x => x.CodLav);
                    table.ForeignKey(
                        name: "FK_Lavagem_Carro_CarroCodCarro",
                        column: x => x.CarroCodCarro,
                        principalTable: "Carro",
                        principalColumn: "CodCarro",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Lavagem_TipoLavagem_TipoLavagemCodTipoLav",
                        column: x => x.TipoLavagemCodTipoLav,
                        principalTable: "TipoLavagem",
                        principalColumn: "CodTipoLav",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carro_ClienteCodCliente",
                table: "Carro",
                column: "ClienteCodCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Lavagem_CarroCodCarro",
                table: "Lavagem",
                column: "CarroCodCarro");

            migrationBuilder.CreateIndex(
                name: "IX_Lavagem_TipoLavagemCodTipoLav",
                table: "Lavagem",
                column: "TipoLavagemCodTipoLav");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Lavagem");

            migrationBuilder.DropTable(
                name: "Carro");

            migrationBuilder.DropTable(
                name: "TipoLavagem");

            migrationBuilder.DropTable(
                name: "Cliente");
        }
    }
}
