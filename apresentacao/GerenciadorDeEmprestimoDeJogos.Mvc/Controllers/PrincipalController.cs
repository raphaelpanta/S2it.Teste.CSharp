using System;
using System.Linq;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Emprestimos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Controllers {

    [Authorize]
    public class PrincipalController : Controller {

        private IServicoDeEmprestimo _servicoDeEmprestimo;

        public PrincipalController (IServicoDeEmprestimo servicoDeEmprestimo) {
            _servicoDeEmprestimo = servicoDeEmprestimo;
        }
        public IActionResult Index () => View (_servicoDeEmprestimo.DadosDeEmprestimo (this.HttpContext.User.Claims.First(x => x.Type.Equals("email")).Value));

        [HttpPost]
        public IActionResult RemoverAmigo (Guid id) {
            _servicoDeEmprestimo.DefazerAmizadePorId (id);
            return RedirectToAction ("Index");
        }

        [HttpPost]
        public IActionResult RemoverJogo (Guid id) {
            _servicoDeEmprestimo.RemoverJogoPorId (id);
            return Redirect ("Principal");
        }
    }
}