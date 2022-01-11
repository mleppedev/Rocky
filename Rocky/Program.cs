using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rocky
{
    public class Program
    {
        // las aplicaciones .net core son iniciadas como aplicaciones de consola, por ello el metodo Main()
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // configuracion del web host con valores por defecto
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    // archivo de inicio
                    webBuilder.UseStartup<Startup>();
                });
    }
}
