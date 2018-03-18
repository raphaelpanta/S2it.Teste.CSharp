using System;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;

namespace GerenciadoDeEmprestimoDeJogos.Dominio.Entidades
{
    public class Jogo 
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public int Ano { get; set; }

        public string Sistema { get; set; }

        public Usuario Dono { get; set; }

        public Emprestimo Emprestimo { get; set; }
    }
}