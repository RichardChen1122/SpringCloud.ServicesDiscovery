using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SpringCould.Service1.Controllers;
using Steeltoe.Common.Http.Discovery;
using Steeltoe.Discovery.Client;

namespace SpringCould.Service1
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
            services.AddDiscoveryClient(Configuration);
            //services.AddTransient<DiscoveryHttpMessageHandler>();

            // Configure a HttpClient
            //services.AddHttpClient("fortunes", c =>
            //{
            //    c.BaseAddress = new Uri("http://product/api/values");
            //})
            //.AddHttpMessageHandler<DiscoveryHttpMessageHandler>().
            //AddTypedClient<IFortuneService, FortuneService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //app.UseHttpsRedirection();
            app.UseMvc();
            app.UseDiscoveryClient();
        }
    }
}
