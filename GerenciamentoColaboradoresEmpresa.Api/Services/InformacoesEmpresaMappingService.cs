using GerenciamentoColaboradoresEmpresa.Api.Models.Entities;
using GerenciamentoColaboradoresEmpresa.Domain.Models.Entities;

namespace GerenciamentoColaboradoresEmpresa.Api.Services
{
    public class InformacoesEmpresaMappingService
    {
        public InformacoesEmpresaDto MapToDto(InformacoesEmpresa informacoesEmpresa)
        {
            return new InformacoesEmpresaDto
            {
                Id = informacoesEmpresa.Id,
                Nome = informacoesEmpresa.Nome,
                Endereco = informacoesEmpresa.Endereco,
                Telefone = informacoesEmpresa.Telefone
            };
        }

        public List<InformacoesEmpresaDto> MapToDto(List<InformacoesEmpresa> informacoesEmpresas)
        {
            var informacoesEmpresasDto = new List<InformacoesEmpresaDto>();
            foreach (var informacoesEmpresa in informacoesEmpresas)
            {
                informacoesEmpresasDto.Add(MapToDto(informacoesEmpresa));
            }
            return informacoesEmpresasDto;
        }

        public InformacoesEmpresa MapToEntity(InformacoesEmpresaDto informacoesEmpresaDto)
        {
            return new InformacoesEmpresa
            {
                Id = informacoesEmpresaDto.Id,
                Nome = informacoesEmpresaDto.Nome,
                Endereco = informacoesEmpresaDto.Endereco,
                Telefone = informacoesEmpresaDto.Telefone
            };
        }
    }
}
