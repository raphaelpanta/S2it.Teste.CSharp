using System;

namespace GerenciadoDeEmprestimoDeJogos.Dominio.Entidades {
    public class Amigo {

        public Guid Id {get; set;}

        public Usuario Usuario { get; set;}
       
        public Guid UsuarioId { get;set; } 

        public Guid MeuAmigoId {get; set;}

        public Usuario MeuAmigo { get;set;}

        public DateTime InicioDaAmizade { get; set; }

    }
}