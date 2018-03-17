using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GerenciadorDeEmprestimoDeJogos.Mvc.Models.Cadastro;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Controllers
{
    public class CadastroController : Controller
    {
        public IActionResult Index() => View(new DadosDoUsuario());

        [HttpPost]
        public IActionResult Index(DadosDoUsuario dados) {
            if(ModelState.IsValid) 
            { 
                return Redirect("Home");
            } 

            return View(dados);
        }
    }
}