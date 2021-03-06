using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace Personal
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
           Host.CreateDefaultBuilder(args)
             .ConfigureAppConfiguration((hostContext, builder) =>
             {
                 if (hostContext.HostingEnvironment.IsDevelopment())
                 {
                     builder.AddUserSecrets("ef7b1b6d-e3df-4fa6-8a11-2807dcc0f0fa");                     
                 }
             })
               .ConfigureWebHostDefaults(webBuilder =>
               {
                   webBuilder.UseStartup<Startup>();
               });
    }
}