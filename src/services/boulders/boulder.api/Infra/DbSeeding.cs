
/// <summary>
/// Drive and initialize basic DB seeding for a test club
/// </summary>
public static class DbSeeding
{
    public static async Task TryRunSeed(BoulderContext context)
    {
        if (!context.Boulders.Any())
        {
        }

        if(!context.Locations.Any())
        {
            await SeedLocations(context);
        }

        if(!context.Groupings.Any())
        {
            await SeedGroupings(context);
        }
    }

    static async Task SeedBoulders(BoulderContext context)
    {
        var boulders = new List<Boulder>();
        for (int i = 1; i <= 10; i++)
        {
            boulders.Add(new Boulder(
                $"Boulder {i}",
                true,
                DateTime.Now.AddDays(-i),
                context.Groupings.First()));
        }

        context.Boulders.AddRange(boulders);
        await context.SaveChangesAsync();
    }

    static async Task SeedGroupings(BoulderContext context)
    {
        var groupings = new List<Grouping>();
        for (int i = 1; i <= 10; i++)
        {
            groupings.Add(new Grouping
            {
                Name = $"Grouping {i}",
                GymLocation = context.Locations.First()
            });
        }

        context.Groupings.AddRange(groupings);
        await context.SaveChangesAsync();
    }

    static async Task SeedLocations(BoulderContext context)
    {
        var locations = new List<Location>();
        locations.Add(new Location("Movement", true, false));
        locations.Add(new Location("Earth Treks", true, false, "https://www.earthtreksclimbing.com/englewood/"));
        locations.Add(new Location("The Spot", true, false));

        context.Locations.AddRange(locations);
        await context.SaveChangesAsync();
    }
}