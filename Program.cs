using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EtecFilmes.Data;
using EtecFilmes.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EtecFilmes
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try
                {
                    var context = services.GetRequiredService<Contexto>();
                    var userManager = services.GetRequiredService<UserManager<Usuario>>();
                    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
                    await ContextoSeed.SeedRolesAsync(userManager, roleManager);
                    await ContextoSeed.SeedSuperAdminAsync(userManager, roleManager);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "Ocorreu um erro ao popular o identity");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}