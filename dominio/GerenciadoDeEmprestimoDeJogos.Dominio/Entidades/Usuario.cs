using System;
using System.Collections.Generic;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;

namespace GerenciadoDeEmprestimoDeJogos.Dominio.Entidades
{
    public class Usuario : IRaizDaAgregacao
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public virtual Credenciais Credenciais {get; set;}

        public DateTime DataDeNascimento { get;set; }

        public virtual Endereco Endereco { get; set; }

        public virtual ICollection<Amigo> Amigos { get; set; }

        public virtual ICollection<Jogo> Jogos { get; set; }

        public virtual ICollection<Emprestimo> Emprestimos { get; set; }
    }
}