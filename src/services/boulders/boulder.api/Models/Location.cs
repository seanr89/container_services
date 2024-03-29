
/// <summary>
/// Breakdown of location information
/// </summary>
public class Location : AuditableEntity
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public string? Url { get; private set; }
    public bool Active { get; private set; }
    public bool IsPrivate { get; set; }
    public List<Grouping> BoulderGroups { get; set; }
    public List<User> Users { get; set; }

    #region Constructors

    public Location(string name, bool active, bool isPrivate)
    {
        this.Name = name;
        this.Active = active;
        this.IsPrivate = isPrivate;
    }

    public Location(string name, bool active, bool isPrivate, string url) : this(name, active, isPrivate) => this.Url = url;

    #endregion

    #region Public Methods

    public void SetName(string name) => this.Name = name;

    public void SetUrl(string url) => this.Url = url;

    public void AddBoulderGroup(Grouping boulderGroup) => this.BoulderGroups.Add(boulderGroup);

    public void Activate() => this.Active = true;

    public void Deactivate() => this.Active = false;

    public void SetIsPrivate(bool isPrivate) => this.IsPrivate = isPrivate;

    #endregion
}