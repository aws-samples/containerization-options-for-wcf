// Copyright Amazon.com, Inc. or its affiliates. All Rights Reserved.
// SPDX-License-Identifier: MIT-0
using CoreWCF;
using CoreWCF.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace Server
{
   public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddServiceModelServices();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.MapWhen(context => context.Request.Method == "GET" && context.Request.Path.StartsWithSegments("/health-check"), (appBuilder) =>
            {
                appBuilder.Run(async (context) =>
                {
                    await context.Response.WriteAsync("OK");
                });
            });
            app.UseServiceModel(builder =>
            {
                void ConfigureSoapService<TService, TContract>(string servicePrefix) where TService : class
                {
                    builder.AddService<TService>()
                        .AddServiceEndpoint<TService, TContract>(new BasicHttpBinding(),
                            $"/{servicePrefix}")
                        .AddServiceEndpoint<TService, TContract>(new NetTcpBinding(SecurityMode.None),
                            $"/{servicePrefix}");
                }

                ConfigureSoapService<CalculatorService, ICalculator>(nameof(CalculatorService));
                
            });
        }
    }
}
