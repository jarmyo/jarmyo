﻿using Microsoft.Extensions.Options;
using Personal.Helpers;
using System.Globalization;
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
            AzureServiceHelper.SpeechKey = Configuration["speechKey1"];
            CosmosDBHelper.PrimaryKey = Configuration["cosmosDBKey"];
            CosmosDBHelper.EndpointUri = Configuration["cosmosDBEndPoint"];
            services.AddEntityFrameworkSqlite().AddDbContext<BlogContext>();
            services.AddEntityFrameworkSqlite().AddDbContext<SchoolContext>();
            services.AddEntityFrameworkSqlite().AddDbContext<SQLiteContext>();            
            services.AddDbContext<SecurityContext>();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SecurityContext>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddRazorPages().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
            services.AddControllersWithViews(ConfigureMvcOptions);
            services.AddScoped<IScopedService, ExampleService>();
            services.AddSingleton<ISingletonService, ExampleService>();
            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("es-MX"),
                    new CultureInfo("fr-fr")
                };
                options.DefaultRequestCulture = new RequestCulture(culture: "en-US", uiCulture: "en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var locOptions = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(locOptions.Value);
            if (env.IsDevelopment())
            {
                app.UseStatusCodePagesWithReExecute("/Home/Error", "?code={0}");
                //app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
                app.UseStatusCodePagesWithReExecute("/Home/Error", "?code={0}");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "areas", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}/{offset?}");
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
            /// Initialize blog constants
            using (var ctx = new BlogContext())
            {
                Controllers.BlogController.TotalPost = ctx.Entradas.Count();
                Controllers.BlogController.TotalPages = Controllers.BlogController.TotalPost / Controllers.BlogController.MaxPages;
                if (Controllers.BlogController.TotalPages == 0) Controllers.BlogController.TotalPages = 1;
            }
        }
        private void ConfigureMvcOptions(MvcOptions mvcOptions)
        {
        }
    }
}