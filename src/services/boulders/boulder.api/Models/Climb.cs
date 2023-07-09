
public class Climb
{
    public int Id { get; private set; }
    public Session ClimbSession { get; set; }
    public int Attempts { get; set; }
    public bool Complete { get; set; }
    public bool Project { get; set; }
    public Boulder Boulder { get; set; }

    public Climb()
    {
        
    }
}