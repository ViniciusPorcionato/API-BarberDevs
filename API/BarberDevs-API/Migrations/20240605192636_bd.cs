using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BarberDevs_API.Migrations
{
    /// <inheritdoc />
    public partial class bd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Barbearia",
                columns: table => new
                {
                    IdBarbearia = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomeFantasia = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CNPJ = table.Column<int>(type: "INT", nullable: false),
                    Latitude = table.Column<decimal>(type: "DECIMAL(6,2)", nullable: true),
                    Longitude = table.Column<decimal>(type: "DECIMAL(6,2)", nullable: true),
                    Cep = table.Column<int>(type: "INT", nullable: false),
                    Logradouro = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Bairro = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Numero = table.Column<int>(type: "INT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbearia", x => x.IdBarbearia);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    IdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Email = table.Column<string>(type: "VARCHAR(200)", nullable: false),
                    Senha = table.Column<string>(type: "VARCHAR(65)", maxLength: 65, nullable: false),
                    Nome = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Foto = table.Column<string>(type: "TEXT", nullable: true),
                    CodRecupSenha = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.IdUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Barbeiro",
                columns: table => new
                {
                    IdBarbeiro = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rg = table.Column<int>(type: "INT", nullable: false),
                    Cpf = table.Column<int>(type: "INT", nullable: false),
                    Descricao = table.Column<string>(type: "TEXT", nullable: true),
                    IdBarbearia = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    UsuarioBarbeiroIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Barbeiro", x => x.IdBarbeiro);
                    table.ForeignKey(
                        name: "FK_Barbeiro_Barbearia_IdBarbearia",
                        column: x => x.IdBarbearia,
                        principalTable: "Barbearia",
                        principalColumn: "IdBarbearia");
                    table.ForeignKey(
                        name: "FK_Barbeiro_Usuario_UsuarioBarbeiroIdUsuario",
                        column: x => x.UsuarioBarbeiroIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Rg = table.Column<int>(type: "INT", nullable: false),
                    Cpf = table.Column<int>(type: "INT", nullable: false),
                    UsuarioClienteIdUsuario = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.IdCliente);
                    table.ForeignKey(
                        name: "FK_Cliente_Usuario_UsuarioClienteIdUsuario",
                        column: x => x.UsuarioClienteIdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "IdUsuario");
                });

            migrationBuilder.CreateTable(
                name: "Agendamento",
                columns: table => new
                {
                    IdAgendamento = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataAgendamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HoraAgendamento = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IdCliente = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IdBarbeiro = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agendamento", x => x.IdAgendamento);
                    table.ForeignKey(
                        name: "FK_Agendamento_Barbeiro_IdBarbeiro",
                        column: x => x.IdBarbeiro,
                        principalTable: "Barbeiro",
                        principalColumn: "IdBarbeiro");
                    table.ForeignKey(
                        name: "FK_Agendamento_Cliente_IdCliente",
                        column: x => x.IdCliente,
                        principalTable: "Cliente",
                        principalColumn: "IdCliente");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdBarbeiro",
                table: "Agendamento",
                column: "IdBarbeiro");

            migrationBuilder.CreateIndex(
                name: "IX_Agendamento_IdCliente",
                table: "Agendamento",
                column: "IdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Barbeiro_IdBarbearia",
                table: "Barbeiro",
                column: "IdBarbearia");

            migrationBuilder.CreateIndex(
                name: "IX_Barbeiro_UsuarioBarbeiroIdUsuario",
                table: "Barbeiro",
                column: "UsuarioBarbeiroIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Cpf",
                table: "Cliente",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Rg",
                table: "Cliente",
                column: "Rg",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UsuarioClienteIdUsuario",
                table: "Cliente",
                column: "UsuarioClienteIdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agendamento");

            migrationBuilder.DropTable(
                name: "Barbeiro");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Barbearia");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
