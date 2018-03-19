using System;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Jogos {
    public class ServicoDeJogos : IServicoDeJogos {

        private readonly IRepositorioDeJogos _repositorio;
        public ServicoDeJogos (IRepositorioDeJogos repositorio) {
            _repositorio = repositorio;
        }

        public void Adicionar (DadosDoJogo jogo, string email) {
            _repositorio.Adicionar (new Jogo {
                Nome = jogo.Nome,
                    Sistema = jogo.Sistema,
                    Ano = jogo.Ano
            }, email);

        }

        public void Editar (Guid id, DadosDoJogo jogo) {
            _repositorio.Editar (new Jogo {
                    Id = id,
                    Nome = jogo.Nome,
                    Sistema = jogo.Sistema,
                    Ano = jogo.Ano
            });
        }

        public DadosDoJogo PorId (Guid id) {
            var jogo = _repositorio.PorId (id);
            return new DadosDoJogo {
                Nome = jogo.Nome,
                    Sistema = jogo.Sistema,
                    Ano = jogo.Ano
            };
        }

    }
}