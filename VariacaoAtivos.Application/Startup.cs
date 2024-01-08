using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VariacaoAtivos.Domain.Entities;
using VariacaoAtivos.Domain.Interfaces;
using VariacaoAtivos.Service.Services;
using VariacaoAtivos.BD.Context;
using VariacaoAtivos.BD.Repository;


namespace VariacaoAtivos.Application
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
            services.AddDbContext<SQL>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("Conexao") ?? throw new InvalidOperationException("Connection string 'Context' not found.")));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddScoped<SQL, SQL>();
            services.AddHttpClient<IServicoAPI<Ativo>> ("", c =>
            {
                c.BaseAddress = new Uri(Configuration["ServiceUrls:BaseUrl"]);
                c.DefaultRequestHeaders.Add("Accept", "application/json");
                c.DefaultRequestHeaders.Add("User-Agent", "HttpClientFactury-sample");
            });
                   
                 
            services.AddControllers();
            services.AddScoped<IServicoAPI<Ativo>,ServicoAPI<Ativo>>();
            services.AddScoped<IBancoDados<Ativo>, BancoDados<Ativo>>();
            services.AddHostedService<AtivoResultados>();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Variacao.Ativo v1"));
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
