using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeEmprestimos.EntityFramework
{
    public class EmprestimoContext : DbContext
    {
        public DbSet<Usuario> Usuarios {get; set;}

        public DbSet<Jogo> Jogos {get;set;}

    }
}