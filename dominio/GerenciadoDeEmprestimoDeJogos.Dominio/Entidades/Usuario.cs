using System;
using System.Collections.Generic;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;

namespace GerenciadoDeEmprestimoDeJogos.Dominio.Entidades
{
    public class Usuario : IRaizDaAgregacao
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public Credenciais Credenciais {get; set;}

        public DateTime DataDeNascimento { get;set; }

        public Endereco Endereco { get; set; }

        public ICollection<Amigo> Amigos { get; set; }

        public ICollection<Jogo> Jogos { get; set; }

    }
}