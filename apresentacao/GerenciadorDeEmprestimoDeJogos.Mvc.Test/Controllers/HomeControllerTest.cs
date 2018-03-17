using GerenciadorDeEmprestimoDeJogos.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using FluentAssertions;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Test.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void ShouldReturnToHome()
        {
            var homeController = new HomeController();

            var result = homeController.Index() as ViewResult;

            result.Should().NotBeNull();
            result.ViewName.Should().BeNullOrEmpty();
        }
    }
}