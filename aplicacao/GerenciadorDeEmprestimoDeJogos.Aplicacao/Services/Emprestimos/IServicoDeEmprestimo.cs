using System;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Emprestimos
{
    public interface IServicoDeEmprestimo
    {
         DadosDoEmprestimo DadosDeEmprestimo(string usuario);

         void RemoverJogoPorId(Guid jogoId);

         void DevolverJogoPorId(Guid emprestimoId);

         void DefazerAmizadePorId(Guid amigoId);
     }
}