using ForumWeb.Models;
using ForumData.Repositories.DbConnect;
using ForumData.Repositories.Interface;
using ForumData.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


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
            //Database connection
            services.AddDbContext<GemeenteForumDbContext>(options =>
              //connectionstring
              options.UseSqlServer(Configuration.GetConnectionString("EFGemeenteForum"),
              //Migration files dump destitantion
              x => x.MigrationsAssembly("ForumData")));
            //MaxBatchSize --> zie swimlane "Brainstorm"

            //Layer service
            services.AddTransient<IAdresRepository, AdresRepository>();
            services.AddTransient<IAfdelingRepository, AfdelingRepository>();
            services.AddTransient<IBerichtRepository, BerichtRepository>();
            services.AddTransient<IBerichtTypeRepository, BerichtTypeRepository>();
            services.AddTransient<IGemeenteRepository, GemeenteRepository>();
            services.AddTransient<IInteresseRepository, InteresseRepository>();
            services.AddTransient<IMedewerkerRepository, MedewerkerRepository>();
            services.AddTransient<IProfielRepository, ProfielRepository>();
            services.AddTransient<IProfielInteresse, ProfielInteresseRepository>();
            services.AddTransient<IProvincieRepository, ProvincieRepository>();
            services.AddTransient<IStraatRepository, StraatRepository>();
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
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        
    }
}
