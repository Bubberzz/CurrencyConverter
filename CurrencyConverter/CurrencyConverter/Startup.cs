using CurrencyConverter.Context;
using CurrencyConverter.Interfaces;
using CurrencyConverter.Repository;
using CurrencyConverter.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace CurrencyConverter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddDbContext<ExchangeRateDbContext>(options => options.UseInMemoryDatabase("ExchangeRates"));
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.WithOrigins("https://localhost:5001")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });
            services.AddScoped<IConversionRepository, ConversionRepository>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            // services.AddScoped<IConversionService, ConversionService>();
            services.AddScoped(typeof(IConversionService), typeof(ConversionService) );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "CurrencyConverter", Version = "v1"});
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CurrencyConverter v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}