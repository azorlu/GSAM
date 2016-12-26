﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using GSAM.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GSAM
{
    public class Startup
    {
        IConfigurationRoot Configuration;

        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["Data:GSAMData:ConnectionString"]));
            services.AddTransient<IPlayerRepository, EFPlayerRepository>();
            services.AddTransient<ITournamentRepository, EFTournamentRepository>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                name: null,
                template: "{category}/Page{page:int}",
                defaults: new { Controller = "Tournament", action = "List" });

                routes.MapRoute(
                name: null,
                template: "Page{page:int}",
                defaults: new { Controller = "Tournament", action = "List", page = 1 });

                routes.MapRoute(
                name: null,
                template: "{category}",
                defaults: new { Controller = "Tournament", action = "List", page = 1 });

                routes.MapRoute(
               name: null,
               template: "",
               defaults: new { Controller = "Tournament", action = "List", page = 1 });

                routes.MapRoute(
               name: null,
               template: "{controller}/{action}/{id?}");
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
