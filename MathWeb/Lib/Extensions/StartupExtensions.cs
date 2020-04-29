using MathService.Function;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MathWeb
{
    public static class StartupExtensions
    {
        public static void ConfigureRoutes(this IRouteBuilder builder)
        {

            builder.MapRoute(
                name: "calculate-function-data",
                template: "calculate-function-data/{xlist}",
                defaults: new { action = "CalculateFunctionExampleData", controller = "Function" }
            );
            builder.MapRoute(
                name: "calculate-function-data-base",
                template: "Function/CalculateFunctionExampleData/{xlist}",
                defaults: new { action = "CalculateFunctionExampleData", controller = "Function" }
            );

            builder.MapRoute(
                name: "calculate-function-example",
                template: "calculate-function-example",
                defaults: new { action = "CalculateFunctionExample", controller = "Function" }
            );
            
            
            builder.MapRoute(
                name: "default",
                template: "{controller}/{action}/{id?}",
                defaults: new { action = "ShowAll", controller = "Main" }
            );

        }


        public static void ConfigureServices(this IServiceCollection services)
        {
            services
                .AddMvc()
            .AddJsonOptions(jsonOptions =>
             {
                 jsonOptions.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
             });

            services.AddScoped<IFunctionCalculation<double>, FunctionCalculation>();
            services.AddScoped<IFunctionService<double>, FunctionService<double>>();
        }

    }
}
