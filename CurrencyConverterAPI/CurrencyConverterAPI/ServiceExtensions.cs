using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace CurrencyConverter
{
    public static class ServiceExtensions
    {
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                    builder.WithOrigins("https://localhost:5001")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
            });
        }

        public static void ConfigureExceptionHandling(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(app =>
            {
                app.Run(async context =>
                {
                    // Write exception to log here
                    var exception = context.Features.Get<IExceptionHandlerPathFeature>().Error;
                    
                    // Handle exceptions here
                    await context.Response.WriteAsJsonAsync(new {Error = "An error has occured"});
                });
            });
        }
    }
}