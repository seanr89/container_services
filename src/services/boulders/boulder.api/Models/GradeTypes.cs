
public class GradeTypes{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public bool Active { get; private set; }

    public GradeTypes(string name, bool active)
    {
        this.Name = name;
        this.Active = active;
    }
}