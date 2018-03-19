using System;
using System.Linq;
using FluentAssertions;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Emprestimos;
using GerenciadorDeEmprestimoDeJogos.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Test.Controllers {
    public class PrincipalControllerTest {
        [Fact]
        public void DeveRemoverAmizade () {
            var servico = new Mock<IServicoDeEmprestimo> ();
            var id = Guid.NewGuid ();
            servico.Setup (x => x.DefazerAmizadePorId (id, "raphaelpanta@gmail.com"));
            servico.Setup (x => x.DadosDeEmprestimo ("raphaelpanta@gmail.com"))
                .Returns (new DadosDoEmprestimo {
                    JogosEmprestados = Enumerable.Empty<JogoEmprestado> (),
                        Amigos = Enumerable.Empty<DadosDeAmigo> (),
                        MeusJogos = Enumerable.Empty<DadosDeJogo> ()
                });

            var controller = new PrincipalController (servico.Object);

            var result = controller.RemoverAmigo (id) as RedirectToActionResult;

            result.Should ().NotBeNull ();

            result.ActionName.Should ().Be ("Index");
        }

        [Fact]
        public void DeveRemoverJogo () {
            var servico = new Mock<IServicoDeEmprestimo> ();
            var id = Guid.NewGuid ();
            servico.Setup (x => x.RemoverJogoPorId (id, "raphaelpanta@gmail.com"));
            servico.Setup (x => x.DadosDeEmprestimo ("raphaelpanta@gmail.com"))
                .Returns (new DadosDoEmprestimo {
                    JogosEmprestados = Enumerable.Empty<JogoEmprestado> (),
                        Amigos = Enumerable.Empty<DadosDeAmigo> (),
                        MeusJogos = Enumerable.Empty<DadosDeJogo> ()
                });

            var controller = new PrincipalController (servico.Object);

            var result = controller.RemoverJogo (id) as RedirectResult;

            result.Should ().NotBeNull ();

            result.Url.Should ().Contain ("Principal");
        }
    }
}