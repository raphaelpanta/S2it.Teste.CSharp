using System;
using System.Collections.Generic;
using System.Linq;
using GerenciadoDeEmprestimoDeJogos.Dominio.Api;
using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeEmprestimos.EntityFramework
{
    public class RepositorioDeAmigos : IRepositorioDeAmigos
    {
        private readonly EmprestimoContext _context;

        public RepositorioDeAmigos(EmprestimoContext context) {
                _context = context;
        }
        public void Adicionar(Usuario amigo)
        {
            _context.Entry(amigo).State = EntityState.Modified;

            _context.SaveChanges();
            
        }

        public IEnumerable<Usuario> NaoAdicionados(string email)
        {
            return from u in _context.Usuarios 
                   from a in _context.Usuarios
                   where u.Credenciais.Email == email && !u.Amigos.Select(x =>x.MeuAmigo).Contains(a) 
                select a;
        }

        public Usuario PorEmail(string id)
        {
            return (from u in _context.Usuarios
                   where u.Credenciais.Email == id
                   select u).First();
        }

        public Usuario PorId(Guid id)
        {
            return (from u in _context.Usuarios 
             where u.Id == id 
             select u).First();
        }
    }
}