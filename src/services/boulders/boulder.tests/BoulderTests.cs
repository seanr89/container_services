public class BoulderTests
{
    [Fact]
    public void Activate_SetsActiveToTrue()
    {
        // Arrange
        var boulder = new Boulder("Test Boulder", false, DateTime.UtcNow);

        // Act
        boulder.Activate();

        // Assert
        Assert.True(boulder.Active);
    }

    [Fact]
    public void Deactivate_SetsActiveToFalse()
    {
        // Arrange
        var boulder = new Boulder("Test Boulder", true, DateTime.UtcNow);

        // Act
        boulder.Deactivate();

        // Assert
        Assert.False(boulder.Active);
    }

    // [Fact]
    // public void SetGrouping_SetsBoulderGroup()
    // {
    //     // Arrange
    //     var boulder = new Boulder("Test Boulder", true, DateTime.UtcNow);

    //     // Act
    //     boulder.SetGrouping(Grouping.B);

    //     // Assert
    //     Assert.Equal(Grouping.B, boulder.BoulderGroup);
    // }

    [Fact]
    public void SetActiveDate_SetsActiveDate()
    {
        // Arrange
        var boulder = new Boulder("Test Boulder", true, DateTime.UtcNow);
        var newActiveDate = DateTime.UtcNow.AddDays(2);

        // Act
        boulder.SetActiveDate(newActiveDate);

        // Assert
        Assert.Equal(newActiveDate, boulder.ActiveDate);
    }

    [Fact]
    public void SetDeActiveDate_ThrowsExceptionIfDeActiveDateBeforeActiveDate()
    {
        // Arrange
        var boulder = new Boulder("Test Boulder", true, DateTime.UtcNow);
        var newDeActiveDate = DateTime.UtcNow.AddDays(-1);

        // Act & Assert
        Assert.Throws<Exception>(() => boulder.SetDeActiveDate(newDeActiveDate));
    }
}