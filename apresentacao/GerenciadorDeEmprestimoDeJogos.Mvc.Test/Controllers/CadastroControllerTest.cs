using System;
using FluentAssertions;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Login;
using GerenciadorDeEmprestimoDeJogos.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Test.Controllers
{
    public class CadastroControllerTest
    {
        [Fact]
        public void DeveREnderizarAView() {
            var controller = new CadastroController();
            var result = controller.Index() as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().BeEquivalentTo(new DadosDoUsuario());
            result.ViewName.Should().BeNullOrEmpty();
        }


        [Fact]
        public void DeveRedirecionarAHome() {
            var controller = new CadastroController();
            var result = controller.Index(new DadosDoUsuario{
                Nome = "Raphael Pantaleão",
                Email = "raphaelpanta@gmail.com",
                RepetirEmail = "raphaelpanta@gmail.com",
                Senha = "123456",
                RepetirSenha = "123456",
                DataDeNascimento = new DateTime(1987, 2, 25),
                Endereco = "Rua 110",
                Numero = 987,
                Complemento = "De frente a um frigorífico",
                Cep = "14600206",
                Cidade = "Araraquara",
                UnidadeFederativa = "SP"
            }) as RedirectResult;

            result.Should().NotBeNull();

            result.Url.Should().Contain("Home");
        }

        [Fact]
        public void DeveReredenrizarViewQuandoCredenciaisIncompletas(){
            var controller = new CadastroController();

            controller.ModelState.AddModelError("Email", "preencher email");  
            
            var result = controller.Index(new DadosDoUsuario{
                Nome = "Raphael ",
            }) as ViewResult;

            
            result.Should().NotBeNull();
            result.ViewName.Should().BeNullOrEmpty();
            result.Model.Should().BeEquivalentTo(
                new DadosDoUsuario{
                     Nome = "Raphael ",
                });
        }
    }
}