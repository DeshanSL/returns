using Returns;
using Returns.Exceptions;

namespace ReturnsTest;

public class ReturnIsErrorTypeOfTest
{
    [Fact]
    public void IsErrorTypeOf_ShouldReturnTrue_WhenErrorTypeMatches()
    {
        // Arrange
        Return result = Return.Conflict("Conflict occurred");

        // Act
        var isErrorType = result.IsErrorTypeOf<Conflict>();
        var isErrorType2 = result.Error.Is<Conflict>();

        // Assert
        Assert.True(isErrorType);
        Assert.True(isErrorType2);
    }

    [Fact]
    public void IsErrorTypeOf_ShouldReturnFalse_WhenErrorTypeDoesNotMatch()
    {
        // Arrange
        Return result = Return.NotFound("Not found");

        // Act
        var isErrorType = result.IsErrorTypeOf<Conflict>();
        var isErrorType2 = result.Error.Is<Conflict>();

        // Assert
        Assert.False(isErrorType);
        Assert.False(isErrorType2);
    }

    [Fact]
    public void IsErrorTypeOf_ShouldThrowInvalidRequestException_WhenResultIsNotFailure()
    {
        // Arrange
        Return result = Return.Success();

        // Act & Assert
        Assert.Throws<InvalidRequestException>(() => result.IsErrorTypeOf<Conflict>());
    }

    [Fact]
    public void ErrorsContain_ShouldReturnTrue_WhenErrorsContainSpecifiedFaultType()
    {
        // Arrange
        var errors = new List<Fault> { Return.Conflict("Conflict"), Return.NotFound("Not Found") };
        var result = Return.Failure(errors);

        // Act
        var containsError = result.ErrorsContain<Conflict>();
        var containsError2 = result.Errors.ContainsErrorType<Conflict>();

        // Assert
        Assert.True(containsError);
        Assert.True(containsError2);
    }

    [Fact]
    public void ErrorsContain_ShouldReturnFalse_WhenErrorsDoNotContainSpecifiedFaultType()
    {
        // Arrange
        var errors = new List<Fault> { Return.InternalError("Internal Error"), Return.NotFound("Not Found") };
        var result = Return.Failure(errors);

        // Act
        var containsError = result.ErrorsContain<Conflict>();
        var containsError2 = result.Errors.ContainsErrorType<Conflict>();

        // Assert
        Assert.False(containsError);
        Assert.False(containsError2);
    }

    [Fact]
    public void ErrorsContain_ShouldThrowInvalidRequestException_WhenResultIsNotFailure()
    {
        // Arrange
        Return result = Return.Success();

        // Act & Assert
        Assert.Throws<InvalidRequestException>(() => result.ErrorsContain<Conflict>());
    }
}
