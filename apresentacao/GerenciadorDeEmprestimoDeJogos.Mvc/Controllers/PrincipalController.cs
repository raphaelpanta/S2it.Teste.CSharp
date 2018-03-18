using System;
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

        [HttpPost]
        public IActionResult RemoverAmigo(Guid id)
        {
            _servicoDeEmprestimo.DefazerAmizadePorId(id);
            return RedirectToAction("Index");
        }

           [HttpPost]
        public IActionResult RemoverJogo(Guid id) {
            _servicoDeEmprestimo.RemoverJogoPorId(id);
            return Redirect("Principal");
        }
    }
}