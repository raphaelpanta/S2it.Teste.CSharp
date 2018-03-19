using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using FluentAssertions;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Amigos;
using Moq;
using Xunit;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Test.Services {

    public class ServicoDeAmigosTest {

        [Fact]
        public void DeveListarAmigosNaoAdicionados () {
            var repositorio = new Mock<IRepositorioDeAmigos> ();
            var lista = new [] {
                new Usuario { }
            };
            repositorio.Setup (x => x.NaoAdicionados (It.Is<string> (v => v.Equals ("raphaelpanta@gmail.com"))))
                .Returns (lista);

            var identity = new ClaimsIdentity ();
            identity.AddClaim (new Claim ("email", "raphaelpanta@gmail.com"));
            var principal = new ClaimsPrincipal (identity);

            var servico = new ServicoDeAmigos (repositorio.Object) as IServicoDeAmigos;

            var resultado = servico.NaoAdicionados ("raphaelpanta@gmail.com");

            resultado.Should ().BeEquivalentTo (lista.Select(x => new DadosDoAmigo {
               Nome = x.Nome,
               AmigoId = x.Id 
            }));

            repositorio.Verify(x => x.NaoAdicionados(It.Is<string>(v => v.Equals("raphaelpanta@gmail.com"))), Times.Once());
        }

        [Fact]
        public void DeveAdicionarAmigo() {
            var repositorio = new Mock<IRepositorioDeAmigos>();
            var id = Guid.NewGuid();
            var amigo = new Usuario {};
            
            repositorio.Setup(x => x.PorId(It.Is<Guid>(y => y == id)))
            .Returns(amigo);
            
            var usuario = new Usuario {
                Amigos = new List<Amigo>() 
            };
            
            repositorio.Setup(x => x.PorEmail(It.Is<string>(y => y.Equals("raphaelpanta@gmail.com"))))
            .Returns(usuario);


            repositorio.Setup(x => x.Adicionar(It.IsAny<Usuario>()));

            var identity = new ClaimsIdentity ();
            identity.AddClaim (new Claim ("email", "raphaelpanta@gmail.com"));
            var principal = new ClaimsPrincipal (identity);
            var servico = new ServicoDeAmigos(repositorio.Object);

            servico.Adicionar(id, "raphaelpanta@gmail.com");


            repositorio.Verify(x => x.PorId(It.Is<Guid>(y => y == id)), Times.Once());

            repositorio.Verify(x => x.PorEmail(It.Is<string>(y => y.Equals("raphaelpanta@gmail.com"))), Times.Once());

            repositorio.Verify(x => x.Adicionar(It.IsAny<Usuario>()), Times.Once());
        }
    }
}