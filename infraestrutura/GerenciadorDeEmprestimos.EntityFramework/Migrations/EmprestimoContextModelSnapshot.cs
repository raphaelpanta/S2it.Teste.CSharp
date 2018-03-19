﻿// <auto-generated />
using GerenciadorDeEmprestimos.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GerenciadorDeEmprestimos.EntityFramework.Migrations
{
    [DbContext(typeof(EmprestimoContext))]
    partial class EmprestimoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.2-rtm-10011")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GerenciadoDeEmprestimoDeJogos.Dominio.Entidades.Emprestimo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("DataDeDevolucao");

                    b.Property<DateTime>("DataDeEmprestimo");

                    b.Property<Guid?>("UsuarioId");

                    b.HasKey("Id");

                    b.HasIndex("UsuarioId");

                    b.ToTable("Emprestimo");
                });

            modelBuilder.Entity("GerenciadoDeEmprestimoDeJogos.Dominio.Entidades.Jogo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Ano");

                    b.Property<Guid?>("DonoId");

                    b.Property<Guid?>("EmprestimoId");

                    b.Property<string>("Nome");

                    b.Property<string>("Sistema");

                    b.HasKey("Id");

                    b.HasIndex("DonoId");

                    b.HasIndex("EmprestimoId")
                        .IsUnique()
                        .HasFilter("[EmprestimoId] IS NOT NULL");

                    b.ToTable("Jogos");
                });

            modelBuilder.Entity("GerenciadoDeEmprestimoDeJogos.Dominio.Entidades.Usuario", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("GerenciadoDeEmprestimoDeJogos.Dominio.Entidades.Emprestimo", b =>
                {
                    b.HasOne("GerenciadoDeEmprestimoDeJogos.Dominio.Entidades.Usuario", "Usuario")
                        .WithMany("Emprestimos")
                        .HasForeignKey("UsuarioId");
                });

            modelBuilder.Entity("GerenciadoDeEmprestimoDeJogos.Dominio.Entidades.Jogo", b =>
                {
                    b.HasOne("GerenciadoDeEmprestimoDeJogos.Dominio.Entidades.Usuario", "Dono")
                        .WithMany("Jogos")
                        .HasForeignKey("DonoId");

                    b.HasOne("GerenciadoDeEmprestimoDeJogos.Dominio.Entidades.Emprestimo", "Emprestimo")
                        .WithOne("Jogo")
                        .HasForeignKey("GerenciadoDeEmprestimoDeJogos.Dominio.Entidades.Jogo", "EmprestimoId");
                });

            modelBuilder.Entity("GerenciadoDeEmprestimoDeJogos.Dominio.Entidades.Usuario", b =>
                {
                    b.OwnsOne("GerenciadoDeEmprestimoDeJogos.Dominio.Entidades.Credenciais", "Credenciais", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("Email");

                            b1.Property<string>("Salt");

                            b1.Property<string>("Senha");

                            b1.ToTable("Usuarios");

                            b1.HasOne("GerenciadoDeEmprestimoDeJogos.Dominio.Entidades.Usuario")
                                .WithOne("Credenciais")
                                .HasForeignKey("GerenciadoDeEmprestimoDeJogos.Dominio.Entidades.Credenciais", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });

                    b.OwnsOne("GerenciadoDeEmprestimoDeJogos.Dominio.Entidades.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<Guid>("UsuarioId");

                            b1.Property<string>("Cep");

                            b1.Property<string>("Cidade");

                            b1.Property<string>("Complemento");

                            b1.Property<string>("Logradouro");

                            b1.Property<int?>("Numero");

                            b1.Property<string>("UnidadeFederativa");

                            b1.ToTable("Usuarios");

                            b1.HasOne("GerenciadoDeEmprestimoDeJogos.Dominio.Entidades.Usuario")
                                .WithOne("Endereco")
                                .HasForeignKey("GerenciadoDeEmprestimoDeJogos.Dominio.Entidades.Endereco", "UsuarioId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
