
public record Boulder
{
    public Guid Id { get; private set; }
    public string Name { get; set; }
    public string ContactEmail { get; set; }
    public bool Active { get; set; } = false;
    public DateTime ActiveDate { get; set; }
}