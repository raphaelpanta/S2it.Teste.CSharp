using System;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Emprestimos
{
    public interface IServicoDeEmprestimo
    {
         DadosDoEmprestimo DadosDeEmprestimo(string email);

         void RemoverJogoPorId(Guid jogoId, string email);

         void TomarEmprestadoPor(Guid emprestimoId, string email);

         void DevolverJogoPorId(Guid emprestimoId, string email);

         void DefazerAmizadePorId(Guid amigoId, string email);
     }
}