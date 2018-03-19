using System;
using System.Collections.Generic;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;

namespace GerenciadoDeEmprestimoDeJogos.Dominio.Api {
    public interface IRepositorioDeEmprestimo {
        IEnumerable<Usuario> PorEmail (string email);

        IEnumerable<Emprestimo> EmprestimoPor(string email, Guid id);

        void RegistrarDevolucao(string email, Guid id);

        void DesfazerAmizade(string email, Guid amigoId);

        void RemoverJogo(string email, Guid jogoId);

        void RegistrarEmprestimo(string email, Guid jogoId);
    }
}