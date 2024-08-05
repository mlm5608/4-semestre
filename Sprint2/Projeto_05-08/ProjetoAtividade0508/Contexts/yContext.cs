using Projeto_Atividade_05_08.Domains;
using Microsoft.EntityFrameworkCore;

namespace ProjetoAtividade0508.Contexts
{
    public class yContext : DbContext
    {
        public yContext()
        {
        }

        public yContext(DbContextOptions<yContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Products> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Data Source=NOTE10-SALA21; initial catalog=ApiTeste_Miguel; User Id = sa; pwd = Senai@134; TrustServerCertificate=true;");
    }
}
