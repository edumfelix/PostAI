using Microsoft.EntityFrameworkCore;

namespace PostAIWebAPI.Models.Context
{
    public class PsqlContext : DbContext
    {
        public PsqlContext() { }
        public PsqlContext(DbContextOptions<PsqlContext> options) : base(options) { }

        public DbSet<DadosCliente> DadosClientes { get; set; }
    }
}
