using AutoMapper;
using FluentValidation;
using LocacaoFilmes.App.Mappings;
using LocacaoFilmes.App.Models.Cadastro;
using LocacaoFilmes.App.Validacao;
using LocacaoFilmes.Negocios.Cadastro;
using LocacaoFilmes.Repositorio.Data;
using LocacaoFilmes.Repositorio.EntityCore;
using LocacaoFilmes.Repositorio.Migracao;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LocacaoFilmes.App
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
            var mappingConfig = new MapperConfiguration(mc => mc.AddProfile(new MapearPerfil()));
            services.AddSingleton(mappingConfig.CreateMapper());

            services.AddDbContext<EntityDataContext>(options => options.UseSqlServer(Configuration.GetConnectionString("FilmeLocadoraSql")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<EntityDataContext>();

            services.AddControllersWithViews();
            services.AddRazorPages();

            //a Partir daqui poderia usa o boostrap inject para fazer injeção de dependencia automatica.

            //instancio os repositorios
            services.AddScoped(typeof(IGeneroRepositorio), typeof(GeneroRepositorio));
            services.AddScoped(typeof(IFilmeRepositorio), typeof(FilmeRepositorio));
            services.AddScoped(typeof(IFilmeLocacaoRepositorio), typeof(FilmeLocacaoRepositorio));
            services.AddScoped(typeof(ILocacaoRepositorio), typeof(LocacaoRepositorio));

            //instancio os Serviços
            services.AddScoped<IGeneroCrudServico, GeneroCrudServico>();
            services.AddScoped<IFilmeCrudServico, FilmeCrudServico>();
            services.AddScoped<ILocacaoCrudServico, LocacaoCrudServico>();

            //Validacao com Fluent
            services.AddScoped<IValidator<GeneroCadastroModel>, GeneroValidacao>();
            services.AddScoped<IValidator<FilmeCadastroModel>, FilmeValidacao>();
            services.AddScoped<IValidator<LocacaoCadastroModel>, LocacaoValidacao>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MigracaoLocadora<EntityDataContext>();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
