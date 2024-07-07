
using Returns;

namespace ReturnsTest;

public class ReturnMatchTest
{
    [Fact]
    public void Match_Success_ExecutesOnSuccess()
    {
        // Arrange
        var returnObject = Return.Success();
        bool onSuccessCalled = false;
        bool onFailureCalled = false;

        // Act
        returnObject.Match(
            onSuccess: () => onSuccessCalled = true,
            onFailure: faults => onFailureCalled = true
        );

        // Assert
        Assert.True(onSuccessCalled);
        Assert.False(onFailureCalled);
    }

    [Fact]
    public void Match_Failure_ExecutesOnFailure()
    {
        // Arrange
        var fault = Fault.Create("Some error message");
        var returnObject = Return.Failure(fault);
        bool onSuccessCalled = false;
        bool onFailureCalled = false;

        // Act
        returnObject.Match(
            onSuccess: () => onSuccessCalled = true,
            onFailure: faults => onFailureCalled = true
        );

        // Assert
        Assert.False(onSuccessCalled);
        Assert.True(onFailureCalled);
    }

    [Fact]
    public void MatchFirst_Success_ExecutesOnSuccess()
    {
        // Arrange
        var returnObject = Return.Success();
        bool onSuccessCalled = false;
        bool onFailureCalled = false;

        // Act
        returnObject.MatchFirst(
            onSuccess: () => onSuccessCalled = true,
            onFailure: fault => onFailureCalled = true
        );

        // Assert
        Assert.True(onSuccessCalled);
        Assert.False(onFailureCalled);
    }

    [Fact]
    public void MatchFirst_Failure_ExecutesOnFailure()
    {
        // Arrange
        var fault = Fault.Create("Some error message");
        var returnObject = Return.Failure(fault);
        bool onSuccessCalled = false;
        bool onFailureCalled = false;

        // Act
        returnObject.MatchFirst(
            onSuccess: () => onSuccessCalled = true,
            onFailure: fault => onFailureCalled = true
        );

        // Assert
        Assert.False(onSuccessCalled);
        Assert.True(onFailureCalled);
    }

    [Fact]
    public void MatchFirst_Generic_Success_ReturnsOnSuccessValue()
    {
        // Arrange
        var returnObject = Return.Success();
        var successValue = "Success";
        var failureValue = "Failure";

        // Act
        var result = returnObject.MatchFirst(
            onSuccess: () => successValue,
            onFailure: fault => failureValue
        );

        // Assert
        Assert.Equal(successValue, result);
    }

    [Fact]
    public void MatchFirst_Generic_Failure_ReturnsOnFailureValue()
    {
        // Arrange
        var fault = Fault.Create("Some error message");
        var returnObject = Return.Failure(fault);
        var successValue = "Success";
        var failureValue = "Failure";

        // Act
        var result = returnObject.MatchFirst(
            onSuccess: () => successValue,
            onFailure: fault => failureValue
        );

        // Assert
        Assert.Equal(failureValue, result);
    }

    [Fact]
    public void Match_Generic_Success_ReturnsOnSuccessValue()
    {
        // Arrange
        var returnObject = Return.Success();
        var successValue = "Success";
        var failureValue = "Failure";

        // Act
        var result = returnObject.Match(
            onSuccess: () => successValue,
            onFailure: faults => failureValue
        );

        // Assert
        Assert.Equal(successValue, result);
    }

    [Fact]
    public void Match_Generic_Failure_ReturnsOnFailureValue()
    {
        // Arrange
        var fault = Fault.Create("Some error message");
        var returnObject = Return.Failure(fault);
        var successValue = "Success";
        var failureValue = "Failure";

        // Act
        var result = returnObject.Match(
            onSuccess: () => successValue,
            onFailure: faults => failureValue
        );

        // Assert
        Assert.Equal(failureValue, result);
    }
}
