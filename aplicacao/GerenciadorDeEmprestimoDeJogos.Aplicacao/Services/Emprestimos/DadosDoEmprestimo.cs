using System.Collections.Generic;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Emprestimos
{
    public class DadosDoEmprestimo
    {
        public IEnumerable<DadosDeAmigo> Amigos { get; set; }

        public IEnumerable<DadosDeJogo> MeusJogos { get; set;} 

        public IEnumerable<JogoEmprestado> JogosEmprestados { get;  set; }
    }
}