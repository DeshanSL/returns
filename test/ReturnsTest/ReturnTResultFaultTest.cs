using Returns;

namespace ReturnsTest;
public class ReturnFaultFactoryTest{
    
}
public class ReturnTResultFaultFactoryTests
{
    [Fact]
    public void Conflict_Returns_ConflictFault_WithCorrectMessageAndDescription()
    {
        // Arrange
        var message = "Conflict occurred";
        var description = "Conflict details";

        // Act
        var result = Return<string>.Conflict(message, description);

        // Assert
        Assert.IsType<Conflict>(result);
        Assert.Equal(message, result.Message);
        Assert.Equal(description, result.Description);
    }

    [Fact]
    public void Conflict_Returns_ConflictFault_WithCorrectMessage_And_NullDescription()
    {
        // Arrange
        var message = "Conflict occurred";

        // Act
        var result = Return<string>.Conflict(message);

        // Assert
        Assert.IsType<Conflict>(result);
        Assert.Equal(message, result.Message);
        Assert.Null(result.Description);
    }

    [Fact]
    public void NotFound_Returns_NotFoundFault_WithCorrectMessageAndDescription()
    {
        // Arrange
        var message = "Not found";
        var description = "Item not found";

        // Act
        var result = Return<string>.NotFound(message, description);

        // Assert
        Assert.IsType<NotFound>(result);
        Assert.Equal(message, result.Message);
        Assert.Equal(description, result.Description);
    }

    [Fact]
    public void NotFound_Returns_NotFoundFault_WithCorrectMessage_And_NullDescription()
    {
        // Arrange
        var message = "Not found";

        // Act
        var result = Return<string>.NotFound(message);

        // Assert
        Assert.IsType<NotFound>(result);
        Assert.Equal(message, result.Message);
        Assert.Null(result.Description);
    }

    [Fact]
    public void InternalError_Returns_InternalErrorFault_WithCorrectMessageAndDescription()
    {
        // Arrange
        var message = "Internal server error";
        var description = "Error details";

        // Act
        var result = Return<string>.InternalError(message, description);

        // Assert
        Assert.IsType<InternalError>(result);
        Assert.Equal(message, result.Message);
        Assert.Equal(description, result.Description);
    }

    [Fact]
    public void InternalError_Returns_InternalErrorFault_WithCorrectMessage_And_NullDescription()
    {
        // Arrange
        var message = "Internal server error";

        // Act
        var result = Return<string>.InternalError(message);

        // Assert
        Assert.IsType<InternalError>(result);
        Assert.Equal(message, result.Message);
        Assert.Null(result.Description);
    }

    [Fact]
    public void Unauthorized_Returns_UnauthorizedFault_WithCorrectMessageAndDescription()
    {
        // Arrange
        var message = "Unauthorized access";
        var description = "Authorization failure";

        // Act
        var result = Return<string>.Unauthorized(message, description);

        // Assert
        Assert.IsType<Unauthorized>(result);
        Assert.Equal(message, result.Message);
        Assert.Equal(description, result.Description);
    }

    [Fact]
    public void Unauthorized_Returns_UnauthorizedFault_WithCorrectMessage_And_NullDescription()
    {
        // Arrange
        var message = "Unauthorized access";

        // Act
        var result = Return<string>.Unauthorized(message);

        // Assert
        Assert.IsType<Unauthorized>(result);
        Assert.Equal(message, result.Message);
        Assert.Null(result.Description);
    }

    [Fact]
    public void BadRequest_Returns_BadRequestFault_WithCorrectMessageAndDescription()
    {
        // Arrange
        var message = "Bad request";
        var description = "Invalid request data";

        // Act
        var result = Return<string>.BadRequest(message, description);

        // Assert
        Assert.IsType<BadRequest>(result);
        Assert.Equal(message, result.Message);
        Assert.Equal(description, result.Description);
    }

    [Fact]
    public void BadRequest_Returns_BadRequestFault_WithCorrectMessage_And_NullDescription()
    {
        // Arrange
        var message = "Bad request";

        // Act
        var result = Return<string>.BadRequest(message);

        // Assert
        Assert.IsType<BadRequest>(result);
        Assert.Equal(message, result.Message);
        Assert.Null(result.Description);
    }

    [Fact]
    public void InvalidArguments_Returns_InvalidArgumentsFault_WithCorrectMessageAndDescription()
    {
        // Arrange
        var message = "Invalid arguments";
        var description = "Argument validation failed";

        // Act
        var result = Return<string>.InvalidArguments(message, description);

        // Assert
        Assert.IsType<InvalidArguments>(result);
        Assert.Equal(message, result.Message);
        Assert.Equal(description, result.Description);
    }

    [Fact]
    public void InvalidArguments_Returns_InvalidArgumentsFault_WithCorrectMessage_And_NullDescription()
    {
        // Arrange
        var message = "Invalid arguments";

        // Act
        var result = Return<string>.InvalidArguments(message);

        // Assert
        Assert.IsType<InvalidArguments>(result);
        Assert.Equal(message, result.Message);
        Assert.Null(result.Description);
    }
}