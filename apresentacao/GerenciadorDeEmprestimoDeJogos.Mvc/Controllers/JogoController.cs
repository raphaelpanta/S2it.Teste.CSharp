using System;
using System.Linq;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Jogos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Controllers {
    [Authorize]
    public class JogoController : Controller {
        private readonly IServicoDeJogos _servicoDeJogos;

        public JogoController (IServicoDeJogos servicoDeJogos) {
            _servicoDeJogos = servicoDeJogos;
        }

        public IActionResult Index () {
            return View (new DadosDoJogo ());
        }

        [HttpPost]
        public IActionResult Index (DadosDoJogo jogo) {
            if (ModelState.IsValid) {
                _servicoDeJogos.Adicionar (jogo, this.HttpContext.User.Claims.First (x => x.Type.Equals ("email")).Value);
                return Redirect ("Principal");
            }

            return View (jogo);
        }

        [HttpPost]
        public IActionResult Editar (Guid id, DadosDoJogo jogo) {
            if (ModelState.IsValid) {
                _servicoDeJogos.Editar (id, jogo);
                return RedirectToAction ("Index", "Principal");
            }

            return View (jogo);
        }

        public IActionResult Editar (Guid id) {
            return View ( _servicoDeJogos.PorId (id));
        }
    }
}