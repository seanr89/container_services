
public class GroupingListDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public GroupingListDTO(Grouping model)
    {
        this.Id = model.Id;
        this.Name = model.Name;
    }
}