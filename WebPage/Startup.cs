using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Personal.Data;
namespace Personal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            KeyVault.SpeechKey = Configuration["speechKey1"];

            services.AddEntityFrameworkSqlite().AddDbContext<SQLiteContext>();
            services.AddDbContext<SecurityContext>();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SecurityContext>();
            services.AddRazorPages();            
            services.AddControllersWithViews(ConfigureMvcOptions);            
            services.AddScoped<IScopedService, ExampleService>();
            services.AddSingleton<ISingletonService, ExampleService>();
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}/{offset?}"
                );

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
        private void ConfigureMvcOptions(MvcOptions mvcOptions)
        {
        }
    }
}
