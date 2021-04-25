using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AtividadeAvaliativa.Data;
using AtividadeAvaliativa.Models.Atividade;
using AtividadeAvaliativa.Models.Teste;
using Buffet.Models.Acesso;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AtividadeAvaliativa
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
            services.AddDbContext<DataBaseContext>(optionsAction: option => option.UseMySql(Configuration.GetConnectionString(name:"BuffetDb1")));
            services.AddTransient<AcessoService>();
            services.AddTransient<TesteService>();
            services.AddIdentity<Usuario, Papel>(optinos =>
                {
                    optinos.User.RequireUniqueEmail = true;
                    optinos.Password.RequiredLength = 8;
                
                })
                .AddEntityFrameworkStores<DataBaseContext>();
            services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/Acesso/login";
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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
                    pattern: "{controller=Acesso}/{action=Login}/{id?}");
                
                endpoints.MapControllerRoute(
                    name: "admin",
                    pattern: "Admin/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}