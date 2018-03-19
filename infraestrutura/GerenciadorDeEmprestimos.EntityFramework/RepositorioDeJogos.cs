using System;
using System.Linq;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeEmprestimos.EntityFramework {
    public class RepositorioDeJogos : IRepositorioDeJogos {
        private EmprestimoContext _context;

        public RepositorioDeJogos (EmprestimoContext context) {
            _context = context;
        }
        public void Adicionar (Jogo jogo, string email) {
            _context.Jogos.Add (jogo);

            var usuario = _context.Usuarios.Include("Jogos").FirstOrDefault (x => x.Credenciais.Email.Equals (email));

            usuario.Jogos.Add (jogo);

            _context.SaveChanges ();
        }

        public void Editar (Jogo jogo) {
            _context.Update(jogo);
            _context.SaveChanges ();
        }

        public Jogo PorId (Guid id) {
            return _context.Jogos.FirstOrDefault (x => x.Id == id);
        }
    }
}