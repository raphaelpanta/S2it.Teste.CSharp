using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Amigos {
    public class ServicoDeAmigos : IServicoDeAmigos {

        private readonly IRepositorioDeAmigos _repositorio;
        
        public ServicoDeAmigos (IRepositorioDeAmigos repositorio) {
            _repositorio = repositorio;
        }
        public void Adicionar (Guid id, string email) {
            var amigo = _repositorio.PorId (id);

            var usuarioAtual = _repositorio.PorEmail (email);

            usuarioAtual.Amigos.Add (new Amigo {
                MeuAmigo = amigo,
                InicioDaAmizade = DateTime.Today
            });

            _repositorio.Adicionar (usuarioAtual);
        }

        public IEnumerable<DadosDoAmigo> NaoAdicionados (string email) {
            return _repositorio.NaoAdicionados (email)
                .Select (x => new DadosDoAmigo {
                    AmigoId = x.Id,
                        Nome = x.Nome
                });
        }
    }
}