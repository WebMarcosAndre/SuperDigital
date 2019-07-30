using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SuperDigital.Domain.Entities;
using SuperDigital.Domain.Interfaces.Repositories;
using SuperDigital.Domain.Interfaces.Services;
using SuperDigital.Infra.Data.Context;
using SuperDigital.Infra.Data.Repositories;
using SuperDigital.Services;

namespace SuperDigital.API
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<SqlContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));

            services.AddScoped<IBaseRepository<BaseEntity>, BaseRepository<BaseEntity>>();
            services.AddScoped<ILancamentoRepository, LancamentoRepository>();
            services.AddScoped<IContaRepository, ContaRepository>();

            services.AddScoped<ITransacaoBancariaService, TransacaoBancariaService>() ;
            services.AddScoped<ILancamentoDebitoService, LancamentoDebitoService>();
            services.AddScoped<ILancamentoCreditoService, LancamentoCreditoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
