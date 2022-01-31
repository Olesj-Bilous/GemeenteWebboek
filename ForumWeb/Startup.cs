using ForumData.Repositories.DbConnect;
using ForumData.Repositories.Interface;
using ForumData.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Http;
using ForumService;

namespace ForumWeb
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
            services.AddControllersWithViews();

            //Sessionstate
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            
            //Database connection
            services.AddDbContext<GemeenteForumDbContext>(options =>
              options
                .UseSqlServer(Configuration.GetConnectionString("EFGemeenteForum"),
                    x => x.MigrationsAssembly("ForumData")));


            //Layer service
            services.AddTransient<AdresService>();
            services.AddTransient<IAdresRepository, AdresRepository>();

            services.AddTransient<IAfdelingRepository, AfdelingRepository>();
            services.AddTransient<IBerichtRepository, BerichtRepository>();
            services.AddTransient<IBerichtThemaRepository, BerichtThemaRepository>();

            services.AddTransient<GemeenteService>();
            services.AddTransient<IGemeenteRepository, GemeenteRepository>();

            services.AddTransient<InteresseService>();
            services.AddTransient<IInteresseRepository, InteresseRepository>();

            services.AddTransient<PersoonService>();
            services.AddTransient<IPersoonRepository, PersoonRepository>();
            services.AddTransient<IMedewerkerRepository, MedewerkerRepository>();

            services.AddTransient<ProfielService>();
            services.AddTransient<IProfielRepository, ProfielRepository>();

            services.AddTransient<ProfielInteresseService>();
            services.AddTransient<IProfielInteresseRepository, ProfielInteresseRepository>();

            services.AddTransient<IProvincieRepository, ProvincieRepository>();

            services.AddTransient<StraatService>();
            services.AddTransient<IStraatRepository, StraatRepository>();

            services.AddTransient<TaalService>();
            services.AddTransient<ITaalRepository, TaalRepository>();

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
                
            }

            app.UseSession();
            
            app.UseStaticFiles();
            app.UseRouting();

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
