using System;
using System.Linq;
using System.Security.Claims;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Emprestimos
{
    public class ServicoDeEmprestimo : IServicoDeEmprestimo
    {

        private readonly IRepositorioDeEmprestimo _repositorio;


        public ServicoDeEmprestimo(IRepositorioDeEmprestimo repositorio)
        {
            _repositorio = repositorio;
        }

        public DadosDoEmprestimo DadosDeEmprestimo(string email)
        {

            return _repositorio.PorEmail(email)
            .Select(x => new DadosDoEmprestimo
            {
                Amigos = x.Amigos.Select(a => new DadosDeAmigo
                {
                    Nome = a.MeuAmigo.Nome,
                    AmigoId = a.Id,
                    InicioDaAmizade = a.InicioDaAmizade,
                    JogosEmprestados = 0
                }),
                JogosEmprestados = x.Emprestimos
                  .Select(je => new JogoEmprestado
                  {
                      EmprestimoId = je.Id,
                      Nome = je.Jogo.Nome,
                      Amigo = je.Jogo.Dono.Nome,
                      Sistema = je.Jogo.Sistema
                  }),
                JogosAEmprestar = x.Amigos.SelectMany(a => a.MeuAmigo.Jogos).Where(j => j.Emprestimo == null || j.Emprestimo.DataDeDevolucao != null)
                  .Select(j => new JogoEmprestado
                  {
                      EmprestimoId = j.Id,
                      Nome = j.Nome,
                      Amigo = j.Dono.Nome,
                      Sistema = j.Sistema
                  })
                  ,
                MeusJogos = x.Jogos
                  .Select(j => new DadosDeJogo
                  {
                      JogoId = j.Id,
                      Sistema = j.Sistema,
                      Nome = j.Nome,
                      Ano = j.Ano,
                      Status = j.Emprestimo == null || j.Emprestimo.DataDeDevolucao != null ? "Livre" : "Emprestado"
                  })
            }).FirstOrDefault();


        }

        public void DevolverJogoPorId(Guid emprestimoId, string email)
        {
            var emprestimo = _repositorio.EmprestimoPor(email, emprestimoId);
            _repositorio.RegistrarDevolucao(emprestimo.First());
        }

        public void DefazerAmizadePorId(Guid amigoId, string email)
        {
            _repositorio.DesfazerAmizade(email, amigoId);
        }

        public void RemoverJogoPorId(Guid jogoId, string email)
        {
            _repositorio.RemoverJogo(email, jogoId);
        }

        public void TomarEmprestadoPor(Guid jogoId, string email)
        {

            _repositorio.RegistrarEmprestimo(email, jogoId);
        }
    }
}