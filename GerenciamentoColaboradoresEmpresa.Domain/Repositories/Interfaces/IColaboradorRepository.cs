using GerenciamentoColaboradoresEmpresa.Domain.Models.Entities;

namespace GerenciamentoColaboradoresEmpresa.Domain.Repositories.Interfaces
{
    public interface IColaboradorRepository
    {
        Task<List<Colaborador>> GetAllAsync();
        Task<Colaborador> GetByIdAsync(int id);
        Task AddAsync(Colaborador colaborador);
        Task UpdateAsync(Colaborador colaborador);
        Task DeleteAsync(int id);
    }
}
