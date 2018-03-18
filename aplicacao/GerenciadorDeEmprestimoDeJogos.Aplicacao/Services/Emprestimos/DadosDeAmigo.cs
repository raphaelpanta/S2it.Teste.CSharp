using System;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Emprestimos
{
    public class DadosDeAmigo
    {
        public Guid AmigoId {get; set;}
        
        public string Nome {get; set;}

        public DateTime InicioDaAmizade {get; set;}

        public int JogosEmprestados  {get; set;}
    }
}