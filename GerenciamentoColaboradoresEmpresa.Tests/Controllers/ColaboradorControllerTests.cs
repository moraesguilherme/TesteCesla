using GerenciamentoColaboradoresEmpresa.Api.Controllers;
using GerenciamentoColaboradoresEmpresa.Api.Models.Entities;
using GerenciamentoColaboradoresEmpresa.Api.Services;
using GerenciamentoColaboradoresEmpresa.Application.Services;
using GerenciamentoColaboradoresEmpresa.Domain.Models.Entities;
using GerenciamentoColaboradoresEmpresa.Domain.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace GerenciamentoColaboradoresEmpresa.Tests.Controllers
{
    public class ColaboradorControllerTests
    {
        [Fact]
        public async Task Deve_Retornar_Todos_Os_Colaboradores()
        {
            var colaboradores = new List<Colaborador>
            {
                new Colaborador { Id = 1, Nome = "Colaborador 1" },
                new Colaborador { Id = 2, Nome = "Colaborador 2" }
            };

            var realMappingService = new ColaboradorMappingService();

            var mockRepository = new Mock<IColaboradorRepository>();
            mockRepository.Setup(repo => repo.GetAllAsync()).ReturnsAsync(colaboradores);

            var realService = new ColaboradorService(mockRepository.Object);

            var controller = new ColaboradorController(realService, realMappingService);

            var result = await controller.Get();

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsAssignableFrom<IEnumerable<ColaboradorDto>>(okResult.Value);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public async Task Deve_Retornar_Colaborador_Por_Id()
        {
            var colaborador = new Colaborador { Id = 1, Nome = "Colaborador 1" };

            var realMappingService = new ColaboradorMappingService();

            var mockRepository = new Mock<IColaboradorRepository>();
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(colaborador);

            var realService = new ColaboradorService(mockRepository.Object);

            var controller = new ColaboradorController(realService, realMappingService);

            var result = await controller.Get(1);

            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsType<ColaboradorDto>(okResult.Value);
            Assert.Equal(colaborador.Id, model.Id);
            Assert.Equal(colaborador.Nome, model.Nome);
        }

        [Fact]
        public async Task Deve_Adicionar_Novo_Colaborador()
        {
            var colaboradorDto = new ColaboradorDto { Id = 1, Nome = "Colaborador 1" };

            var realMappingService = new ColaboradorMappingService();

            var mockRepository = new Mock<IColaboradorRepository>();

            var realService = new ColaboradorService(mockRepository.Object);

            var controller = new ColaboradorController(realService, realMappingService);

            var result = await controller.Post(colaboradorDto);

            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal("Get", createdAtActionResult.ActionName);
            Assert.Equal(1, createdAtActionResult.RouteValues["id"]);
        }

        [Fact]
        public async Task Deve_Atualizar_Colaborador_Existente()
        {
            var colaboradorDto = new ColaboradorDto { Id = 1, Nome = "Colaborador 1 Atualizado" };
            var existingColaborador = new Colaborador { Id = 1, Nome = "Colaborador 1" };

            var realMappingService = new ColaboradorMappingService();

            var mockRepository = new Mock<IColaboradorRepository>();
            mockRepository.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(existingColaborador);

            var realService = new ColaboradorService(mockRepository.Object);

            var controller = new ColaboradorController(realService, realMappingService);

            var result = await controller.Put(1, colaboradorDto);

            Assert.IsType<NoContentResult>(result);
        }

        [Fact]
        public async Task Deve_Deletar_Colaborador_Existente()
        {
            var existingColaborador = new Colaborador { Id = 1, Nome = "Colaborador 1" };

            var realMappingService = new ColaboradorMappingService();

            var mockRepository = new Mock<IColaboradorRepository>();
            mockRepository.Setup(repo => repo.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(existingColaborador);
            mockRepository.Setup(repo => repo.DeleteAsync(1)).Returns(Task.CompletedTask);

            var realService = new ColaboradorService(mockRepository.Object);

            var controller = new ColaboradorController(realService, realMappingService);

            var result = await controller.Delete(1);

            Assert.IsType<NoContentResult>(result);
        }
    }
}
