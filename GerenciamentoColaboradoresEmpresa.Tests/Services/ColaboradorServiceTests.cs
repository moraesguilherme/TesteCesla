using GerenciamentoColaboradoresEmpresa.Application.Services;
using GerenciamentoColaboradoresEmpresa.Domain.Models.Entities;
using GerenciamentoColaboradoresEmpresa.Domain.Repositories.Interfaces;
using Moq;

namespace GerenciamentoColaboradoresEmpresa.Tests.Services
{
    public class ColaboradorServiceTests
    {
        [Fact]
        public async Task Deve_Retornar_A_Lista_Com_Todos_Os_Colaboradores()
        {
            var mockRepository = new Mock<IColaboradorRepository>();
            mockRepository.Setup(repo => repo.GetAllAsync())
                          .ReturnsAsync(new List<Colaborador> { new Colaborador(), new Colaborador() });
            var service = new ColaboradorService(mockRepository.Object);

            var result = await service.GetAllColaboradoresAsync();

            Assert.NotNull(result);
            Assert.IsType<List<Colaborador>>(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task Deve_Retornar_O_Colaborador_Pelo_Id()
        {
            int id = 1;
            var colaborador = new Colaborador { Id = id, Nome = "Teste" };
            var mockRepository = new Mock<IColaboradorRepository>();
            mockRepository.Setup(repo => repo.GetByIdAsync(id))
                          .ReturnsAsync(colaborador);
            var service = new ColaboradorService(mockRepository.Object);

            var result = await service.GetColaboradorByIdAsync(id);

            Assert.NotNull(result);
            Assert.Equal(id, result.Id);
            Assert.Equal(colaborador.Nome, result.Nome);
        }

        [Fact]
        public async Task Deve_Adicionar_Um_Colaborador()
        {
            var colaborador = new Colaborador { Nome = "Novo Colaborador" };
            var mockRepository = new Mock<IColaboradorRepository>();
            var service = new ColaboradorService(mockRepository.Object);

            await service.AddColaboradorAsync(colaborador);

            mockRepository.Verify(repo => repo.AddAsync(colaborador), Times.Once);
        }

        [Fact]
        public async Task Deve_Atualizar_Um_Colaborador()
        {
            var colaborador = new Colaborador { Id = 1, Nome = "Colaborador Atualizado" };
            var mockRepository = new Mock<IColaboradorRepository>();
            var service = new ColaboradorService(mockRepository.Object);

            await service.UpdateColaboradorAsync(colaborador);

            mockRepository.Verify(repo => repo.UpdateAsync(colaborador), Times.Once);
        }

        [Fact]
        public async Task Deve_Deletar_Um_Colaborador()
        {
            int id = 1;
            var mockRepository = new Mock<IColaboradorRepository>();
            var service = new ColaboradorService(mockRepository.Object);

            await service.DeleteColaboradorAsync(id);

            mockRepository.Verify(repo => repo.DeleteAsync(id), Times.Once);
        }

        [Fact]
        public async Task Deve_Lancar_Excecao_Quando_Tentar_Adicionar_Colaborador_Nulo()
        {
            var mockRepository = new Mock<IColaboradorRepository>();
            var service = new ColaboradorService(mockRepository.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.AddColaboradorAsync(null));
        }

        [Fact]
        public async Task Deve_Lancar_Excecao_Quando_Tentar_Atualizar_Colaborador_Nulo()
        {
            var mockRepository = new Mock<IColaboradorRepository>();
            var service = new ColaboradorService(mockRepository.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => service.UpdateColaboradorAsync(null));
        }

        [Fact]
        public async Task Deve_Lancar_Excecao_Quando_Tentar_Deletar_Colaborador_Com_Id_Invalido()
        {
            int id = 0;
            var mockRepository = new Mock<IColaboradorRepository>();
            var service = new ColaboradorService(mockRepository.Object);

            await Assert.ThrowsAsync<ArgumentException>(() => service.DeleteColaboradorAsync(id));
        }

        [Fact]
        public async Task Deve_Lancar_Excecao_Quando_Tentar_Obter_Colaborador_Com_Id_Invalido()
        {
            int id = 0;
            var mockRepository = new Mock<IColaboradorRepository>();
            var service = new ColaboradorService(mockRepository.Object);

            await Assert.ThrowsAsync<ArgumentException>(() => service.GetColaboradorByIdAsync(id));
        }
    }
}
