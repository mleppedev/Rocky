using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // metodo utilizado para agregar servicios al container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // basado en esta condicion se condicion se configura el pipeline
            // el pipeline especifica como la applicacion .net core responde a los http request
            if (env.IsDevelopment())
            {
                // por ejemplo en el pipeline en caso de que este en desarrollo se agrega el middleware siguiente para mostrar excepciones
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // en caso de no estar en desarrollo se utiliza el middleware que muestra custom messages en lugar de la excepcion real
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            // este middleware obliga al usuario a usar una linea segura
            app.UseHttpsRedirection();
            // a continuacion se agregan archivos estaticos como por ejemplo: hojas de estilo, javascript, imagenes, etc.
            // carpeta de archivos estaticos wwwroot
            app.UseStaticFiles();

            app.UseRouting();

            // la autorizacion se agrega antes del endpoint debido a que el orden importa cuando se trata de middlewares
            app.UseAuthorization();

            // aqui se configura la ruta de la aplicacion
            app.UseEndpoints(endpoints =>
            {
                // por defecto en mvc el patron es el siguiente (13. Routing in MVC)
                // https://localhost:55555/{controller}/{action}/{id}
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
