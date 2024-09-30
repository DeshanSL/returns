using Returns;

namespace ReturnsTest;

public class FaultTypeExtensionsTests
{
    [Fact]
    public void Is_ShouldReturnTrue_WhenFaultTypeMatches()
    {
        // Arrange
        Fault fault = new Conflict("Conflict occurred");

        // Act
        var isConflict = fault.Is<Conflict>();

        // Assert
        Assert.True(isConflict);
    }

    [Fact]
    public void Is_ShouldReturnFalse_WhenFaultTypeDoesNotMatch()
    {
        // Arrange
        Fault fault = new NotFound("Not found");

        // Act
        var isConflict = fault.Is<Conflict>();

        // Assert
        Assert.False(isConflict);
    }

    [Fact]
    public void ContainsErrorType_ShouldReturnTrue_WhenListContainsFaultType()
    {
        // Arrange
        var faults = new List<Fault>
        {
            new Conflict("Conflict occurred"),
            new NotFound("Not found")
        };

        // Act
        var containsConflict = faults.ContainsErrorType<Conflict>();

        // Assert
        Assert.True(containsConflict);
    }

    [Fact]
    public void ContainsErrorType_ShouldReturnFalse_WhenListDoesNotContainFaultType()
    {
        // Arrange
        var faults = new List<Fault>
        {
            new InternalError("Internal error"),
            new NotFound("Not found")
        };

        // Act
        var containsConflict = faults.ContainsErrorType<Conflict>();

        // Assert
        Assert.False(containsConflict);
    }

    [Fact]
    public void ContainsErrorType_ShouldReturnFalse_WhenListIsEmpty()
    {
        // Arrange
        var faults = new List<Fault>();

        // Act
        var containsConflict = faults.ContainsErrorType<Conflict>();

        // Assert
        Assert.False(containsConflict);
    }
}
