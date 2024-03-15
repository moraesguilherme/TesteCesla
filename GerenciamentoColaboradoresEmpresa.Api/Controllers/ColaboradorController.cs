using GerenciamentoColaboradoresEmpresa.Api.Models.Entities;
using GerenciamentoColaboradoresEmpresa.Api.Services;
using GerenciamentoColaboradoresEmpresa.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GerenciamentoColaboradoresEmpresa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColaboradorController : ControllerBase
    {
        private readonly ColaboradorService _colaboradorService;
        private readonly ColaboradorMappingService _dtoMappingService;

        public ColaboradorController(ColaboradorService colaboradorService, ColaboradorMappingService dtoMappingService)
        {
            _colaboradorService = colaboradorService;
            _dtoMappingService = dtoMappingService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ColaboradorDto>>> Get()
        {
            var colaboradores = await _colaboradorService.GetAllColaboradoresAsync();
            var colaboradoresDto = _dtoMappingService.MapToDto(colaboradores);
            return Ok(colaboradoresDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ColaboradorDto>> Get(int id)
        {
            var colaborador = await _colaboradorService.GetColaboradorByIdAsync(id);
            if (colaborador == null)
            {
                return NotFound();
            }
            var colaboradorDto = _dtoMappingService.MapToDto(colaborador);
            return Ok(colaboradorDto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ColaboradorDto colaboradorDto)
        {
            if (colaboradorDto == null)
            {
                return BadRequest("Invalid data");
            }

            var colaborador = _dtoMappingService.MapToEntity(colaboradorDto);
            await _colaboradorService.AddColaboradorAsync(colaborador);
            return CreatedAtAction(nameof(Get), new { id = colaborador.Id }, colaboradorDto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] ColaboradorDto colaboradorDto)
        {
            if (colaboradorDto == null || id != colaboradorDto.Id)
            {
                return BadRequest("Invalid data");
            }

            var existingColaborador = await _colaboradorService.GetColaboradorByIdAsync(id);
            if (existingColaborador == null)
            {
                return NotFound();
            }

            var colaborador = _dtoMappingService.MapToEntityForUpdate(existingColaborador, colaboradorDto);
            await _colaboradorService.UpdateColaboradorAsync(colaborador);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var existingColaborador = await _colaboradorService.GetColaboradorByIdAsync(id);
            if (existingColaborador == null)
            {
                return NotFound();
            }

            await _colaboradorService.DeleteColaboradorAsync(id);
            return NoContent();
        }
    }
}
