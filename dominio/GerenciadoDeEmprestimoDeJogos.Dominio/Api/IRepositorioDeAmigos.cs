using System;
using System.Collections.Generic;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;

namespace GerenciadoDeEmprestimoDeJogos.Dominio.Api
{
    public interface IRepositorioDeAmigos
    {
        IEnumerable<Usuario> NaoAdicionados (string email);

        Usuario PorId(Guid id);

        Usuario PorEmail(string id);

        void Adicionar(Usuario amigo);
    }

    public class UsuarioNaoEncontradoException : Exception {}

    public class NaoPodeAdicionarAmigo: Exception {}
}