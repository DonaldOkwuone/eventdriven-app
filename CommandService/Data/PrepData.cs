namespace CommandService.Data
{
    public static class PrepData
    {
        public static void PrepDb(IApplicationBuilder app, bool IsProd)
        {
            //If db is empty seed
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), IsProd);
            }
            //

        }

        public static void SeedData(AppDbContext context, bool IsProd)
        {
            ///Migrate programmatically and 
            ///Seed if empty
            ///
            /*if (!context.commands.Any())
            {
                context.commands.AddRange(
                    new Models.Command { CommandText = "dotnet build", HowTo = "Build Project", PlatformId = 1, Id = 1 }
                    new Models.Command { CommandText = "dotnet build", HowTo = "Build Project", PlatformId = 1, Id = 1 }
                    new Models.Command { CommandText = "dotnet build", HowTo = "Build Project", PlatformId = 1, Id = 1 }
                );
            }
            */
        }
    }
}