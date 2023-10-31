using Microsoft.EntityFrameworkCore;
using PlatformService.Models;

namespace PlatformService.Repository
{
    public static class PrepDb
    {
        //Migrate Db if we are on prod
        //Seed database if there is no data

        public static void PrePopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }

        private static void SeedData(AppDbContext appDbContext, bool isProd)
        {
            if (isProd)
            {
                Console.WriteLine("--> Attempting to apply migrations...");
                try
                {
                    appDbContext.Database.Migrate();
                }
                catch (Exception e)
                {
                    Console.WriteLine($"--> Could not run migration: {e.Message}");
                }
            }

            if (!appDbContext.platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");
                appDbContext.platforms.AddRange(
                    new Platform() { PlatformName = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { PlatformName = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { PlatformName = "Kubernetes", Publisher = "Cloud Native Computing Foundation", Cost = "Free" }
                );
                appDbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> we already have data");
            }
        }
    }
}