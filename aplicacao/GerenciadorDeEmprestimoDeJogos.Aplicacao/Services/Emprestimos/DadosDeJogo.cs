using System;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Emprestimos
{
    public class DadosDeJogo
    {
        public Guid JogoId {get; set;}
        public string Nome {get; set;}

        public string Sistema {get; set;}

        public int Ano {get; set;}

        public string Status {get;set;}
    }
}