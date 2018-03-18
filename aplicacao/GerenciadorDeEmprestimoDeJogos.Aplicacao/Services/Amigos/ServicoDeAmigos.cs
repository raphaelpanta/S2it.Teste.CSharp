using System;
using System.Collections.Generic;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Amigos
{
    public class ServicoDeAmigos : IServicoDeAmigos
    {
        public void Adicionar(Guid id)
        {
          //  throw new NotImplementedException();
        }

        public IEnumerable<DadosDoAmigo> NaoAdicionados() {
                return new [] {
                    new DadosDoAmigo {AmigoId = Guid.NewGuid(), Nome = "Fulano"},
                    new DadosDoAmigo {AmigoId = Guid.NewGuid(), Nome = "Ciclano"}
                };
        }
    }
}