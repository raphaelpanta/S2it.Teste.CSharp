using System;

namespace GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Emprestimos
{
    public class ServicoDeEmprestimo : IServicoDeEmprestimo
    {
        public DadosDoEmprestimo DadosDeEmprestimo(string usuario) 
            => new DadosDoEmprestimo {
                JogosEmprestados = new [] {
                    new JogoEmprestado { EmprestimoId = Guid.NewGuid(), Nome = "Chrono Trigger", Amigo = "Leonardo", Sistema = "Super Nintendo" },
                    new JogoEmprestado { EmprestimoId = Guid.NewGuid(), Nome = "Sonic 3D", Amigo = "André", Sistema = "Mega Driver"}
                },
                Amigos = new [] {
                    new DadosDeAmigo { AmigoId = Guid.NewGuid(), Nome = "André", InicioDaAmizade = new DateTime(2016, 2, 2),  JogosEmprestados = 0 },
                    new DadosDeAmigo { AmigoId = Guid.NewGuid(), Nome = "Leonardo", InicioDaAmizade = new DateTime(2017, 2, 3), JogosEmprestados = 1 }
                },
                MeusJogos = new [] {
                    new DadosDeJogo { JogoId = Guid.NewGuid(),  Nome = "Silent Hill", Sistema = "PlayStation", Ano = 2001, Status = "Livre" },
                    new DadosDeJogo { JogoId = Guid.NewGuid(), Nome = "Final Fantasy XV", Sistema = "PlayStation 4/PRO", Ano = 2016, Status = "Livre" }
                }
            };

        public void DevolverJogoPorId(Guid emprestimoId)
        {
            throw new NotImplementedException();
        }

        public void DefazerAmizadePorId(Guid amigoId)
        {
             throw new NotImplementedException();
        }

        public void RemoverJogoPorId(Guid jogoId)
        {
            throw new NotImplementedException();
        }

    }
}