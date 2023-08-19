public class LocationTests
{
    [Fact]
    public void Constructor_SetsProperties()
    {
        // Arrange
        var name = "Test Location";
        var active = true;
        var isPrivate = false;

        //Act
        var location = new Location(name, active, isPrivate);

        //Assert
        Assert.Equal(name, location.Name);
        Assert.Equal(active, location.Active);
        Assert.Equal(isPrivate, location.IsPrivate);
    }

    [Fact]
    public void SetName_ChangesName()
    {
        // Arrange
        var location = new Location("Test Location", true, false);

        // Act
        location.SetName("New Name");

        // Assert
        Assert.Equal("New Name", location.Name);
    }

    [Fact]
    public void SetActive_ChangesActive()
    {
        // Arrange
        var location = new Location("Test Location", true, false);

        // Act
        location.Deactivate();

        // Assert
        Assert.False(location.Active);
    }

    [Fact]
    public void SetIsPrivate_ChangesIsPrivate()
    {
        // Arrange
        var location = new Location("Test Location", true, false);

        // Act
        location.SetIsPrivate(true);

        // Assert
        Assert.True(location.IsPrivate);
    }

    [Fact]
    public void AddBoulderGroup_AddsGroup()
    {
        // Arrange
        var location = new Location("Test Location", true, false);
        var grouping = new Grouping();

        // Act
        location.AddBoulderGroup(grouping);

        // Assert
        Assert.Contains(grouping, location.BoulderGroups);
    }

    // [Fact]
    // public void RemoveBoulderGroup_RemovesGroup()
    // {
    //     // Arrange
    //     var location = new Location("Test Location", true, false, new List<Grouping> { Grouping.A, Grouping.B });

    //     // Act
    //     location.RemoveBoulderGroup(Grouping.A);

    //     // Assert
    //     Assert.DoesNotContain(Grouping.A, location.BoulderGroups);
    // }
}