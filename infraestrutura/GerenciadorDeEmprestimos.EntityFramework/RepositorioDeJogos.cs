using System;
using System.Linq;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeEmprestimos.EntityFramework
{
    public class RepositorioDeJogos : IRepositorioDeJogos
    {
        private EmprestimoContext _context;

        public RepositorioDeJogos(EmprestimoContext context) {
            _context = context;
        }
        public void Adicionar(Jogo jogo)
        {
            _context.Jogos.Add(jogo);
            
            _context.SaveChanges();
        }

        public void Editar(Jogo jogo)
        {
            _context.Entry(jogo).State = EntityState.Modified;
        }

        public Jogo PorId(Guid id)
        {
            return _context.Jogos.FirstOrDefault(x => x.Id == id);
        }
    }
}