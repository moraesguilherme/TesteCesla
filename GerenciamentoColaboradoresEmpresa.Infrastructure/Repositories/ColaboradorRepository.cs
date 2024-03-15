using GerenciamentoColaboradoresEmpresa.Domain.Models.Entities;
using GerenciamentoColaboradoresEmpresa.Infrastructure.Context;
using GerenciamentoColaboradoresEmpresa.Domain.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoColaboradoresEmpresa.Infrastructure.Repositories
{
    public class ColaboradorRepository : IColaboradorRepository
    {
        private readonly ApplicationDbContext _context;

        public ColaboradorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Colaborador>> GetAllAsync()
        {
            return await _context.Colaboradores.ToListAsync();
        }

        public async Task<Colaborador> GetByIdAsync(int id)
        {
            return await _context.Colaboradores.FindAsync(id);
        }

        public async Task AddAsync(Colaborador colaborador)
        {
            _context.Colaboradores.Add(colaborador);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Colaborador colaborador)
        {
            _context.Colaboradores.Update(colaborador);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var colaborador = await GetByIdAsync(id);
            if (colaborador != null)
            {
                _context.Colaboradores.Remove(colaborador);
                await _context.SaveChangesAsync();
            }
        }
    }
}
