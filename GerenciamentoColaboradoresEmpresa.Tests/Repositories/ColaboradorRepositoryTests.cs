using GerenciamentoColaboradoresEmpresa.Domain.Models.Entities;
using GerenciamentoColaboradoresEmpresa.Infrastructure.Context;
using GerenciamentoColaboradoresEmpresa.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoColaboradoresEmpresa.Tests.Repositories
{
    public class ColaboradorRepositoryTests
    {
        [Fact]
        public async Task Deve_Retornar_Todos_Os_Colaboradores()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var colaboradores = new List<Colaborador>
                {
                    new Colaborador { Id = 1, Nome = "Colaborador 1", Cargo = "Cargo 1", Departamento = "Departamento 1" },
                    new Colaborador { Id = 2, Nome = "Colaborador 2", Cargo = "Cargo 2", Departamento = "Departamento 2" }
                };

                context.Colaboradores.AddRange(colaboradores);
                await context.SaveChangesAsync();

                var repository = new ColaboradorRepository(context);

                var result = await repository.GetAllAsync();

                Assert.NotNull(result);
                Assert.Equal(2, result.Count);
            }
        }

        [Fact]
        public async Task Deve_Retornar_Colaborador_Por_Id()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                int id = 1;
                var colaborador = new Colaborador { Id = id, Nome = "Teste", Cargo = "Cargo", Departamento = "Departamento" };
                context.Colaboradores.Add(colaborador);
                await context.SaveChangesAsync();

                var repository = new ColaboradorRepository(context);

                var result = await repository.GetByIdAsync(id);

                Assert.Equal(colaborador.Id, result.Id);
                Assert.Equal(colaborador.Nome, result.Nome);
                Assert.Equal(colaborador.Cargo, result.Cargo);
                Assert.Equal(colaborador.Departamento, result.Departamento);
            }
        }

        [Fact]
        public async Task Deve_Adicionar_Colaborador()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var repository = new ColaboradorRepository(context);

                var colaborador = new Colaborador { Id = 1, Nome = "Novo Colaborador", Cargo = "Cargo", Departamento = "Departamento" };

                await repository.AddAsync(colaborador);

                Assert.Contains(colaborador, context.Colaboradores);
            }
        }

        [Fact]
        public async Task Deve_Atualizar_Colaborador()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                var colaborador = new Colaborador { Id = 1, Nome = "Colaborador Atualizado", Cargo = "Cargo", Departamento = "Departamento" };
                context.Colaboradores.Add(colaborador);
                await context.SaveChangesAsync();

                var repository = new ColaboradorRepository(context);

                colaborador.Nome = "Colaborador Atualizado Nome";
                await repository.UpdateAsync(colaborador);

                var colaboradorAtualizado = await context.Colaboradores.FindAsync(colaborador.Id);
                Assert.Equal(colaborador.Nome, colaboradorAtualizado.Nome);
            }
        }

        [Fact]
        public async Task Deve_Deletar_Colaborador()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            using (var context = new ApplicationDbContext(options))
            {
                int id = 1;
                var colaborador = new Colaborador { Id = id, Nome = "Colaborador a ser deletado", Cargo = "Cargo", Departamento = "Departamento" };
                context.Colaboradores.Add(colaborador);
                await context.SaveChangesAsync();

                var repository = new ColaboradorRepository(context);

                await repository.DeleteAsync(id);

                var colaboradorDeletado = await context.Colaboradores.FindAsync(id);
                Assert.Null(colaboradorDeletado);
            }
        }
    }
}
