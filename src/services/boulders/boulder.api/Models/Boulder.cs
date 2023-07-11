
public record Boulder
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public bool Active { get; set; } = false;
    public DateTime ActiveDate { get; set; }
    public DateTime DeActiveDate { get; set; }
    public Grouping BoulderGroup { get; set; }

    #region Public Methods

    public void Activate () => this.Active = true;

    public void Deactivate () => this.Active = false;   

    #endregion
}