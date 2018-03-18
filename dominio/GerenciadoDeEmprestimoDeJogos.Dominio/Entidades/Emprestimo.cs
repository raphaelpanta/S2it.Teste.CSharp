using System;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;

namespace GerenciadoDeEmprestimoDeJogos.Dominio.Entidades {
    public class Emprestimo {
        
        public Guid Id {get; set;}
        public Usuario Amigo { get; set; }

        public Jogo Jogo { get; set; }

        public DateTime DataDeEmprestimo { get; set; }

        public DateTime? DataDeDevolucao { get; set; }

        public void Devolver(IRepositorioDeEmprestimo repositorio) {
            DataDeDevolucao = DateTime.Today;
            repositorio.RegistrarDevolucao(this);
        }
    }
}