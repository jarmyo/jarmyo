using Microsoft.AspNetCore.Hosting;
[assembly: HostingStartup(typeof(Personal.Areas.Identity.IdentityHostingStartup))]
namespace Personal.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {               
            });
        }
    }
}