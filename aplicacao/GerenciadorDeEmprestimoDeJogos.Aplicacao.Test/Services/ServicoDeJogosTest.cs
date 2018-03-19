using System;
using FluentAssertions;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Jogos;
using Moq;
using Xunit;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Test.Services {
    public class ServicoDeJogosTest {
        [Fact]
        public void DeveAdicionarJogo () {
            var repositorio = new Mock<IRepositorioDeJogos> ();

            repositorio.Setup (x => x.Adicionar (It.IsAny<Jogo> (), "raphaelpanta@gmail.com"));

            var servico = new ServicoDeJogos (repositorio.Object) as IServicoDeJogos;
            servico.Adicionar (new DadosDoJogo {
                Nome = "Jogo",
                    Sistema = "Super Nintendo",
                    Ano = 1990
            }, "raphaelpanta@gmail.com");
            repositorio.Verify (x => x.Adicionar (It.IsAny<Jogo> (), "raphaelpanta@gmail.com"), Times.Once ());
        }

        [Fact]
        public void DeveLancarExcecaoSeNaoCadastrar () {
            var repositorio = new Mock<IRepositorioDeJogos> ();

            repositorio.Setup (x => x.Adicionar (It.IsAny<Jogo> (), "raphaelpanta@gmail.com"))
                .Throws (new JogoNaoPodeSerAdicionadoException ("msg", new Exception ()));

            var servico = new ServicoDeJogos (repositorio.Object) as IServicoDeJogos;
            Action act = () => servico.Adicionar (new DadosDoJogo {
                Nome = "Jogo",
                    Sistema = "Super Nintendo",
                    Ano = 1990
            }, "raphaelpanta@gmail.com");

            act.Should ().Throw<JogoNaoPodeSerAdicionadoException> ();
        }

        [Fact]
        public void DeveEditarJogo () {
            var repositorio = new Mock<IRepositorioDeJogos> ();

            var id = Guid.NewGuid ();

            repositorio.Setup (x => x.Editar (It.IsAny<Jogo> ()));

            var servico = new ServicoDeJogos (repositorio.Object) as IServicoDeJogos;
            servico.Editar (id, new DadosDoJogo {
                Nome = "Jogo",
                    Sistema = "Super Nintendo",
                    Ano = 1990
            });
            repositorio.Verify (x => x.Editar (It.IsAny<Jogo> ()), Times.Once ());
        }

        [Fact]
        public void DeveLancarExcecaoSeNaoEditar () {
            var repositorio = new Mock<IRepositorioDeJogos> ();

            var id = Guid.NewGuid ();

            repositorio.Setup (x => x.Editar (It.IsAny<Jogo> ()))
                .Throws (new JogoNaoPodeSerEditadoException ("msg", new Exception ()));

            var servico = new ServicoDeJogos (repositorio.Object) as IServicoDeJogos;
            Action act = () => servico.Editar (id, new DadosDoJogo {
                Nome = "Jogo",
                    Sistema = "Super Nintendo",
                    Ano = 1990
            });

            act.Should ().Throw<JogoNaoPodeSerEditadoException> ();
        }

        [Fact]
        public void DeveObterJogoPeloSeuId () {
            var repositorio = new Mock<IRepositorioDeJogos> ();

            var id = Guid.NewGuid ();
            var jogo = new Jogo {
                Id = id,
                Nome = "nome",
                Sistema = "Sistema",
                Ano = 1990
            };

            repositorio.Setup (x => x.PorId (It.Is<Guid> (v => v == id)))
                .Returns (jogo);

            var servico = new ServicoDeJogos (repositorio.Object) as IServicoDeJogos;

            var resultado = servico.PorId (id);

            resultado.Should ()
                .BeEquivalentTo (new DadosDoJogo {
                    Nome = "nome",
                        Sistema = "Sistema",
                        Ano = 1990
                });
        }

        [Fact]
        public void DeveLancarExcecaoSeNaoEncontrarPorId () {
            var repositorio = new Mock<IRepositorioDeJogos>();

            repositorio.Setup(x => x.PorId(It.IsAny<Guid>()))
                .Throws(new JogoNaoPodeSerEncontradoException("msg", new Exception()));

            var servico = new ServicoDeJogos(repositorio.Object) as IServicoDeJogos;

            Action act = () => servico.PorId(Guid.NewGuid());

            act.Should().Throw<JogoNaoPodeSerEncontradoException>();
        }
    }
}