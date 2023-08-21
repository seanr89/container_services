public class User
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }
    public string Gender { get; set; }
    public bool IsPrivate { get; private set; }
    public Location GymLocation { get; set; }

    #region Public Methods

    public void SetIsPrivate(bool isPrivate) => this.IsPrivate = isPrivate;

    #endregion
}