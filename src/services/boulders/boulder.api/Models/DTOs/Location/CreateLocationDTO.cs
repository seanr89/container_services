
public class CreateLocationDTO
{
    public string Name { get; set; }
    public bool Active { get; set; }
    public bool IsPrivate { get; set; }
    public Location ToLocation(CreateLocationDTO dto) {
        return new Location(dto.Name, dto.Active, dto.IsPrivate);
    }
}