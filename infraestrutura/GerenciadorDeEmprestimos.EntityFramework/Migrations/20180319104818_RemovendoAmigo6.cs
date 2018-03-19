using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace GerenciadorDeEmprestimos.EntityFramework.Migrations
{
    public partial class RemovendoAmigo6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amigos_Usuarios_UsuarioId",
                table: "Amigos");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Amigos",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Amigos_Usuarios_UsuarioId",
                table: "Amigos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amigos_Usuarios_UsuarioId",
                table: "Amigos");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Amigos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Amigos_Usuarios_UsuarioId",
                table: "Amigos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
