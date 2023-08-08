
public class LocationListDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool Active { get; set; }
    public bool IsPrivate { get; set; }

    public LocationListDTO(Location model)
    {
        this.Id = model.Id;
        this.Name = model.Name;
        this.Active = model.Active;
        this.IsPrivate = model.IsPrivate;
    }
}