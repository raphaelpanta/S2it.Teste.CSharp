using System;
using System.Linq;
using FluentAssertions;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Amigos;
using GerenciadorDeEmprestimoDeJogos.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Test.Controllers
{
    public class AmigosControllerTest
    {
        [Fact]
        public void DeveListarAmigosNaoAdicionados() {
            var servicoDeAmigos = new Mock<IServicoDeAmigos>();

            var id =  Guid.NewGuid();
            servicoDeAmigos.Setup(x => x.NaoAdicionados()).Returns(new [] {
                new DadosDoAmigo { AmigoId = id, Nome = "Raphael"}
            });

            var controller = new AmigosController(servicoDeAmigos.Object);

            var result = controller.Index() as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().BeEquivalentTo(new [] {
                new DadosDoAmigo { AmigoId = id, Nome = "Raphael"}
            });
        }

        [Fact]
        public void DeveAdicionarAmigo() {
            
            var servicoDeAmigos = new Mock<IServicoDeAmigos>();
            var id = Guid.NewGuid();
            servicoDeAmigos.Setup(x => x.Adicionar(id));

            servicoDeAmigos.Setup(x => x.NaoAdicionados()).Returns(Enumerable.Empty<DadosDoAmigo>());

            var controller = new AmigosController(servicoDeAmigos.Object);

            var result = controller.Index(id) as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().BeEquivalentTo(Enumerable.Empty<DadosDoAmigo>());
        }
    }
}