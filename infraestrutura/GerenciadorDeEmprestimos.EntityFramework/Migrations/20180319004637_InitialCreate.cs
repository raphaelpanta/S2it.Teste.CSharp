using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GerenciadorDeEmprestimos.EntityFramework.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeNascimento = table.Column<DateTime>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Credenciais_Email = table.Column<string>(nullable: true),
                    Credenciais_Salt = table.Column<string>(nullable: true),
                    Credenciais_Senha = table.Column<string>(nullable: true),
                    Endereco_Cep = table.Column<string>(nullable: true),
                    Endereco_Cidade = table.Column<string>(nullable: true),
                    Endereco_Complemento = table.Column<string>(nullable: true),
                    Endereco_Logradouro = table.Column<string>(nullable: true),
                    Endereco_Numero = table.Column<int>(nullable: true),
                    Endereco_UnidadeFederativa = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emprestimo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DataDeDevolucao = table.Column<DateTime>(nullable: true),
                    DataDeEmprestimo = table.Column<DateTime>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emprestimo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emprestimo_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Ano = table.Column<int>(nullable: false),
                    DonoId = table.Column<Guid>(nullable: true),
                    EmprestimoId = table.Column<Guid>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Sistema = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jogos_Usuarios_DonoId",
                        column: x => x.DonoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Jogos_Emprestimo_EmprestimoId",
                        column: x => x.EmprestimoId,
                        principalTable: "Emprestimo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_UsuarioId",
                table: "Emprestimo",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_DonoId",
                table: "Jogos",
                column: "DonoId");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_EmprestimoId",
                table: "Jogos",
                column: "EmprestimoId",
                unique: true,
                filter: "[EmprestimoId] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Emprestimo");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
