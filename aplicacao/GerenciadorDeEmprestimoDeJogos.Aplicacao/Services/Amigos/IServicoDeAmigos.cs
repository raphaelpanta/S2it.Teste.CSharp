using System;
using System.Collections.Generic;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Amigos
{
    public interface IServicoDeAmigos
    {
        IEnumerable<DadosDoAmigo> NaoAdicionados ();

        void Adicionar(Guid id);

    }
}