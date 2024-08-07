using GestioneHotelApp.DAO;
using GestioneHotelApp.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace GestioneHotelApp
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<GestioneHotelContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            // Registrazione dei DAO con la stringa di connessione passata come parametro
            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddScoped<PrenotazioneDao>(provider => new PrenotazioneDao(connectionString));
            services.AddScoped<PrenotazioneServizioDao>(provider => new PrenotazioneServizioDao(connectionString));
            services.AddScoped<ServizioDao>(provider => new ServizioDao(connectionString));
            services.AddScoped<TrattamentoDao>(provider => new TrattamentoDao(connectionString));
            services.AddScoped<UserDao>(provider => new UserDao(connectionString));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
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