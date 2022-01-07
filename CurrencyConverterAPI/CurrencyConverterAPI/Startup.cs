using CurrencyConverter.Context;
using CurrencyConverter.Interfaces;
using CurrencyConverter.Repository;
using MediatR;
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
            
            services.AddMediatR(typeof(Startup));
            
            services.ConfigureCors();
            
            services.AddScoped<IConversionRepository, ConversionRepository>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "CurrencyConverterAPI", Version = "v1"});
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.ConfigureExceptionHandling();
            
            if (env.IsDevelopment())
            {
                // app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CurrencyConverterAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            
            app.UseCors();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}