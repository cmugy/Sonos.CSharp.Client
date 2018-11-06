using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hive.Home.Control;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Smart.Home.Integration.Services;
using Sonos.Integration.ParameterValidation;
using Sonos.Integration.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace Sonos.Integration
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
            services.AddMvc();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Home Sonos/Hive Controller", Version = "v1", Contact = new Contact
                    {
                        Email = "collismugy@hotmail.com",
                        Name = "Collins Mugarura",
                        Url = "https://twitter.com/mugy03"
                    }
                });
            });
            
            services.AddScoped<ISonosClient, SonosClient>();
            services.AddScoped<IParameterValidator, ParameterValidator>();
            services.AddScoped<IHiveClient, HiveClient>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseMvc();
            
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sonos.Home.Client");
            });

            app.UseSwagger();
        }
    }
}
