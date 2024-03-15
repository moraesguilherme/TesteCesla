using GerenciamentoColaboradoresEmpresa.Domain.Models.Entities;
using GerenciamentoColaboradoresEmpresa.Domain.Repositories.Interfaces;

namespace GerenciamentoColaboradoresEmpresa.Application.Services
{
    public class InformacoesEmpresaService
    {
        private readonly IInformacoesEmpresaRepository _informacoesEmpresaRepository;

        public InformacoesEmpresaService(IInformacoesEmpresaRepository informacoesEmpresaRepository)
        {
            _informacoesEmpresaRepository = informacoesEmpresaRepository;
        }

        public async Task<List<InformacoesEmpresa>> GetInformacoesEmpresaAsync()
        {
            var informacoesEmpresaList = await _informacoesEmpresaRepository.GetInformacoesEmpresaAsync();
            if (informacoesEmpresaList == null)
            {
                throw new InvalidOperationException("Failed to retrieve information about the company.");
            }

            return await _informacoesEmpresaRepository.GetInformacoesEmpresaAsync();
        }

        public async Task UpdateInformacoesEmpresaAsync(InformacoesEmpresa informacoesEmpresa)
        {
            if (informacoesEmpresa == null)
            {
                throw new ArgumentNullException(nameof(informacoesEmpresa), "Information about the company cannot be null.");
            }

            await _informacoesEmpresaRepository.UpdateInformacoesEmpresaAsync(informacoesEmpresa);
        }
    }
}
