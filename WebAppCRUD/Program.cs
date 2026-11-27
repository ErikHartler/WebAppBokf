using EFData;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace WebAppCRUD
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BokforingContext>();
                dbContext.Database.EnsureCreated();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => {
                    webBuilder.UseStartup<Startup>();
                    webBuilder.ConfigureServices((context, services) => {
                        string environment = context.Configuration["Environment"];
                        string connection = context.Configuration.GetConnectionString("Bokf");
                        services.AddDbContext<BokforingContext>(options => options
                            .UseSqlServer(connection)
                            .EnableSensitiveDataLogging(environment == "Development"));
                    });
                });
        }
    }
}
