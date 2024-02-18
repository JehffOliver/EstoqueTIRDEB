using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using EstoqueTIRDEB.Data;
using EstoqueTIRDEB.Ropositorio;
using EstoqueTIRDEB.Helper;
using Microsoft.AspNetCore.Mvc;
using EstoqueTIRDEB.Services;

namespace EstoqueTIRDEB
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<EstoqueTIRDEBContext>(options =>
             options.UseMySql(Configuration.GetConnectionString("EstoqueTIRDEBContext"), builder =>
                builder.MigrationsAssembly("EstoqueTIRDEB")));

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
            services.AddScoped<UsuarioRepositorio>();
            services.AddScoped<ISessao, Sessao>();
            services.AddScoped<ItensService>();
            services.AddScoped<EstoqueService>();

            services.AddSession(o => 
            {
                o.Cookie.HttpOnly = true;
                o.Cookie.IsEssential = true;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            app.UseCookiePolicy();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Usuarios}/{action=Index}/{id?}");
            });
        }
    }
}
