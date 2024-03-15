using GerenciamentoColaboradoresEmpresa.Domain.Models.Entities;
using GerenciamentoColaboradoresEmpresa.Domain.Repositories.Interfaces;

namespace GerenciamentoColaboradoresEmpresa.Application.Services
{
    public class ColaboradorService
    {
        private readonly IColaboradorRepository _colaboradorRepository;

        public ColaboradorService(IColaboradorRepository colaboradorRepository)
        {
            _colaboradorRepository = colaboradorRepository;
        }

        public async Task<List<Colaborador>> GetAllColaboradoresAsync()
        {
            return await _colaboradorRepository.GetAllAsync();
        }

        public async Task<Colaborador> GetColaboradorByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID", nameof(id));
            }

            return await _colaboradorRepository.GetByIdAsync(id);
        }

        public async Task AddColaboradorAsync(Colaborador colaborador)
        {
            if (colaborador == null)
            {
                throw new ArgumentNullException(nameof(colaborador), "Colaborador cannot be null");
            }

            await _colaboradorRepository.AddAsync(colaborador);
        }

        public async Task UpdateColaboradorAsync(Colaborador colaborador)
        {
            if (colaborador == null)
            {
                throw new ArgumentNullException(nameof(colaborador), "Colaborador cannot be null");
            }

            await _colaboradorRepository.UpdateAsync(colaborador);
        }

        public async Task DeleteColaboradorAsync(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Invalid ID", nameof(id));
            }

            await _colaboradorRepository.DeleteAsync(id);
        }
    }
}
