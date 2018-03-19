using System;
using System.Linq;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Amigos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Controllers
{
    [Authorize]
    public class AmigosController : Controller
    {
        private readonly IServicoDeAmigos _servicoDeAmigos;
        public AmigosController(IServicoDeAmigos servicoDeAmigos) {
            _servicoDeAmigos = servicoDeAmigos;
        }
        public IActionResult Index() {
            return View(_servicoDeAmigos.NaoAdicionados(this.HttpContext.User.Claims.First(x => x.Type.Equals("email")).Value));
        }

        [HttpPost]
        public IActionResult Index(Guid id) {
            _servicoDeAmigos.Adicionar(id, this.HttpContext.User.Claims.First(x => x.Type.Equals("email")).Value);
            return View(_servicoDeAmigos.NaoAdicionados(this.HttpContext.User.Claims.First(x => x.Type.Equals("email")).Value));
        }
    }
}