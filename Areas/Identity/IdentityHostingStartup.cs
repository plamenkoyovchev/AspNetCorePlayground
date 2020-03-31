using System;
using AspNetCorePlayground.Areas.Identity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(AspNetCorePlayground.Areas.Identity.IdentityHostingStartup))]
namespace AspNetCorePlayground.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AspNetCorePlaygroundIdentityDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AspNetCorePlaygroundIdentityDbContextConnection")));

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AspNetCorePlaygroundIdentityDbContext>();
            });
        }
    }
}