using GerenciamentoColaboradoresEmpresa.Domain.Models.Entities;

namespace GerenciamentoColaboradoresEmpresa.Domain.Repositories.Interfaces
{
    public interface IInformacoesEmpresaRepository
    {
        Task<List<InformacoesEmpresa>> GetInformacoesEmpresaAsync();
        Task UpdateInformacoesEmpresaAsync(InformacoesEmpresa informacoesEmpresa);
    }
}
