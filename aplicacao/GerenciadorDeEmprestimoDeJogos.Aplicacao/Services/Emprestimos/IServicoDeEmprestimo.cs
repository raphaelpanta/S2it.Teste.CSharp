using System;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Emprestimos
{
    public interface IServicoDeEmprestimo
    {
         DadosDoEmprestimo DadosDeEmprestimo();

         void RemoverJogoPorId(Guid jogoId);

         void TomarEmprestadoPor(Guid emprestimoId);

         void DevolverJogoPorId(Guid emprestimoId);

         void DefazerAmizadePorId(Guid amigoId);
     }
}