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
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;

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
            services.Configure<CookiePolicyOptions>(options =>
            {

                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(opts =>
            {
                opts.LoginPath = "/admin/login";
            });

            services.AddDistributedMemoryCache();
            services.AddSession(cfg => {
                cfg.Cookie.Name = "ecomerce";
                cfg.Cookie.IsEssential = true;
                cfg.IdleTimeout = new TimeSpan(365, 0, 0, 0);
            });

            services.AddControllersWithViews().AddNewtonsoftJson();
            

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

            app.UseSession();

            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:  "MyArea",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
