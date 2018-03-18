using System;

namespace GerenciadoDeEmprestimoDeJogos.Dominio.Entidades {
    public class Amigo {

        public Usuario Usuario { get; set; }

        public Usuario MeuAmigo { get; set;}

        public DateTime InicioDaAmizade { get; set; }

    }
}