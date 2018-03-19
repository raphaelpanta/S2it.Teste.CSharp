using System;
using System.Collections.Generic;
using System.Linq;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeEmprestimos.EntityFramework {
    public class RepositorioDeAmigos : IRepositorioDeAmigos {
        private readonly EmprestimoContext _context;

        public RepositorioDeAmigos (EmprestimoContext context) {
            _context = context;
        }
        public void Adicionar (Usuario amigo, string email) {
            var usuario = _context.Usuarios.Include ("Amigos").FirstOrDefault (x => x.Credenciais.Email == email);

            usuario.Amigos.Add (new Amigo {
                Usuario = usuario,
                MeuAmigo = amigo,
                InicioDaAmizade = DateTime.Today
            });

            _context.Update(usuario);

            _context.SaveChanges ();

        }

        public IEnumerable<Usuario> NaoAdicionados (string email) {
            var usuario = _context.Usuarios.Include(x=>x.Amigos).ThenInclude(x => x.MeuAmigo).FirstOrDefault(x => x.Credenciais.Email == email);
            
            var amigos = usuario.Amigos.Select(x => x.MeuAmigo);
            return from u in _context.Usuarios
            where u.Credenciais.Email != email && !amigos.Contains(u)
            select u;
        }

        public Usuario PorEmail (string id) {
            return (from u in _context.Usuarios.Include (x => x.Credenciais)
                .Include (x => x.Amigos).ThenInclude(x => x.MeuAmigo)
                 where u.Credenciais.Email == id select u).First ();
        }

        public Usuario PorId (Guid id) {
            return (from u in _context.Usuarios where u.Id == id select u).First ();
        }
    }
}