using System;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Jogos
{
    public interface IServicoDeJogos
    {
         void Adicionar(DadosDoJogo jogo, string email);

         DadosDoJogo PorId(Guid id);

         void Editar(Guid id, DadosDoJogo jogo);
    }
}
