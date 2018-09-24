using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((host, cfg )=>
            {
                var path1 = Path.Combine(host.HostingEnvironment.ContentRootPath, "config.json");
                var path2 = Path.Combine(host.HostingEnvironment.ContentRootPath, "appsettings.json");
                cfg.AddJsonFile(path2, false, true).AddJsonFile(path1, false, true);
            })
            .UseStartup<Startup>();
    }
}
