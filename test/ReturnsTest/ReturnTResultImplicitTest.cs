using Returns;
using Returns.Exceptions;

namespace ReturnsTest;

public class ReturnTResultImplicitTest
{

    public Return<string> ReturnsString()
    {
        return "Test";
    }

    [Fact]
    public void Returns_String_When_TResult_Is_String()
    {
        var result = ReturnsString();
        Assert.True(result.IsSuccessful);
        Assert.Equal("Test", result.Value);
    }
    [Fact]
    public void ImplicitConversion_FromFaultList_ShouldReturnReturnWithFaults()
    {
        // Arrange
        var faults = new List<Fault>
            {
                Fault.Create("Error 1"),
                Fault.Create("Error 2")
            };

        // Act
        Return<string> returnValue = faults;

        // Assert
        Assert.False(returnValue.IsSuccessful);
        Assert.Equal(faults, returnValue.Errors);
        Assert.Throws<InvalidRequestException>(() => returnValue.Value);
    }

    [Fact]
    public void Value_AccessOnFailure_ShouldThrowException()
    {
        // Arrange
        var fault = Fault.Create("Error occurred");
        Return<string> returnValue = fault;

        // Act & Assert
        Assert.Throws<InvalidRequestException>(() => returnValue.Value);
    }

    [Fact]
    public void Error_AccessOnSuccess_ShouldThrowException()
    {
        // Arrange
        var result = "Success";
        Return<string> returnValue = result;

        // Act & Assert
        Assert.Throws<InvalidRequestException>(() => returnValue.Error);
    }

    [Fact]
    public void Errors_AccessOnSuccess_ShouldThrowException()
    {
        // Arrange
        var result = "Success";
        Return<string> returnValue = result;

        // Act & Assert
        Assert.Throws<InvalidRequestException>(() => returnValue.Errors);
    }

    [Fact]
    public void Constructor_WithoutParameters_ShouldThrowException()
    {
        // Act & Assert
        Assert.Throws<InvalidConstructorCallException>(() => new Return<string>());
    }

}