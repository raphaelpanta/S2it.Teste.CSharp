using System;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;

namespace GerenciadoDeEmprestimoDeJogos.Dominio.Entidades {
    public class Emprestimo {
        
        public Guid Id {get; set;}
        public Usuario Usuario {get; set;}
        public Jogo Jogo { get; set; }

        public DateTime DataDeEmprestimo { get; set; }

        public DateTime? DataDeDevolucao { get; set; }

        public void Devolver() {
            DataDeDevolucao = DateTime.Today;
        }
    }
}