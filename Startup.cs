using AspNetCorePlayground.Data;
using AspNetCorePlayground.ModelBinders.Providers;
using AspNetCorePlayground.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AspNetCorePlayground
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
            services.AddDbContextPool<PlaygroundContext>(opt =>
            {
                opt.UseMySql(Configuration.GetConnectionString("Playground"));
            });

            services.AddDefaultIdentity<IdentityUser>(opt =>
            {
                opt.Password.RequireDigit = true;
            })
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<PlaygroundContext>();

            services.AddControllersWithViews(
                opt =>
                {
                    opt.ModelBinderProviders.Insert(0, new YearModelBinderProvider());
                    opt.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                });
            services.AddRazorPages();

            services.AddTransient<IDateTimeService, DateTimeService>();
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
                app.UseStatusCodePagesWithRedirects("/Home/HttpError?statusCode={0}");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
