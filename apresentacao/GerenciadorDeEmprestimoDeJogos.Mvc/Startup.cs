﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Amigos;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Emprestimos;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Jogos;
using GerenciadorDeEmprestimoDeJogos.Aplicacao.Services.Login;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorDeEmprestimoDeJogos.Mvc
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<IServicoDeLogin, ServicoDeLogin>()
            .AddScoped<IServicoDeEmprestimo, ServicoDeEmprestimo>()
            .AddScoped<IServicoDeAmigos, ServicoDeAmigos>()
            .AddScoped<IServicoDeJogos, ServicoDeJogos>();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o => o.LoginPath = new PathString("/Home"));

            services.AddTransient<ClaimsPrincipal>(s => s.GetService<HttpContextAccessor>()?.HttpContext?.User);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseResponseBuffering();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseAuthentication();
        }
    }
}
