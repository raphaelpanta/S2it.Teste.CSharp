using System;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Jogos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeEmprestimoDeJogos.Mvc.Controllers
{
    [Authorize]
    public class JogoController : Controller
    {
        private readonly IServicoDeJogos _servicoDeJogos;

        public JogoController(IServicoDeJogos servicoDeJogos){
            _servicoDeJogos = servicoDeJogos;
        }

        public IActionResult Index() {
            return View(new DadosDoJogo());
        }

        [HttpPost]
        public IActionResult Index(DadosDoJogo jogo) {
            if(ModelState.IsValid) {
                _servicoDeJogos.Adicionar(jogo);
                return Redirect("Principal");
            }

            return View(jogo);
        }

        public IActionResult Editar(Guid id){
            return View("Index", _servicoDeJogos.PorId(id));
        }
    }
}