using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Anow.PingPong.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;


namespace Anow.PingPong.Api
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
            services.AddDbContext<GameContext>(opt => opt.UseInMemoryDatabase("GameVault"));
            
            // Service Created when needed, at initialization
            services.AddTransient<SeedData>();
            services.AddMvc();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();

            using (var scope = app.ApplicationServices.CreateScope())
                {
                    var seeder = scope.ServiceProvider.GetService<SeedData>();
                    seeder.Seed();
                }



        }
    }
}
