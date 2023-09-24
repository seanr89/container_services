
public class GroupingDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }
    public string LocationName { get; set; }
    public int LocationId { get; set; }
    public List<BoulderListDTO> Boulders { get; set; }

    public GroupingDTO(Grouping model)
    {
        this.Id = model.Id;
        this.Name = model.Name;
        this.Active = model.Active;
        this.LocationName = model.GymLocation.Name;
        this.LocationId = model.GymLocation.Id;
        this.Boulders = model.Boulders.Select(b => new BoulderListDTO(b)).ToList();
    }
}