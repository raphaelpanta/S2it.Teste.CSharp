using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GerenciadorDeEmprestimoDeJogos.Mvc.Models;
using GerenciadorDeEmprestimoDeJogos.Mvc.Models.Cadastro;
using GerenciadorDeEmprestimoDeJogos.Mvc.Services;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServicoDeLogin _servicoDeLogin;

        public HomeController(IServicoDeLogin servicoDeLogin) {
            _servicoDeLogin = servicoDeLogin;
        }
        public IActionResult Index() => View();

        [HttpPost]
        public IActionResult Login(CredenciaisDoUsuario credenciais) {
            if(ModelState.IsValid && _servicoDeLogin.Validar(credenciais)) {
                return Redirect("Principal");
            }
            return View("Index", credenciais);
        }

        public IActionResult Error() => 
            View(new ErrorViewModel { 
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
                    });
    }
}
