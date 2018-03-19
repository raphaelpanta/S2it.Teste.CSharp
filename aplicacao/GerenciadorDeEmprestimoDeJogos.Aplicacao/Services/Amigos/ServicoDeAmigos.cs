using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Amigos {
    public class ServicoDeAmigos : IServicoDeAmigos {

        private readonly IRepositorioDeAmigos _repositorio;
        private readonly ClaimsPrincipal _principal;

        public ServicoDeAmigos (IRepositorioDeAmigos repositorio, ClaimsPrincipal principal) {
            _repositorio = repositorio;
            _principal = principal;
        }
        public void Adicionar (Guid id) {
            var amigo = _repositorio.PorId (id);

            var usuarioAtual = _repositorio.PorEmail (_principal.FindFirst (x => x.Type == "email").Value);

            usuarioAtual.Amigos.Add (new Amigo {
                MeuAmigo = amigo,
                InicioDaAmizade = DateTime.Today
            });

            _repositorio.Adicionar (usuarioAtual);
        }

        public IEnumerable<DadosDoAmigo> NaoAdicionados () {
            return _repositorio.NaoAdicionados (_principal.FindFirst (x => x.Type == "email").Value)
                .Select (x => new DadosDoAmigo {
                    AmigoId = x.Id,
                        Nome = x.Nome
                });
        }
    }
}