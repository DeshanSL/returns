using Returns;
using Returns.Exceptions;

namespace ReturnsTest;

public class ReturnTResultIsErrorTypeOfTest
{
    [Fact]
    public void IsErrorTypeOf_ShouldReturnTrue_WhenErrorTypeMatches()
    {
        // Arrange
        Return<string> result = Return<string>.Conflict("Conflict occurred");

        // Act
        var isErrorType = result.IsErrorTypeOf<Conflict>();

        // Assert
        Assert.True(isErrorType);
    }

    [Fact]
    public void IsErrorTypeOf_ShouldReturnFalse_WhenErrorTypeDoesNotMatch()
    {
        // Arrange
        Return<string> result = Return<string>.NotFound("Not found");

        // Act
        var isErrorType = result.IsErrorTypeOf<Conflict>();

        // Assert
        Assert.False(isErrorType);
    }

    [Fact]
    public void IsErrorTypeOf_ShouldThrowInvalidRequestException_WhenResultIsNotFailure()
    {
        // Arrange
        Return<string> result = "test";

        // Act & Assert
        Assert.Throws<InvalidRequestException>(() => result.IsErrorTypeOf<Conflict>());
    }

    [Fact]
    public void ErrorsContain_ShouldReturnTrue_WhenErrorsContainSpecifiedFaultType()
    {
        // Arrange
        var errors = new List<Fault> { Return.Conflict("Conflict"), Return.NotFound("Not Found") };
        var result = Return<string>.Failure(errors);

        // Act
        var containsError = result.ErrorsContain<Conflict>();

        // Assert
        Assert.True(containsError);
    }

    [Fact]
    public void ErrorsContain_ShouldReturnFalse_WhenErrorsDoNotContainSpecifiedFaultType()
    {
        // Arrange
        var errors = new List<Fault> { Return.InternalError("Internal Error"), Return.NotFound("Not Found") };
        var result = Return<string>.Failure(errors);

        // Act
        var containsError = result.ErrorsContain<Conflict>();

        // Assert
        Assert.False(containsError);
    }

    [Fact]
    public void ErrorsContain_ShouldThrowInvalidRequestException_WhenResultIsNotFailure()
    {
        // Arrange
        Return<string> result = "Test"; 

        // Act & Assert
        Assert.Throws<InvalidRequestException>(() => result.ErrorsContain<Conflict>());
    }
}