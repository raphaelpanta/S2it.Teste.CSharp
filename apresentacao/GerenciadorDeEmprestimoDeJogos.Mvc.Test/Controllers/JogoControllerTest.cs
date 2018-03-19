using System;
using FluentAssertions;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Jogos;
using GerenciadorDeEmprestimoDeJogos.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Test.Controllers
{
    public class JogoControllerTest
    {
        [Fact]
        public void DeveAdicionarUmJogo(){
            var servico = new Mock<IServicoDeJogos>();
            var controller = new JogoController(servico.Object);

            var result = controller.Index() as ViewResult;
            
            result.Should().NotBeNull();
            result.Model.Should().BeEquivalentTo(new DadosDoJogo());
        }

        [Fact]
        public void DeveEditarUmJogo(){
            var servico = new Mock<IServicoDeJogos>();
            var jogo = new DadosDoJogo {
                Nome = "nome",
                Ano = 1980,
                Sistema = "snes"
            };
            var id = Guid.NewGuid();
            servico.Setup(x => x.PorId(id)).Returns(jogo);

            var controller = new JogoController(servico.Object);
            var result = controller.Editar(id) as ViewResult;
            
            result.Should().NotBeNull();
            result.Model.Should().Be(jogo);
        }

        [Fact]
        public void DeveRedirecionarSeCadastradoComSucesso(){
            var servico = new Mock<IServicoDeJogos>();
            var jogo = new DadosDoJogo {
                Nome = "Teste",
                Ano = 1989,
                Sistema = "Teste"
            };

            servico.Setup(x =>x.Adicionar(jogo, "raphaelpanta@gmail.com"));

            var controller = new JogoController(servico.Object);

            var result = controller.Index(jogo) as RedirectResult;

            result.Should().NotBeNull();
            result.Url.Should().Contain("Principal");
        }

        [Fact]
        public void DeveRerenderizarSeOModeloForInvalido(){
            var servico = new Mock<IServicoDeJogos>();
            var jogo = new DadosDoJogo {
                Nome = "nome"
            };

            servico.Setup(x => x.Adicionar(jogo, "raphaelpanta@gmail.com"));

            var controller = new JogoController(servico.Object);
            controller.ModelState.AddModelError("Ano", "Deveria ser preenchido");
            
            var result = controller.Index(jogo) as ViewResult;

            result.Should().NotBeNull();

            result.Model.Should().Be(jogo);
        }
    }
}