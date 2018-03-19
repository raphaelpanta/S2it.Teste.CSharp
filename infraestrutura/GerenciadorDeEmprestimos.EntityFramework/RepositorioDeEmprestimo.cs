using System;
using System.Collections.Generic;
using System.Linq;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeEmprestimos.EntityFramework {
    public class RepositorioDeEmprestimo : IRepositorioDeEmprestimo {
        private EmprestimoContext _context;
        public RepositorioDeEmprestimo (EmprestimoContext context) {
            _context = context;
        }
        public void DesfazerAmizade (string email, Guid amigoId) {
            var usuario = _context.Usuarios.FirstOrDefault (x => x.Credenciais.Email == email);
            var amigo = _context.Usuarios.Include(x => x.Amigos).Where (x => x.Credenciais.Email == email).ToList().SelectMany (x => x.Amigos).FirstOrDefault (x => x.Id == amigoId);
       
            usuario.Amigos.Remove (amigo);

            _context.SaveChanges ();
        }

        public IEnumerable<Emprestimo> EmprestimoPor (string email, Guid id) {
            return _context.Usuarios.Include (x => x.Emprestimos).Where (x => x.Credenciais.Email == email).SelectMany (x => x.Emprestimos).Where (x => x.Id == id);
        }

        public IEnumerable<Usuario> PorEmail (string email) {
            return _context.Usuarios.Include(x =>x.Amigos).ThenInclude(x => x.MeuAmigo).Include(x =>x.Emprestimos).Include(x =>x.Jogos).Where (x => x.Credenciais.Email == email).ToList();
        }

        public void RegistrarDevolucao (Emprestimo emprestimo) {
            _context.Entry (emprestimo).State = EntityState.Modified;
            _context.SaveChanges ();
        }

        public void RegistrarEmprestimo (string email, Guid jogoId) {
            var emprestimo = new Emprestimo {
                Jogo = _context.Jogos.FirstOrDefault (x => x.Id == jogoId),
                DataDeEmprestimo = DateTime.Today
            };

            var usuario = _context.Usuarios.FirstOrDefault (x => x.Credenciais.Email == email);
            usuario.Emprestimos.Add (emprestimo);

            _context.SaveChanges ();
        }

        public void RemoverJogo (string email, Guid jogoId) {
            var jogo = _context.Jogos.FirstOrDefault (x => x.Id == jogoId);
            var usuario = _context.Usuarios.FirstOrDefault (x => x.Credenciais.Email == email);
            usuario.Jogos.Remove (jogo);
            _context.SaveChanges ();
        }
    }
}