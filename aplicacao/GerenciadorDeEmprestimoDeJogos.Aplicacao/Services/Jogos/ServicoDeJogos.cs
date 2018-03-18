using System;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Jogos
{
    public class ServicoDeJogos : IServicoDeJogos
    {
        public void Adicionar(DadosDoJogo jogo)
        {
           // throw new NotImplementedException();
        }

        public void Editar(Guid id, DadosDoJogo jogo)
        {
          //  throw new NotImplementedException();
        }

        public DadosDoJogo PorId(Guid id)
        {
         //   throw new NotImplementedException();

         return new DadosDoJogo {
             Nome = "Nome",
             Ano = 1971,
             Sistema = "Snes" 
            };
        }

    }
}