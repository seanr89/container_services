
public class LocationDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }
    public bool IsPrivate { get; set; }
    public List<GroupingListDTO> Groupings { get; set; }

    public LocationDTO(Location model)
    {
        this.Id = model.Id;
        this.Name = model.Name;
        this.Active = model.Active;
        this.IsPrivate = model.IsPrivate;
        this.Groupings = model.BoulderGroups.Select(g => new GroupingListDTO(g)).ToList();
    }
}