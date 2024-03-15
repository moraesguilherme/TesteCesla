using GerenciamentoColaboradoresEmpresa.Api.Services;
using GerenciamentoColaboradoresEmpresa.Application.Services;
using GerenciamentoColaboradoresEmpresa.Domain.Repositories.Interfaces;
using GerenciamentoColaboradoresEmpresa.Infrastructure.Context;
using GerenciamentoColaboradoresEmpresa.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoColaboradoresEmpresa.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseMySql(Configuration.GetConnectionString("DefaultConnection"),
                    ServerVersion.AutoDetect(Configuration.GetConnectionString("DefaultConnection"))));

            services.AddScoped<InformacoesEmpresaService>();
            services.AddScoped<InformacoesEmpresaMappingService>();
            services.AddScoped<ColaboradorService>();
            services.AddScoped<ColaboradorMappingService>();
            services.AddScoped<IColaboradorRepository, ColaboradorRepository>();
            services.AddScoped<IInformacoesEmpresaRepository, InformacoesEmpresaRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "GerenciamentoColaboradoresEmpresa Api", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "GerenciamentoColaboradoresEmpresa Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
