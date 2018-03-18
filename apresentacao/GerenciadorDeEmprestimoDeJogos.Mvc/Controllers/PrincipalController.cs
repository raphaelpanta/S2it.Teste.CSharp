using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Emprestimos;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Controllers
{
    public class PrincipalController : Controller
    {

        private IServicoDeEmprestimo _servicoDeEmprestimo;

        public PrincipalController(IServicoDeEmprestimo servicoDeEmprestimo) {
            _servicoDeEmprestimo = servicoDeEmprestimo;
        }
        public IActionResult Index() => View(_servicoDeEmprestimo.DadosDeEmprestimo(""));
    }
}