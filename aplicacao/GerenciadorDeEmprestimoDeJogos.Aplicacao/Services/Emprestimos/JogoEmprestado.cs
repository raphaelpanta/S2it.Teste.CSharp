
using System;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Emprestimos
{
    public class JogoEmprestado
    {
        public Guid EmprestimoId {get; set;}
        public string Nome { get;  set; }
        public string Amigo { get;  set; }
        public string Sistema { get;  set; }
    }

}