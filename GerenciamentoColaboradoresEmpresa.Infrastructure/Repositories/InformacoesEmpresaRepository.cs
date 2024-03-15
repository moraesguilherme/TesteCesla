using GerenciamentoColaboradoresEmpresa.Domain.Models.Entities;
using GerenciamentoColaboradoresEmpresa.Infrastructure.Context;
using GerenciamentoColaboradoresEmpresa.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoColaboradoresEmpresa.Infrastructure.Repositories
{
    public class InformacoesEmpresaRepository : IInformacoesEmpresaRepository
    {
        private readonly ApplicationDbContext _context;

        public InformacoesEmpresaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<InformacoesEmpresa>> GetInformacoesEmpresaAsync()
        {
            return await _context.InformacoesEmpresas.ToListAsync();
        }

        public async Task UpdateInformacoesEmpresaAsync(InformacoesEmpresa informacoesEmpresa)
        {
            _context.InformacoesEmpresas.Update(informacoesEmpresa);
            await _context.SaveChangesAsync();
        }
    }
}
