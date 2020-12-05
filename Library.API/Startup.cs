using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Library.Core.Interfaces;
using Library.Core.Services;
using Library.Infrastructure.Data;
using Library.Infrastructure.Repositories;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Library.API
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
            services.AddControllers().AddNewtonsoftJson(options => 
            {
                //Ignoramos la referencia ciclica
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                //Cuando este serializando y encuentre una propiedad null, no la muestre
                options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            });

             services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();
            services.AddDbContext<LibraryContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("LibraryConectionString"));
            });

            //Dependency Injection
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IAuthorService, AuthorService>();

            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IBookService, BookService>();
            
            services.AddTransient<IGenderRepository, GenderRepository>();
            services.AddTransient<IGenderService, GenderService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
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
