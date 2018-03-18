using System;
using FluentAssertions;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Login;
using Moq;
using Xunit;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Test.Services {
    public class ServicoDeLoginTest {
        [Fact]
        public void DeveValidarCredenciais () {
            var repositorio = new Mock<IRepositorioDeUsuario> ();
            var salt = Guid.NewGuid ();
            repositorio.Setup (x => x.Por ("raphaelpanta@gmail.com"))
                .Returns (Credenciais.Nova ("raphaelpanta@gmail.com", "123456", salt.ToString ()));
            var servicoDeLogin = new ServicoDeLogin (repositorio.Object) as IServicoDeLogin;

            var validacao = servicoDeLogin.Validar (new CredenciaisDoUsuario {
                Email = "raphaelpanta@gmail.com",
                    Senha = "123456"
            });

            validacao.Should ().BeTrue ();
        }

        [Fact]
        public void DeveInvalidarCredenciais () 
        {
            var repositorio = new Mock<IRepositorioDeUsuario> ();
            var salt = Guid.NewGuid ();
            repositorio.Setup (x => x.Por ("raphaelpanta@gmail.com"))
                .Returns (Credenciais.Nova ("raphaelpanta@gmail.com", "123456", salt.ToString ()));
            var servicoDeLogin = new ServicoDeLogin (repositorio.Object) as IServicoDeLogin;

            var validacao = servicoDeLogin.Validar (new CredenciaisDoUsuario {
                Email = "raphaelpanta@gmail.com",
                    Senha = "1234567"
            });

            validacao.Should ().BeFalse ();
        }

        [Fact]
        public void DeveCadastrarUsuario () 
        {
            var repositorio = new Mock<IRepositorioDeUsuario> ();
            var salt = Guid.NewGuid();
            var usuario = new Usuario {
                Nome = "nome",
                Credenciais = Credenciais.Nova("email@email.com", "123456", salt.ToString()),
                DataDeNascimento = new DateTime(1987, 2, 25),
                Endereco = new Endereco{
                    Logradouro = "Rua 11",
                    Numero = 0,
                    Complemento = "nenhum",
                    Cep = "14800206",
                    Cidade = "Araraquara",
                    UnidadeFederativa = "SP"
                }
            };

            repositorio.Setup(x => x.NewSalt()).Returns(salt);
            repositorio.Setup(x => 
                x.Cadastrar(It.IsAny<Usuario>()));

            var servicoDeLogin = new ServicoDeLogin (repositorio.Object) as IServicoDeLogin;

            servicoDeLogin.Cadastrar(new DadosDoUsuario{
                    Nome = "nome",
                    Email = "email@email.com",
                    RepetirEmail = "email@email.com",
                    Senha = "123456",
                    RepetirSenha = "123456",
                    DataDeNascimento = new DateTime(1987,2,25),
                    Endereco = "Rua 11",
                    Numero = 0,
                    Complemento = "nenhum",
                    Cep = "14800206",
                    Cidade = "Araraquara",
                    UnidadeFederativa = "SP"
            });

            repositorio.Verify(x => x.NewSalt(), Times.Once());
            repositorio.Verify(x => x.Cadastrar(It.IsAny<Usuario>()));
        }

        [Fact]
        public void DeveLancarExcecaoSeNaoCadastrar() {
            var repositorio = new Mock<IRepositorioDeUsuario>();

            repositorio.Setup(x => x.Cadastrar(It.IsAny<Usuario>()))
                .Throws(new CadastroNaoRealizadoException("não realizou cadastro", new Exception()));

            var servicoDeLogin = new ServicoDeLogin(repositorio.Object) as IServicoDeLogin;

            Action act = () => servicoDeLogin.Cadastrar(new DadosDoUsuario());

            act.Should().Throw<CadastroNaoRealizadoException>();
        }
    }
}