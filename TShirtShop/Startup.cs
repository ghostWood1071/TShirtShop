using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Bussiness;
using Bussiness.Interfaces;
using DataAcess;
using DataAcess.Interfaces;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
namespace TShirtShop
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
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddDistributedMemoryCache();           
            services.AddSession(cfg => {                    
                cfg.Cookie.Name = "ecomerce";             
                cfg.IdleTimeout = new TimeSpan(365, 0, 0, 0); 
            });

            services.AddTransient<IDataHelper>(x => new DataHelper(Configuration.GetConnectionString("MVC")));
            services.AddTransient<IProductAcessible, ProductDataAcess>();
            services.AddTransient<ICategoryAcessible, CategoryDataAcess>();
            services.AddTransient<IAccountAcessible, UserDataAcess>();
            services.AddTransient<IOrderAcessible, OrderDataAcess>();

            services.AddTransient<IProductBuss, ProductBussiness>();
            services.AddTransient<ICategoryBuss, CategoryBussiness>();
            services.AddTransient<IUserBussiness, UserBussiness>();
            services.AddTransient<IOrderBuss, OrderBussiness>();
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
