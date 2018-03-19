using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using FluentAssertions;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Emprestimos;
using Moq;
using Xunit;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Test.Services {
    public class ServicoDeEmprestimoTest {

        [Fact]
        public void DeveMontadorOsDadosDoEmprestimo () {
            var repositorio = new Mock<IRepositorioDeEmprestimo> ();

            repositorio.Setup (x => x.PorEmail (It.Is<string> (v => v.Equals ("raphaelpanta@gmail.com"))))
                .Returns (new [] {
                    new Usuario {
                        Emprestimos = new List<Emprestimo> (),
                            Credenciais = new Credenciais {
                                Email = "raphaelpanta@gmail.com",
                            },
                            Amigos = new List<Amigo> (),
                            Jogos = new List<Jogo> ()
                    }
                });

            var servico = new ServicoDeEmprestimo (repositorio.Object) as IServicoDeEmprestimo;

            servico.DadosDeEmprestimo ("raphaelpanta@gmail.com")
                .Should ()
                .BeEquivalentTo (new DadosDoEmprestimo {
                    Amigos = Enumerable.Empty<DadosDeAmigo> (),
                        JogosEmprestados = Enumerable.Empty<JogoEmprestado> (),
                        MeusJogos = Enumerable.Empty<DadosDeJogo> ()
                });

            repositorio.Verify (x => x.PorEmail (It.Is<string> (v => v.Equals ("raphaelpanta@gmail.com"))), Times.Once ());
        }

        [Fact]
        public void DeveRegistrarDevolucao () {
            var repositorio = new Mock<IRepositorioDeEmprestimo> ();

            repositorio.Setup (x => x.RegistrarDevolucao (It.IsAny<Emprestimo> ()));
            var id = Guid.NewGuid ();
            repositorio.Setup (x => x.EmprestimoPor (It.Is<string> (v => v.Equals ("raphaelpanta@gmail.com")), It.Is<Guid> (v => v.Equals (id))))
                .Returns (new [] {
                    new Emprestimo { }
                });

            ClaimsIdentity claimsIdentity = new ClaimsIdentity ();
            claimsIdentity.AddClaim (new Claim ("email", "raphaelpanta@gmail.com"));

            var servico = new ServicoDeEmprestimo (repositorio.Object) as IServicoDeEmprestimo;

            servico.DevolverJogoPorId (id, "raphaelpanta@gmail.com");

            repositorio.Verify (x => x.RegistrarDevolucao (It.IsAny<Emprestimo> ()));

            repositorio.Verify (x => x.EmprestimoPor (It.Is<string> (v => v.Equals ("raphaelpanta@gmail.com")), It.Is<Guid> (v => v.Equals (id))), Times.Once ());
        }
    }
}