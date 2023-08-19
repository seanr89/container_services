
public class GroupingListDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int BoulderCount { get; set; }

    public GroupingListDTO(Grouping model)
    {
        this.Id = model.Id;
        this.Name = model.Name;
        this.BoulderCount = model.Boulders.Any() ? model.Boulders.Count : 0;
    }
}