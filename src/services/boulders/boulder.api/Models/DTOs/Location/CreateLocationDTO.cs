
public class CreateLocationDTO
{
    public string Name { get; set; }
    public bool IsPrivate { get; set; }

    public Location ToLocation(CreateLocationDTO dto) => new Location
    {
        Name = dto.Name,
        IsPrivate = dto.IsPrivate
    };
}