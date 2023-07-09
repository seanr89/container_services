

public class Grouping
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }
    public Location GymLocation { get; set; }
    public List<Boulder> Boulders { get; set; }

    // public Grouping(string name, bool active, Location gymLocation)
    // {
    //     this.Name = name;
    //     this.Active = active;
    //     this.GymLocation = gymLocation;
    // }
}