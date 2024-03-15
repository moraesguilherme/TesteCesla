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
    public class InformacoesEmpresaControllerTests
    {
        [Fact]
        public async Task Deve_Retornar_Informacoes_Empresa()
        {
            var informacoesEmpresa = new InformacoesEmpresa { Id = 1, Nome = "Empresa XYZ", Endereco = "Rua A, 123", Telefone = "123456789" };

            var realMappingService = new InformacoesEmpresaMappingService();

            var mockRepository = new Mock<IInformacoesEmpresaRepository>();
            mockRepository.Setup(repo => repo.GetInformacoesEmpresaAsync()).ReturnsAsync(new List<InformacoesEmpresa> { informacoesEmpresa });

            var realService = new InformacoesEmpresaService(mockRepository.Object);

            // Criando uma instância do InformacoesEmpresaController com o serviço real e o mapeamento real
            var controller = new InformacoesEmpresaController(realService, realMappingService);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var model = Assert.IsType<List<InformacoesEmpresaDto>>(okResult.Value);
            Assert.Single(model); // Verifica se há apenas um item na lista
            var informacoesEmpresaDto = model.FirstOrDefault();
            Assert.Equal(informacoesEmpresa.Id, informacoesEmpresaDto.Id);
            Assert.Equal(informacoesEmpresa.Nome, informacoesEmpresaDto.Nome);
            Assert.Equal(informacoesEmpresa.Endereco, informacoesEmpresaDto.Endereco);
            Assert.Equal(informacoesEmpresa.Telefone, informacoesEmpresaDto.Telefone);
        }


        [Fact]
        public async Task Deve_Atualizar_Informacoes_Empresa()
        {
            // Arrange
            var informacoesEmpresaDto = new InformacoesEmpresaDto { Id = 1, Nome = "Empresa XYZ Atualizada", Endereco = "Rua B, 456", Telefone = "987654321" };

            // Criando um mock do IInformacoesEmpresaRepository para simular o comportamento do repositório
            var mockRepository = new Mock<IInformacoesEmpresaRepository>();
            // Configurar o comportamento do repositório conforme necessário para o teste
            // Aqui, você configura o comportamento para o método UpdateInformacoesEmpresaAsync
            mockRepository.Setup(repo => repo.UpdateInformacoesEmpresaAsync(It.IsAny<InformacoesEmpresa>())).Returns(Task.CompletedTask);

            // Criando uma instância real do InformacoesEmpresaService passando o mock do repositório
            var realService = new InformacoesEmpresaService(mockRepository.Object);

            // Criando uma instância real do InformacoesEmpresaMappingService
            var realMappingService = new InformacoesEmpresaMappingService();

            // Criando uma instância do InformacoesEmpresaController com o serviço real e o mapeamento real
            var controller = new InformacoesEmpresaController(realService, realMappingService);

            // Act
            var result = await controller.Put(1, informacoesEmpresaDto);

            // Assert
            Assert.IsType<NoContentResult>(result);

            // Verifica se o método UpdateInformacoesEmpresaAsync foi chamado com os parâmetros corretos
            mockRepository.Verify(repo => repo.UpdateInformacoesEmpresaAsync(It.Is<InformacoesEmpresa>(i => i.Id == informacoesEmpresaDto.Id && i.Nome == informacoesEmpresaDto.Nome)), Times.Once);
        }



    }
}
