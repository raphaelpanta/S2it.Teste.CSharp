using System;
using System.Linq;
using System.Security.Claims;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Emprestimos {
    public class ServicoDeEmprestimo : IServicoDeEmprestimo {

        private readonly IRepositorioDeEmprestimo _repositorio;

        private readonly ClaimsPrincipal _principal;

        public ServicoDeEmprestimo(IRepositorioDeEmprestimo repositorio, ClaimsPrincipal principal) {
            _repositorio = repositorio;
            _principal = principal;
        }

        public DadosDoEmprestimo DadosDeEmprestimo (string email) {
        
          return  _repositorio.PorEmail(email)
          .Select(x => new DadosDoEmprestimo {
              Amigos = x.Amigos.Select(a => new DadosDeAmigo {
                  Nome = a.MeuAmigo.Nome,
                  AmigoId = a.Id,
                  InicioDaAmizade = a.InicioDaAmizade,
                  JogosEmprestados = 0
              }),
              JogosEmprestados = x.Emprestimos
                .Select(je => new JogoEmprestado {
                   EmprestimoId = je.Id,
                   Nome = je.Jogo.Nome,
                   Amigo = je.Jogo.Dono.Nome,
                   Sistema = je.Jogo.Sistema
                }),
               MeusJogos = x.Jogos
                .Select(j => new DadosDeJogo {
                    JogoId = j.Id,
                    Sistema = j.Sistema,
                    Nome = j.Nome,
                    Ano = j.Ano,
                    Status = j.Emprestimo == null ? "Livre" : "Emprestado"
                })       
              }).FirstOrDefault();
    

        }

        public void DevolverJogoPorId (Guid emprestimoId) {
           var emprestimo =_repositorio.EmprestimoPor(_principal.Claims.First(x => x.Type == "email").Value, emprestimoId);
           _repositorio.RegistrarDevolucao(emprestimo.First());
        }

        public void DefazerAmizadePorId (Guid amigoId) 
           {
                _repositorio.DesfazerAmizade(_principal.Claims.First(x => x.Type == "email").Value, amigoId);
           }

        public void RemoverJogoPorId (Guid jogoId) {
            _repositorio.RemoverJogo(_principal.Claims.First(x => x.Type == "email").Value, jogoId);
        }

        public void TomarEmprestadoPor (Guid jogoId) {

            _repositorio.RegistrarEmprestimo(_principal.Claims.First(x => x.Type == "email").Value, jogoId);
        }
    }
}