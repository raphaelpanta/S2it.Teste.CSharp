using GerenciadorDeEmprestimoDeJogos.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using FluentAssertions;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Login;

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

        [Fact(Skip = "Investigar como mockar o HttpContext")]
        public async void DeveRedirecionarATelaPrincipal()
        {
            var servicoDeLogin = new Moq.Mock<IServicoDeLogin>();

            var credenciaisValidas = new CredenciaisDoUsuario
            {
                Email = "raphaelpanta@gmail.com",
                Senha = "123456"
            };

            servicoDeLogin.Setup(s => s.Validar(credenciaisValidas)).Returns(true);

            var homeController = new HomeController(servicoDeLogin.Object);
            homeController.SetTestContext();
            var result = await homeController.Login(credenciaisValidas) as RedirectResult;

            result.Should().NotBeNull();
            result.Url.Should().Contain("Principal");
        }

        [Fact(Skip = "Investigar como mockar o HttpContext")]
        public async void DeveRerenderizarNaoLogar()
        {
            var servicoDeLogin = new Moq.Mock<IServicoDeLogin>();
            var credenciaisIncompletas = new CredenciaisDoUsuario
            {
                Email = "raphaelpanta@gmail.com",
            };

            servicoDeLogin.Setup(s => s.Validar(credenciaisIncompletas)).Returns(false);
            var homeController = new HomeController(servicoDeLogin.Object);
            homeController.SetTestContext();
            homeController.ModelState.AddModelError("Senha", "nenhuma senha digitada");
            var result = await homeController.Login(credenciaisIncompletas) as ViewResult;

            result.Should().NotBeNull();
            result.ViewName.Should().Be("Index");
            result.Model.Should().BeEquivalentTo(new CredenciaisDoUsuario
            {
                Email = "raphaelpanta@gmail.com",
            });
        }
    }
}