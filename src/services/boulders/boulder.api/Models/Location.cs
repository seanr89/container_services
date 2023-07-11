
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
    public List<Grouping> BoulderGroups { get; set; }

    #region Constructors

    public Location(string name, bool active, bool @private)
    {
        this.Name = name;
        this.Active = active;
        this.Private = @private;
    }

    public Location(string name, bool active, bool @private, string url) : this(name, active, @private)
    {
        this.Url = url;
    }

    #endregion

    #region Public Methods

    public void AddBoulderGroup(Grouping boulderGroup)
    {
        this.BoulderGroups.Add(boulderGroup);
    }

    public void Activate () => this.Active = true;

    public void Deactivate () => this.Active = false;   

    #endregion
}