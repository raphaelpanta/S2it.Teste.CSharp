using System;
using System.Linq;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeEmprestimos.EntityFramework {
    public class RepositorioDeUsuario : IRepositorioDeUsuario {
        private EmprestimoContext _context;

        public RepositorioDeUsuario (EmprestimoContext context) {
            _context = context;
        }
        public void Cadastrar (Usuario usuario) {
            _context.Add(usuario);
            _context.SaveChanges ();
        }

        public Guid NewSalt () {
            return Guid.NewGuid ();
        }

        public Credenciais Por (string email) {
            return _context.Usuarios.Include(u => u.Credenciais).Select (x => x.Credenciais).FirstOrDefault (x => x.Email == email);
        }
    }
}