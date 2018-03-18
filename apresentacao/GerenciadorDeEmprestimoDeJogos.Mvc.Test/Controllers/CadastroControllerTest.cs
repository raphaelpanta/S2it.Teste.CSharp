using System;
using System.Collections.Generic;
using FluentAssertions;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Login;
using GerenciadorDeEmprestimoDeJogos.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Moq;
using Xunit;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Test.Controllers
{

    internal class DummyTempDataDictionary : Dictionary<string, object>, ITempDataDictionary
    {
        public void Keep()
        {
            throw new NotImplementedException();
        }

        public void Keep(string key)
        {
            throw new NotImplementedException();
        }

        public void Load()
        {
            throw new NotImplementedException();
        }

        public object Peek(string key)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
    public class CadastroControllerTest
    {
        [Fact]
        public void DeveREnderizarAView() {
            var controller = new CadastroController(null);
            var result = controller.Index() as ViewResult;

            result.Should().NotBeNull();
            result.Model.Should().BeEquivalentTo(new DadosDoUsuario());
            result.ViewName.Should().BeNullOrEmpty();
        }


        [Fact]
        public void DeveRedirecionarAHome() {
            var servico = new Mock<IServicoDeLogin>();
            var usuario = new DadosDoUsuario{
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
            };
            servico.Setup(x => x.Cadastrar(usuario));

            var controller = new CadastroController(servico.Object);
            controller.TempData = new DummyTempDataDictionary();
            var result = controller.Cadastrar(usuario) as RedirectToActionResult;

            result.Should().NotBeNull();

            result.ControllerName.Should().Be("Home");
            result.ActionName.Should().Be("Index");

            controller.TempData["Sucesso"].Should().Be("Cadastrado com sucesso! Por favor entrar novamente com suas credenciais");
            
        }

        [Fact]
        public void DeveReredenrizarViewQuandoCredenciaisIncompletas(){
            var controller = new CadastroController(null);

            controller.ModelState.AddModelError("Email", "preencher email");  
            
            var result = controller.Cadastrar(new DadosDoUsuario{
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