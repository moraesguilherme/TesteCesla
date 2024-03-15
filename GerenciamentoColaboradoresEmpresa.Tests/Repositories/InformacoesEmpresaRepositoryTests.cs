using GerenciamentoColaboradoresEmpresa.Domain.Models.Entities;
using GerenciamentoColaboradoresEmpresa.Infrastructure.Context;
using GerenciamentoColaboradoresEmpresa.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoColaboradoresEmpresa.Tests.Repositories
{
    public class InformacoesEmpresaRepositoryTests
    {
        [Fact]
        public async Task Deve_Retornar_Todas_Informacoes_Empresa()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var informacoes = new List<InformacoesEmpresa> {
                    new InformacoesEmpresa { Id = 1, Nome = "Informacoes Empresa 1", Endereco = "Endereco 1", Telefone = "1234567890" },
                    new InformacoesEmpresa { Id = 2, Nome = "Informacoes Empresa 2", Endereco = "Endereco 2", Telefone = "9876543210" }
                };
                context.InformacoesEmpresas.AddRange(informacoes);
                await context.SaveChangesAsync();

                var repository = new InformacoesEmpresaRepository(context);

                var result = await repository.GetInformacoesEmpresaAsync();

                Assert.NotNull(result);
                Assert.Equal(2, result.Count);
            }
        }

        [Fact]
        public async Task Deve_Atualizar_Informacoes_Empresa()
        {
            var informacoes = new InformacoesEmpresa { Id = 1, Nome = "Informacoes Empresa", Endereco = "Endereco", Telefone = "Telefone" };
            var novoNome = "Novo Nome da Empresa";

            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                context.InformacoesEmpresas.Add(informacoes);
                await context.SaveChangesAsync();

                var repository = new InformacoesEmpresaRepository(context);

                informacoes.Nome = novoNome;

                await repository.UpdateInformacoesEmpresaAsync(informacoes);

                var informacoesAtualizadas = await context.InformacoesEmpresas.FindAsync(informacoes.Id);

                Assert.Equal(novoNome, informacoesAtualizadas.Nome);
            }
        }
    }
}
