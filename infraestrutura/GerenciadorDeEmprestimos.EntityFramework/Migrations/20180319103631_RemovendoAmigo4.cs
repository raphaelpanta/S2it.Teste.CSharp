using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GerenciadorDeEmprestimos.EntityFramework.Migrations
{
    public partial class RemovendoAmigo4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amigo_Usuarios_MeuAmigoId",
                table: "Amigo");

            migrationBuilder.DropForeignKey(
                name: "FK_Amigo_Usuarios_UsuarioId",
                table: "Amigo");

            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Emprestimo_EmprestimoId",
                table: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_EmprestimoId",
                table: "Jogos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amigo",
                table: "Amigo");

            migrationBuilder.DropColumn(
                name: "EmprestimoId",
                table: "Jogos");

            migrationBuilder.RenameTable(
                name: "Amigo",
                newName: "Amigos");

            migrationBuilder.RenameIndex(
                name: "IX_Amigo_UsuarioId",
                table: "Amigos",
                newName: "IX_Amigos_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Amigo_MeuAmigoId",
                table: "Amigos",
                newName: "IX_Amigos_MeuAmigoId");

            migrationBuilder.AddColumn<Guid>(
                name: "JogoId",
                table: "Emprestimo",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amigos",
                table: "Amigos",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Emprestimo_JogoId",
                table: "Emprestimo",
                column: "JogoId",
                unique: true,
                filter: "[JogoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Amigos_Usuarios_MeuAmigoId",
                table: "Amigos",
                column: "MeuAmigoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Amigos_Usuarios_UsuarioId",
                table: "Amigos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Emprestimo_Jogos_JogoId",
                table: "Emprestimo",
                column: "JogoId",
                principalTable: "Jogos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amigos_Usuarios_MeuAmigoId",
                table: "Amigos");

            migrationBuilder.DropForeignKey(
                name: "FK_Amigos_Usuarios_UsuarioId",
                table: "Amigos");

            migrationBuilder.DropForeignKey(
                name: "FK_Emprestimo_Jogos_JogoId",
                table: "Emprestimo");

            migrationBuilder.DropIndex(
                name: "IX_Emprestimo_JogoId",
                table: "Emprestimo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amigos",
                table: "Amigos");

            migrationBuilder.DropColumn(
                name: "JogoId",
                table: "Emprestimo");

            migrationBuilder.RenameTable(
                name: "Amigos",
                newName: "Amigo");

            migrationBuilder.RenameIndex(
                name: "IX_Amigos_UsuarioId",
                table: "Amigo",
                newName: "IX_Amigo_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Amigos_MeuAmigoId",
                table: "Amigo",
                newName: "IX_Amigo_MeuAmigoId");

            migrationBuilder.AddColumn<Guid>(
                name: "EmprestimoId",
                table: "Jogos",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amigo",
                table: "Amigo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_EmprestimoId",
                table: "Jogos",
                column: "EmprestimoId",
                unique: true,
                filter: "[EmprestimoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Amigo_Usuarios_MeuAmigoId",
                table: "Amigo",
                column: "MeuAmigoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Amigo_Usuarios_UsuarioId",
                table: "Amigo",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Emprestimo_EmprestimoId",
                table: "Jogos",
                column: "EmprestimoId",
                principalTable: "Emprestimo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
