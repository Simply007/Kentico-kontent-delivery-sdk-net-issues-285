using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Kentico.Kontent.Delivery.Caching.Extensions;
using Kentico.Kontent.Delivery.Caching;

namespace test5
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddStackExchangeRedisCache(options =>
            // {
            //     // Copy the connection string from the Access key tab in Azure Portal
            //     options.Configuration = "<your_instance>.redis.cache.windows.net:6380,password=<your_pwd>,ssl=True,abortConnect=False";
            //     options.InstanceName = "SampleInstance";
            // });

            services.AddDeliveryClientCache(new DeliveryCacheOptions()
            {
                CacheType = CacheTypeEnum.Distributed
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });
        }
    }
}
