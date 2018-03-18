using System;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Amigos;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Controllers
{
    public class AmigosController : Controller
    {
        private readonly IServicoDeAmigos _servicoDeAmigos;
        public AmigosController(IServicoDeAmigos servicoDeAmigos) {
            _servicoDeAmigos = servicoDeAmigos;
        }
        public IActionResult Index() {
            return View(_servicoDeAmigos.NaoAdicionados());
        }

        [HttpPost]
        public IActionResult Index(Guid id) {
            _servicoDeAmigos.Adicionar(id);
            return View(_servicoDeAmigos.NaoAdicionados());
        }
    }
}