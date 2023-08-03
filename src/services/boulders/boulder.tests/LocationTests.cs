public class LocationTests
{
    [Fact]
    public void Constructor_SetsProperties()
    {
        // Arrange
        var name = "Test Location";
        var active = true;
        var isPrivate = false;
        var boulderGroups = new List<Grouping> { Grouping.A, Grouping.B };

        // Act
        var location = new Location(name, active, isPrivate, boulderGroups);

        // Assert
        Assert.Equal(name, location.Name);
        Assert.Equal(active, location.Active);
        Assert.Equal(isPrivate, location.IsPrivate);
        Assert.Equal(boulderGroups, location.BoulderGroups);
    }

    [Fact]
    public void SetName_ChangesName()
    {
        // Arrange
        var location = new Location("Test Location", true, false, new List<Grouping>());

        // Act
        location.SetName("New Name");

        // Assert
        Assert.Equal("New Name", location.Name);
    }

    [Fact]
    public void SetActive_ChangesActive()
    {
        // Arrange
        var location = new Location("Test Location", true, false, new List<Grouping>());

        // Act
        location.SetActive(false);

        // Assert
        Assert.False(location.Active);
    }

    [Fact]
    public void SetIsPrivate_ChangesIsPrivate()
    {
        // Arrange
        var location = new Location("Test Location", true, false, new List<Grouping>());

        // Act
        location.SetIsPrivate(true);

        // Assert
        Assert.True(location.IsPrivate);
    }

    [Fact]
    public void AddBoulderGroup_AddsGroup()
    {
        // Arrange
        var location = new Location("Test Location", true, false, new List<Grouping>());

        // Act
        location.AddBoulderGroup(Grouping.A);

        // Assert
        Assert.Contains(Grouping.A, location.BoulderGroups);
    }

    [Fact]
    public void RemoveBoulderGroup_RemovesGroup()
    {
        // Arrange
        var location = new Location("Test Location", true, false, new List<Grouping> { Grouping.A, Grouping.B });

        // Act
        location.RemoveBoulderGroup(Grouping.A);

        // Assert
        Assert.DoesNotContain(Grouping.A, location.BoulderGroups);
    }
}