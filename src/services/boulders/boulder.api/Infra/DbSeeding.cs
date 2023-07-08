
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
    }

    static async Task SeedLocations(BoulderContext context)
    {
        context.Locations.Add(new Location("The Spot", true, false));
        context.Locations.Add(new Location("Movement", true, false));
        context.Locations.Add(new Location("Earth Treks", true, false, "https://www.earthtreksclimbing.com/englewood/"));

        await context.SaveChangesAsync();
    }
}