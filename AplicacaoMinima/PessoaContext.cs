using Microsoft.EntityFrameworkCore;

namespace AplicacaoMinima
{
    public class PessoaContext:DbContext
    {
        public PessoaContext(DbContextOptions<PessoaContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }

        public DbSet<Pessoa> TAB_PESSOA { get; set; }
        public DbSet<PessoaFilho> TAB_PESSOA_FILHO { get; set; }
    }
}
