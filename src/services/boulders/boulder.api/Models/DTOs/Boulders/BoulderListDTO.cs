
public class BoulderListDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public BoulderListDTO(Boulder model)
    {
        this.Id = model.Id;
        this.Name = model.Name;
    }
}