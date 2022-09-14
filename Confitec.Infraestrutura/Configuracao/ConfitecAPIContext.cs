using Microsoft.EntityFrameworkCore;

namespace Confitec.Infraestrutura.Configuracao
{
    public class ConfitecAPIContext : DbContext
    {
        private const string ConnectionString = "Server=(localdb)\\mssqllocaldb;Database=ConfitecAPIContext-bd63f215-97de-4951-bd9e-327187adfc61;Trusted_Connection=True;MultipleActiveResultSets=true";

        public ConfitecAPIContext(DbContextOptions<ConfitecAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Entidade.Entidade.Usuario> Usuario { get; set; }

       protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }
    }
}
