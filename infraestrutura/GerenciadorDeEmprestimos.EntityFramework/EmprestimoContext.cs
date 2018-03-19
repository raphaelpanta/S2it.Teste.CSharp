using GerenciadoDeEmprestimoDeJogos.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeEmprestimos.EntityFramework {
    public class EmprestimoContext : DbContext {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Jogo> Jogos { get; set; }

        public EmprestimoContext (DbContextOptions<EmprestimoContext> options) : base (options) {
        }

        protected override void OnModelCreating (ModelBuilder modelBuilder) {
            modelBuilder.Entity<Usuario> ()
                .OwnsOne (u => u.Credenciais);

            modelBuilder.Entity<Usuario>()
            .OwnsOne(u => u.Endereco);
        }
    }
}