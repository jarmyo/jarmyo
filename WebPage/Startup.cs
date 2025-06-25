using Microsoft.Extensions.Options;
using Personal.Helpers;
using System.Globalization;
namespace Personal
{
    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            AzureServiceHelper.SpeechKey = Configuration["speechKey1"];
            CosmosDBHelper.PrimaryKey = Configuration["cosmosDBKey"];
            CosmosDBHelper.EndpointUri = Configuration["cosmosDBEndPoint"];
            services.AddEntityFrameworkSqlite().AddDbContext<BlogContext>();
            services.AddDbContext<SecurityContext>();
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<SecurityContext>();
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddRazorPages().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix).AddDataAnnotationsLocalization();
            services.AddControllersWithViews(ConfigureMvcOptions);
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
            services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "JulianWebAPI", Version = "v2" });
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "JulianWebAPI");
            });
        }
        private void ConfigureMvcOptions(MvcOptions mvcOptions)
        {
        }
    }
}