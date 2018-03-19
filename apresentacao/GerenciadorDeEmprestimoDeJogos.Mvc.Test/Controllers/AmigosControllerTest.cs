using System;
using System.Linq;
using System.Security.Claims;
using FluentAssertions;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Amigos;
using GerenciadorDeEmprestimoDeJogos.Mvc.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Test.Controllers
{

    public static class Utils {

        public static void SetTestContext(this Controller c) {
             c.ControllerContext = new ControllerContext {
                HttpContext = new DefaultHttpContext()
            };
            
            c.HttpContext.User = new ClaimsPrincipal(new ClaimsIdentity(new [] { 
                new Claim("email", "raphaelpanta@gmail.com")
            }));
        }
        
    }

    public class AmigosControllerTest
    {
        [Fact]
        public void DeveListarAmigosNaoAdicionados()
        {
            var servicoDeAmigos = new Mock<IServicoDeAmigos>();

            var id = Guid.NewGuid();
            servicoDeAmigos.Setup(x => x.NaoAdicionados(It.Is<string>(y =>  y == "raphaelpanta@gmail.com")))
            .Returns(new[] {
                new DadosDoAmigo { AmigoId = id, Nome = "Raphael"}
            });

            var controller = new AmigosController(servicoDeAmigos.Object);
            controller.SetTestContext();
            
            
            var result = controller.Index() as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().BeEquivalentTo(new[] {
                new DadosDoAmigo { AmigoId = id, Nome = "Raphael"}
            });
        }

        [Fact]
        public void DeveAdicionarAmigo()
        {

            var servicoDeAmigos = new Mock<IServicoDeAmigos>();
            var id = Guid.NewGuid();
            servicoDeAmigos.Setup(x => x.Adicionar(id, "raphaelpanta@gmail.com"));

            servicoDeAmigos.Setup(x => x.NaoAdicionados("raphaelpanta@gmail.com")).Returns(Enumerable.Empty<DadosDoAmigo>());

            var controller = new AmigosController(servicoDeAmigos.Object);
            controller.SetTestContext();
            var result = controller.Index(id) as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().BeEquivalentTo(Enumerable.Empty<DadosDoAmigo>());
        }
    }
}