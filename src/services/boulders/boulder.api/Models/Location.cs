
/// <summary>
/// Breakdown of location information
/// </summary>
public class Location : AuditableEntity
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public string? Url { get; set; }
    public bool Active { get; set; }
    public bool Private { get; set; }

    public Location(string name, bool active, bool @private)
    {
        this.Name = name;
        this.Active = active;
        this.Private = @private;
    }
}