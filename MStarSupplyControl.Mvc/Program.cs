using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MStarSupplyControl.Infrastructure.Context;
using MStarSupplyControl.Infrastructure.DynamicParametersRepository;
using MStarSupplyControl.Infrastructure.Interfaces;
using MStarSupplyControl.Infrastructure.Repository;
using MStarSupplyControl.IoC.Adapters;
using MStarSupplyControl.IoC.Interfaces;
using MStarSupplyControl.Application.Services;
using Microsoft.AspNetCore.Http;
using MStarSupplyControl.IoC.Helpers;

namespace MStarSupplyControl.Mvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddScoped<IConexao, Conexao>();
            builder.Services.AddScoped<IGerenciamentoRepository, GerenciamentoRepository>();
            builder.Services.AddScoped<IGerenciamentoParameters, GerenciamentoParameters>();
            builder.Services.AddScoped<IGerenciamentoAdapter, GerenciamentoAdapter>();
            builder.Services.AddScoped<IGerenciamentoService, GerenciamentoService>();
            builder.Services.AddScoped<IPossuiEstoqueService, PossuiEstoqueService>();
            builder.Services.AddScoped<IMercadoriaRepository, MercadoriaRepository>();
            builder.Services.AddScoped<IMercadoriaParameters, MercadoriaParameters>();
            builder.Services.AddScoped<IRelatorioParameters, RelatorioParameters>();
            builder.Services.AddScoped<IMercadoriaAdapter, MercadoriaAdapter>();
            builder.Services.AddScoped<IMercadoriaService, MercadoriaService>();
            builder.Services.AddScoped<IRelatorioService, RelatorioService>();
            builder.Services.AddScoped<IRelatorioRepository, RelatorioRepository>();
            builder.Services.AddScoped<IRelatorioAdapter, RelatorioAdapter>();
            builder.Services.AddScoped<IRelatorioPdfService, RelatorioPdfService>();
            builder.Services.AddScoped<IUsuarioParameters, UsuarioParameters>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IUsuarioAdapter, UsuarioAdapter>();    
            builder.Services.AddScoped<ISessao, Sessao>();


            builder.Services.AddSession(o =>
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Login}/{action=Index}/{id?}");

            app.Run();
        }
    }
}