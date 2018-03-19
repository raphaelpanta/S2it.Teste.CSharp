using System;
using System.Linq;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Emprestimos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Controllers {

    public static class CtrlUtils {
        public static string GetEmailFromUser(this Controller controller) {
            return controller.HttpContext.User.Claims.First(x => x.Type.Equals("email")).Value;
        }
    }

    [Authorize]
    public class PrincipalController : Controller {

        private IServicoDeEmprestimo _servicoDeEmprestimo;

        public PrincipalController (IServicoDeEmprestimo servicoDeEmprestimo) {
            _servicoDeEmprestimo = servicoDeEmprestimo;
        }
        public IActionResult Index () => View (_servicoDeEmprestimo.DadosDeEmprestimo (this.GetEmailFromUser()));

        [HttpPost]
        public IActionResult RemoverAmigo (Guid id) {
            _servicoDeEmprestimo.DefazerAmizadePorId (id, this.GetEmailFromUser());
            return RedirectToAction ("Index", "Principal");
        }

        [HttpPost]
        public IActionResult RemoverJogo (Guid id) {
            _servicoDeEmprestimo.RemoverJogoPorId (id, this.GetEmailFromUser());
            return RedirectToAction ("Index","Principal");
        }

        [HttpPost]
        public IActionResult TomarEmprestado(Guid id){
             _servicoDeEmprestimo.TomarEmprestadoPor(id,this.GetEmailFromUser());
             return RedirectToAction ("Index","Principal");
        }
    }
}