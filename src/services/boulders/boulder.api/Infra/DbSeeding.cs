
/// <summary>
/// Drive and initialize basic DB seeding for a test club
/// </summary>
public static class DbSeeding
{
    /// <summary>
    /// Seed the database with basic data
    /// </summary>
    /// <param name="context"></param>
    /// <returns></returns>
    public static async Task TryRunSeed(BoulderContext context)
    {
        if (!context.Locations.Any())
        {
            await SeedLocations(context);
        }

        if (!context.Groupings.Any())
        {
            await SeedGroupings(context);
        }

        if (!context.Boulders.Any())
        {
            await SeedBoulders(context);
        }
    }

    /// <summary>
    /// Seeds the boulders in the database.
    /// </summary>
    /// <param name="context">The <see cref="BoulderContext"/> instance.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private static async Task SeedBoulders(BoulderContext context)
    {
        var boulders = new List<Boulder>();
        for (var i = 1; i <= 10; i++)
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

    /// <summary>
    /// Seeds the groupings in the database.
    /// </summary>
    /// <param name="context">The <see cref="BoulderContext"/> instance.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    private static async Task SeedGroupings(BoulderContext context)
    {
        var groupings = new List<Grouping>();
        for (var i = 1; i <= 10; i++)
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

    /// <summary>
    /// Seeds the locations in the database.
    /// </summary>
    /// <param name="context">The BoulderContext instance.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    private static async Task SeedLocations(BoulderContext context)
    {
        var locations = new List<Location>
        {
            new("Movement", true, false),
            new("Earth Treks", true, false, "https://www.earthtreksclimbing.com/englewood/"),
            new("The Spot", true, false)
        };

        context.Locations.AddRange(locations);
        await context.SaveChangesAsync();
    }
}