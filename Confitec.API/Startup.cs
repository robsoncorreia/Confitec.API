using Confitec.Aplicacao.Aplicacao;
using Confitec.Aplicacao.Interface;
using Confitec.Dominio.Interface;
using Confitec.Dominio.Interface.Generico;
using Confitec.Dominio.Interface.InterfaceServico;
using Confitec.Dominio.Servico;
using Confitec.Infraestrutura.Repositorio;
using Confitec.Infraestrutura.Repositorio.Generico;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Confitec.API
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
            _ = services.AddControllers();


            _ = services.AddSingleton(typeof(IGenerico<>), typeof(GenericoRepositorio<>));
            _ = services.AddSingleton<IUsuario, UsuarioRepositorio>();
            _ = services.AddSingleton<IUsuarioServico, UsuarioServico>();
            _ = services.AddSingleton<IAplicacaoUsuario, AplicacaoUsuario>();


        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                _ = app.UseDeveloperExceptionPage();
            }

            _ = app.UseHttpsRedirection();

            _ = app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            _ = app.UseRouting();

            _ = app.UseAuthorization();

            _ = app.UseEndpoints(endpoints =>
            {
                _ = endpoints.MapControllers();
            });
        }
    }
}
