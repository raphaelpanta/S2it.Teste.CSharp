using System;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;

namespace GerenciadoDeEmprestimoDeJogos.Dominio.Api
{
    public interface IRepositorioDeUsuario
    {
         Credenciais Por(string email);

         void Cadastrar(Usuario usuario);

         Guid NewSalt();
    }

    public class CadastroNaoRealizadoException : Exception 
    {
        public CadastroNaoRealizadoException(string msg, Exception e): base(msg,e) {}
    }
}