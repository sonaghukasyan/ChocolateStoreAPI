using ChocolateStoreAPI.DataFile;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ChocolateStoreAPI.Models;
using Microsoft.OpenApi.Models;

namespace ChocolateStoreAPI
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
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ChocolateStoreAPI", Version = "v1" });
            });
            services.AddSingleton<IDataAccess<Chocolate>, DataAccess<Chocolate>>();
        }

        //A
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChocolateStoreAPI v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        //B
    }
}
//   app.Use(async (context, next) =>
//    {
//        await context.Response.WriteAsync("<p>Request goes here first.</p>");
//        await next();
//        await context.Response.WriteAsync("<p>Response goes back</p>");
//    });

////with next delegate we send the request to the next middleware,
////comtext is plaxceholder for current http context
//app.Use(async (context, next) =>
//{
//    await context.Response.WriteAsync("<p>Hello world 2.</p>");
//    await next();
//});