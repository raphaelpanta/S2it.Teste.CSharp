using System;

namespace GerenciadoDeEmprestimoDeJogos.Dominio.Entidades {
    public class Amigo {
        public Guid Id { get; set; }

        public Usuario Usuario { get; set; }

        public DateTime InicioDaAmizade { get; set; }

    }
}