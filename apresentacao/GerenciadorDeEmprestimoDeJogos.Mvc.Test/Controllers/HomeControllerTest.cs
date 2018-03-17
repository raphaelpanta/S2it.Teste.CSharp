using GerenciadorDeEmprestimoDeJogos.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using FluentAssertions;
using GerenciadorDeEmprestimoDeJogos.Mvc.Models.Cadastro;
using GerenciadorDeEmprestimoDeJogos.Mvc.Services;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Test.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void DeveRetornarAViewHome()
        {
            var homeController = new HomeController(null);

            var result = homeController.Index() as ViewResult;

            result.Should().NotBeNull();
            result.ViewName.Should().BeNullOrEmpty();
            result.Model.Should().Should().NotBeNull();
        }

        [Fact]
        public void DeveRedirecionarATelaPrincipal() {
            var servicoDeLogin = new Moq.Mock<IServicoDeLogin>();
            
            var credenciaisValidas = new CredenciaisDoUsuario{
              Email = "raphaelpanta@gmail.com",
              Senha = "123456"  
            };

            servicoDeLogin.Setup(s => s.Validar(credenciaisValidas)).Returns(true);

            var homeController = new HomeController(servicoDeLogin.Object);
            var result = homeController.Login(credenciaisValidas) as RedirectResult;

            result.Should().NotBeNull();
            result.Url.Should().Contain("Principal");
        }

        [Fact]
        public void DeveRerenderizarNaoLogar(){
            var servicoDeLogin = new Moq.Mock<IServicoDeLogin>();
            var credenciaisIncompletas = new CredenciaisDoUsuario 
            {
                Email = "raphaelpanta@gmail.com",
            };

            servicoDeLogin.Setup(s => s.Validar(credenciaisIncompletas)).Returns(false);
            var homeController = new HomeController(servicoDeLogin.Object);
            homeController.ModelState.AddModelError("Senha", "nenhuma senha digitada");
            var result = homeController.Login(credenciaisIncompletas) as ViewResult;

            result.Should().NotBeNull();
            result.ViewName.Should().Be("Home");
            result.Model.Should().BeEquivalentTo(new CredenciaisDoUsuario{
                Email = "raphaelpanta@gmail.com",
            });
        }
    }
}