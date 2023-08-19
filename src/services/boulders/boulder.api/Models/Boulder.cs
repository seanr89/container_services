
public record Boulder
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public bool Active { get; private set; } = false;
    public DateTime ActiveDate { get; private set; }
    public DateTime? DeActiveDate { get; private set; }
    public Grouping BoulderGroup { get; private set; }

    #region Constructors

    public Boulder()
    {
    }

    public Boulder(string name, bool active, DateTime activeDate)
    {
        Name = name;
        Active = active;
        ActiveDate = activeDate;
    }

    public Boulder(string name, bool active, DateTime activeDate, Grouping boulderGroup) : this(name, active, activeDate)
    {
        BoulderGroup = boulderGroup;
    }

    public Boulder(string name, bool active, DateTime activeDate, Grouping boulderGroup, DateTime deActiveDate) : 
        this(name, active, activeDate, boulderGroup)
    {
        DeActiveDate = deActiveDate;
        BoulderGroup = boulderGroup;
    }

    #endregion

    #region Public Methods

    public void Activate() => this.Active = true;

    public void Deactivate() => this.Active = false;

    public void SetGrouping(Grouping grouping) => this.BoulderGroup = grouping;

    public void SetActiveDate(DateTime activeDate) => this.ActiveDate = activeDate;

    public void SetDeActiveDate(DateTime deActiveDate)
    {
        if (deActiveDate >= this.ActiveDate)
        {
            this.DeActiveDate = deActiveDate;
        }
        throw new Exception("DeActiveDate cannot be before ActiveDate");
    }

    #endregion
}