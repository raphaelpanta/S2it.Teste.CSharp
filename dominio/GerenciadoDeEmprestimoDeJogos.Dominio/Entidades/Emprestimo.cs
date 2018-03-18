using System;

namespace GerenciadoDeEmprestimoDeJogos.Dominio.Entidades {
    public class Emprestimo {
        public Usuario Amigo { get; set; }

        public Jogo Jogo { get; set; }

        public DateTime DataDeEmprestimo { get; set; }

        public DateTime DataDeDevolucao { get; set; }
    }
}