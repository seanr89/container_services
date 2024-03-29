
/// <summary>
/// Design for a method to breakdown and grade a climb
/// </summary>
public class GradeType{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public bool Active { get; private set; }

    public GradeType(string name, bool active)
    {
        this.Name = name;
        this.Active = active;
    }
}