
public class Session
{
    public Guid Id { get; private set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public Location GymLocation { get; set; }
    public List<Climb> Climbs { get; set; }
}