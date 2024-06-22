using Returns;

namespace ReturnsTest;


public class FaultTest
{
    [Fact]
    public void Fault_Create_WithMessage_ShouldReturnFaultWithCorrectMessage()
    {
        // Arrange
        var message = "Test error message";

        // Act
        var fault = Fault.Create(message);

        // Assert
        Assert.NotNull(fault);
        Assert.Equal(message, fault.Message);
        Assert.Null(fault.Description);
    }

    [Fact]
    public void Fault_Create_WithMessageAndDescription_ShouldReturnFaultWithCorrectMessageAndDescription()
    {
        // Arrange
        var message = "Test error message";
        var description = "Test error description";

        // Act
        var fault = Fault.Create(message, description);

        // Assert
        Assert.NotNull(fault);
        Assert.Equal(message, fault.Message);
        Assert.Equal(description, fault.Description);
    }

    [Fact]
    public void Fault_ShouldBeAssignableToFaultType()
    {
        // Arrange
        var message = "Test error message";

        // Act
        var fault = Fault.Create(message);

        // Assert
        Assert.IsType<ReturnError>(fault);
        Assert.IsAssignableFrom<Fault>(fault);
    }
    [Fact]
    public void Conflict_ShouldCreateConflictFault()
    {
        // Arrange
        var message = "Conflict occurred";
        var description = "A conflict error happened during processing.";

        // Act
        var fault = Fault.Conflict(message, description);

        // Assert
        Assert.NotNull(fault);
        Assert.IsType<Conflict>(fault);
        Assert.Equal(message, fault.Message);
        Assert.Equal(description, fault.Description);
    }

    [Fact]
    public void Conflict_ShouldCreateConflictFaultWithOnlyMessage()
    {
        // Arrange
        var message = "Conflict occurred";

        // Act
        var fault = Fault.Conflict(message);

        // Assert
        Assert.NotNull(fault);
        Assert.IsType<Conflict>(fault);
        Assert.Equal(message, fault.Message);
        Assert.Null(fault.Description);
    }

    [Fact]
    public void NotFound_ShouldCreateNotFoundFault()
    {
        // Arrange
        var message = "Item not found";
        var description = "The requested item could not be located.";

        // Act
        var fault = Fault.NotFound(message, description);

        // Assert
        Assert.NotNull(fault);
        Assert.IsType<NotFound>(fault);
        Assert.Equal(message, fault.Message);
        Assert.Equal(description, fault.Description);
    }

    [Fact]
    public void NotFound_ShouldCreateNotFoundFaultWithOnlyMessage()
    {
        // Arrange
        var message = "Item not found";

        // Act
        var fault = Fault.NotFound(message);

        // Assert
        Assert.NotNull(fault);
        Assert.IsType<NotFound>(fault);
        Assert.Equal(message, fault.Message);
        Assert.Null(fault.Description);
    }

    [Fact]
    public void InternalError_ShouldCreateInternalErrorFault()
    {
        // Arrange
        var message = "Internal server error";
        var description = "An unexpected error occurred in the server.";

        // Act
        var fault = Fault.InternalError(message, description);

        // Assert
        Assert.NotNull(fault);
        Assert.IsType<InternalError>(fault);
        Assert.Equal(message, fault.Message);
        Assert.Equal(description, fault.Description);
    }

    [Fact]
    public void InternalError_ShouldCreateInternalErrorFaultWithOnlyMessage()
    {
        // Arrange
        var message = "Internal server error";

        // Act
        var fault = Fault.InternalError(message);

        // Assert
        Assert.NotNull(fault);
        Assert.IsType<InternalError>(fault);
        Assert.Equal(message, fault.Message);
        Assert.Null(fault.Description);
    }
}