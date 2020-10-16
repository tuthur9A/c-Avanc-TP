using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TP.Configurations;
using TP.Data;
using TP.Repository.Book;
using TP.Repository.Shelve;
using TP.Services.Book;
using TP.Services.GoogleAPI;
using TP.Services.Shelve;

namespace TP
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
            services.AddControllers();
            ConfigureMongoDBServices(services);
            ConfigureDependencyInjectionServices(services);
            ConfigureHttpClientServices(services);
            // Add AutoMapper.
            services.AddAutoMapper(typeof(Startup).Assembly);
        }

                /// <summary>
        /// Configure mongodb service.
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureMongoDBServices(IServiceCollection services)
        {
            //TODO: Configuration n'est pas accèssible pour les tests (waste)
            // requires using Microsoft.Extensions.Options
            services.Configure<MessagingDbSettings>(
                Configuration.GetSection(nameof(MessagingDbSettings)));

            services.AddSingleton<IMessagingDbSettings>(sp =>
                sp.GetRequiredService<IOptions<MessagingDbSettings>>().Value);

            services.AddSingleton<MessagingDbContext>();

        }

                /// <summary>
        /// Configure dependency injection service.
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureDependencyInjectionServices(IServiceCollection services)
        {
            ///Service
            services.AddTransient<IBooksService, BooksService>();
            services.AddTransient<IShelvesService, ShelvesService>();
            ///Repo
            services.AddTransient<IBooksRepository, BooksRepository>();
            services.AddTransient<IShelvesRepository, ShelvesRepository>();
        }

         /// <summary>
        /// Configure http client service.
        /// </summary>
        /// <param name="services"></param>
        private void ConfigureHttpClientServices(IServiceCollection services)
        {
            services.AddHttpClient<IGoogleAPIClientService, GoogleAPIClientService>(c =>
            {
                c.DefaultRequestHeaders.Accept.Clear();
                c.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AutoMapper.IConfigurationProvider autoMapper)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            autoMapper.AssertConfigurationIsValid();
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
