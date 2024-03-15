using GerenciamentoColaboradoresEmpresa.Application.Services;
using GerenciamentoColaboradoresEmpresa.Domain.Models.Entities;
using GerenciamentoColaboradoresEmpresa.Domain.Repositories.Interfaces;
using Moq;

namespace GerenciamentoColaboradoresEmpresa.Tests.Services
{
    public class InformacoesEmpresaServiceTests
    {
        [Fact]
        public async Task Deve_Retornar_A_Lista_Com_Todas_As_Informacoes_Empresa()
        {
            var mockRepository = new Mock<IInformacoesEmpresaRepository>();
            mockRepository.Setup(repo => repo.GetInformacoesEmpresaAsync())
                          .ReturnsAsync(new List<InformacoesEmpresa> { new InformacoesEmpresa(), new InformacoesEmpresa() });
            var service = new InformacoesEmpresaService(mockRepository.Object);

            var result = await service.GetInformacoesEmpresaAsync();

            Assert.NotNull(result);
            Assert.IsType<List<InformacoesEmpresa>>(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task Deve_Atualizar_As_Informacoes_Empresa()
        {
            var informacoesEmpresa = new InformacoesEmpresa();
            var mockRepository = new Mock<IInformacoesEmpresaRepository>();
            var service = new InformacoesEmpresaService(mockRepository.Object);

            await service.UpdateInformacoesEmpresaAsync(informacoesEmpresa);

            mockRepository.Verify(repo => repo.UpdateInformacoesEmpresaAsync(informacoesEmpresa), Times.Once);
        }

        [Fact]
        public async Task Deve_Lancar_Excecao_Quando_Nao_Encontrar_Informacoes_Empresa()
        {
            var mockRepository = new Mock<IInformacoesEmpresaRepository>();
            mockRepository.Setup(repo => repo.GetInformacoesEmpresaAsync())
                          .ReturnsAsync(() => null);
            var service = new InformacoesEmpresaService(mockRepository.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => service.GetInformacoesEmpresaAsync());
        }

        [Fact]
        public async Task Deve_Lancar_Excecao_Quando_Atualizar_Informacoes_Empresa_Nula()
        {
            InformacoesEmpresa informacoesEmpresa = null;
            var mockRepository = new Mock<IInformacoesEmpresaRepository>();
            var service = new InformacoesEmpresaService(mockRepository.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.UpdateInformacoesEmpresaAsync(informacoesEmpresa));
        }

    }
}
