using GerenciamentoColaboradoresEmpresa.Api.Models.Entities;
using GerenciamentoColaboradoresEmpresa.Api.Services;
using GerenciamentoColaboradoresEmpresa.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoColaboradoresEmpresa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformacoesEmpresaController : ControllerBase
    {
        private readonly InformacoesEmpresaService _informacoesEmpresaService;
        private readonly InformacoesEmpresaMappingService _informacoesEmpresaMappingService;

        public InformacoesEmpresaController(InformacoesEmpresaService informacoesEmpresaService, InformacoesEmpresaMappingService informacoesEmpresaMappingService)
        {
            _informacoesEmpresaService = informacoesEmpresaService;
            _informacoesEmpresaMappingService = informacoesEmpresaMappingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<InformacoesEmpresaDto>>> Get()
        {
            var informacoesEmpresa = await _informacoesEmpresaService.GetInformacoesEmpresaAsync();
            var informacoesEmpresaDto = _informacoesEmpresaMappingService.MapToDto(informacoesEmpresa);
            return Ok(informacoesEmpresaDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] InformacoesEmpresaDto informacoesEmpresaDto)
        {
            if (id != informacoesEmpresaDto.Id)
            {
                return BadRequest("Id do parâmetro não corresponde ao Id do objeto");
            }

            try
            {
                var informacoesEmpresa = _informacoesEmpresaMappingService.MapToEntity(informacoesEmpresaDto);
                await _informacoesEmpresaService.UpdateInformacoesEmpresaAsync(informacoesEmpresa);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro ao atualizar as informações da empresa: {ex.Message}");
            }
        }
    }
}
