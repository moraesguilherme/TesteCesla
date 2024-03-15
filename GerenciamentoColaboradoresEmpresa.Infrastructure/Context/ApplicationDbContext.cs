using GerenciamentoColaboradoresEmpresa.Domain.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoColaboradoresEmpresa.Infrastructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<InformacoesEmpresa> InformacoesEmpresas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
