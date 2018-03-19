using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GerenciadorDeEmprestimos.EntityFramework.Migrations
{
    public partial class RemovendoAmigo3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amigo",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    InicioDaAmizade = table.Column<DateTime>(nullable: false),
                    MeuAmigoId = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amigo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amigo_Usuarios_MeuAmigoId",
                        column: x => x.MeuAmigoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Amigo_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amigo_MeuAmigoId",
                table: "Amigo",
                column: "MeuAmigoId");

            migrationBuilder.CreateIndex(
                name: "IX_Amigo_UsuarioId",
                table: "Amigo",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amigo");
        }
    }
}
