using GerenciamentoColaboradoresEmpresa.Domain.Models.Entities;
using GerenciamentoColaboradoresEmpresa.Api.Models.Entities;

namespace GerenciamentoColaboradoresEmpresa.Api.Services
{
    public class ColaboradorMappingService
    {
        public ColaboradorDto MapToDto(Colaborador colaborador)
        {
            return new ColaboradorDto
            {
                Id = colaborador.Id,
                Nome = colaborador.Nome,
                Cargo = colaborador.Cargo,
                Departamento = colaborador.Departamento,
                Ativo = colaborador.Ativo,
                InformacoesEmpresaId = colaborador.InformacoesEmpresaId
            };
        }

        public List<ColaboradorDto> MapToDto(List<Colaborador> colaboradores)
        {
            var colaboradoresDto = new List<ColaboradorDto>();
            foreach (var colaborador in colaboradores)
            {
                colaboradoresDto.Add(MapToDto(colaborador));
            }
            return colaboradoresDto;
        }

        public Colaborador MapToEntity(ColaboradorDto colaboradorDto)
        {
            return new Colaborador
            {
                Id = colaboradorDto.Id,
                Nome = colaboradorDto.Nome,
                Cargo = colaboradorDto.Cargo,
                Departamento = colaboradorDto.Departamento,
                Ativo = colaboradorDto.Ativo,
                InformacoesEmpresaId = colaboradorDto.InformacoesEmpresaId
            };
        }

        public Colaborador MapToEntityForUpdate(Colaborador existingColaborador, ColaboradorDto colaboradorDto)
        {
            existingColaborador.Nome = colaboradorDto.Nome;
            existingColaborador.Cargo = colaboradorDto.Cargo;
            existingColaborador.Departamento = colaboradorDto.Departamento;
            existingColaborador.Ativo = colaboradorDto.Ativo;
            existingColaborador.InformacoesEmpresaId = colaboradorDto.InformacoesEmpresaId;

            return existingColaborador;
        }
    }
}
