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
using ZdravaHranaNinaData;
using ZdravaHranaNinaRepositories.ZdravaHranaNinaAPI;
using ZdravaHranaNinaRepositories.ZdravaHranaNinaAPI.Interfaces;
using ZdravaHranaNinaServices.ZdravaHranaNinaAPI;
using ZdravaHranaNinaServices.ZdravaHranaNinaAPI.Interfaces;

namespace ZdravaHranaNinaAPI
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
            services.AddCors(c => c.AddPolicy("CorsPolicy", builder => builder.AllowAnyMethod().AllowAnyHeader().WithOrigins()));
            services.AddControllers();
            //DB Context
            services.AddDbContext<DataContext>(option => option.UseSqlServer(Configuration["ConnectionStrings:LaraViConnection"]));
            //Services
            services.AddTransient<ICategoryRepositoryAPI, CategoryRepositoryAPI>();
            services.AddTransient<ICategoryServiceAPI, CategoryServiceAPI>();
            services.AddTransient<IProductRepositoryAPI, ProductRepositoryAPI>();
            services.AddTransient<IProductServiceAPI, ProductServiceAPI>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors("CorsPolicy");
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
