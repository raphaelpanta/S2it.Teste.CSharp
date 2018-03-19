using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Login;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Models;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

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
        public async Task<IActionResult> Login(CredenciaisDoUsuario credenciais) {
            if(ModelState.IsValid && _servicoDeLogin.Validar(credenciais)) {
                var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                identity.AddClaim(new Claim("email", credenciais.Email));
                identity.AddClaim(new Claim(ClaimTypes.Email, credenciais.Email));
                identity.AddClaim(new Claim(ClaimTypes.Name, credenciais.Email));
                
                await HttpContext
                .SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme, 
                    new ClaimsPrincipal(identity));

                return RedirectToAction("Index","Principal");
            }
            return View("Index", credenciais);
        }

        public IActionResult Error() => 
            View(new ErrorViewModel { 
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier 
                    });
    }
}
