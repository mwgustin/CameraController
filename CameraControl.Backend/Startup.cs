using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using CameraControl.Common;
using CameraControl.Service.Vaddio;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace CameraControl.Backend
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
            // services.AddSingleton<VaddioControlTelnet>();
            services.AddHttpClient<VaddioControlHttp>(config => 
                {
                    config.BaseAddress = new Uri("http://10.0.0.5/");
                })
                .ConfigurePrimaryHttpMessageHandler(() => new HttpClientHandler(){ CookieContainer = new System.Net.CookieContainer()});
            services.AddTransient<CameraResolver>(sp => key =>
            {
                switch(key)
                {
                    case "1":
                        return sp.GetRequiredService<VaddioControlHttp>();
                    // case "2":
                    //     return sp.GetRequiredService<VaddioControlTelnet>();
                    default:
                        return sp.GetRequiredService<VaddioControlHttp>();
                }
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CameraControl.Backend", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CameraControl.Backend v1"));
            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
