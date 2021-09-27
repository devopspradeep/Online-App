using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineApp.Web.UI;
using OnlineApp.Web.UI.IServices;
using OnlineApp.Web.UI.Services;

namespace Web
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
            services.AddHttpClient<IProductService, ProductService>();
            StaticConfiguration.ProductAPIBase = Configuration["ServiceUrls:productAPI"];
            services.AddScoped<IProductService, ProductService>();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

        

            //app.UseMvc(routes =>
            //{
            //    routes.MapRoute(
            //        name: "goto_one",
            //        template: "one",
            //        defaults: new { controller = "Home", action = "PageOne" });

            //    routes.MapRoute(
            //        name: "goto_two",
            //        template: "two/{id?}",
            //        defaults: new { controller = "Home", action = "PageTwo" });

            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            //});

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
  

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });
        }
    }
}
