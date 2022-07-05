using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {

        public static void PrepPolulation(IApplicationBuilder applicationBuilder)
        {
            using (var scope = applicationBuilder.ApplicationServices.CreateScope())
            {
                SeedData(scope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("Adding sample data");
                context.Platforms.AddRange(
                    new Platform(){Name = "GE", Publisher=  "Ge@Pub", Cost = "12"},
                    new Platform(){Name = "Nokia", Publisher=  "Nokia@Pub", Cost = "Free"},
                    new Platform(){Name = "Volvo", Publisher=  "Volvo@Pub", Cost = "Premium"},
                    new Platform(){Name = "PWC", Publisher=  "Pwc@Pub", Cost = "85"},
                    new Platform(){Name = "Ey", Publisher=  "Ey@Pub", Cost = "45"},
                    new Platform(){Name = "Microsoft", Publisher=  "Microsoft@Pub", Cost = "100"},
                    new Platform(){Name = "Ubs", Publisher=  "Ubs@Pub", Cost = "Test"}
                );
            }else System.Console.WriteLine($"DATA EXISTS ALREADY - {DateTime.Now}");
            context.SaveChanges();
        }

    }


}