using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Login;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Controllers
{
    public class CadastroController : Controller
    {

        private readonly IServicoDeLogin _servicoDeLogin;

        public CadastroController(IServicoDeLogin servicoDeLogin) {
            _servicoDeLogin = servicoDeLogin;
        }
        public IActionResult Index() => View(new DadosDoUsuario());

        [HttpPost]
        public IActionResult Cadastrar(DadosDoUsuario dados) {
            if(ModelState.IsValid) 
            { 
                _servicoDeLogin.Cadastrar(dados);
                TempData["Sucesso"] = "Cadastrado com sucesso! Por favor entrar novamente com suas credenciais";
                return RedirectToAction("Index","Home");
            } 

            return View(dados);
        }
    }
}