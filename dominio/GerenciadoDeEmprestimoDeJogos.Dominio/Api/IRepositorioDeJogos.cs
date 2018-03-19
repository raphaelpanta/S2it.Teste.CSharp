using System;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;

namespace GerenciadoDeEmprestimoDeJogos.Dominio.Api
{
    public interface IRepositorioDeJogos
    {
         void Adicionar(Jogo jogo, string email);

         Jogo PorId(Guid id);

         void Editar(Jogo jogo);
    }

    public class JogoNaoPodeSerAdicionadoException : Exception {
        public JogoNaoPodeSerAdicionadoException(string msg, Exception e) : base(msg, e) {}
    }

    
    public class JogoNaoPodeSerEditadoException : Exception {
        public JogoNaoPodeSerEditadoException(string msg, Exception e) : base(msg, e) {}
    }

    
    public class JogoNaoPodeSerEncontradoException : Exception {
        public JogoNaoPodeSerEncontradoException(string msg, Exception e) : base(msg, e) {}
    }
}