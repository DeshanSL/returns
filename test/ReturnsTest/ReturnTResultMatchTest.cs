
using Returns;

namespace ReturnsTest;

public class ReturnTResultMatchTest
{
    [Fact]
    public void Match_Success_ExecutesOnSuccess()
    {
        // Arrange
        var value = "Success Value";
        var returnObject = Return<string>.Success(value);
        bool onSuccessCalled = false;
        bool onFailureCalled = false;

        // Act
        returnObject.Match(
            onSuccess: result => { onSuccessCalled = true; Assert.Equal(value, result); },
            onFailure: faults => { onFailureCalled = true; }
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
        var returnObject = Return<string>.Failure(fault);
        bool onSuccessCalled = false;
        bool onFailureCalled = false;

        // Act
        returnObject.Match(
            onSuccess: result => { onSuccessCalled = true; },
            onFailure: faults => { onFailureCalled = true; Assert.Single(faults, fault); }
        );

        // Assert
        Assert.False(onSuccessCalled);
        Assert.True(onFailureCalled);
    }

    [Fact]
    public void MatchFirst_Success_ExecutesOnSuccess()
    {
        // Arrange
        var value = "Success Value";
        var returnObject = Return<string>.Success(value);
        bool onSuccessCalled = false;
        bool onFailureCalled = false;

        // Act
        returnObject.MatchFirst(
            onSuccess: result => { onSuccessCalled = true; Assert.Equal(value, result); },
            onFailure: fault => { onFailureCalled = true; }
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
        var returnObject = Return<string>.Failure(fault);
        bool onSuccessCalled = false;
        bool onFailureCalled = false;

        // Act
        returnObject.MatchFirst(
            onSuccess: result => { onSuccessCalled = true; },
            onFailure: error => { onFailureCalled = true; Assert.Equal(fault, error); }
        );

        // Assert
        Assert.False(onSuccessCalled);
        Assert.True(onFailureCalled);
    }

    [Fact]
    public void MatchFirst_Generic_Success_ReturnsOnSuccessValue()
    {
        // Arrange
        var value = "Success Value";
        var returnObject = Return<string>.Success(value);
        var successResult = "Success Result";
        var failureResult = "Failure Result";

        // Act
        var result = returnObject.MatchFirst(
            onSuccess: result => successResult,
            onFailure: fault => failureResult
        );

        // Assert
        Assert.Equal(successResult, result);
    }

    [Fact]
    public void MatchFirst_Generic_Failure_ReturnsOnFailureValue()
    {
        // Arrange
        var fault = Fault.Create("Some error message");
        var returnObject = Return<string>.Failure(fault);
        var successResult = "Success Result";
        var failureResult = "Failure Result";

        // Act
        var result = returnObject.MatchFirst(
            onSuccess: result => successResult,
            onFailure: error => failureResult
        );

        // Assert
        Assert.Equal(failureResult, result);
    }

    [Fact]
    public void Match_Generic_Success_ReturnsOnSuccessValue()
    {
        // Arrange
        var value = "Success Value";
        var returnObject = Return<string>.Success(value);
        var successResult = "Success Result";
        var failureResult = "Failure Result";

        // Act
        var result = returnObject.Match(
            onSuccess: result => successResult,
            onFailure: faults => failureResult
        );

        // Assert
        Assert.Equal(successResult, result);
    }

    [Fact]
    public void Match_Generic_Failure_ReturnsOnFailureValue()
    {
        // Arrange
        var fault = Fault.Create("Some error message");
        var returnObject = Return<string>.Failure(fault);
        var successResult = "Success Result";
        var failureResult = "Failure Result";

        // Act
        var result = returnObject.Match(
            onSuccess: result => successResult,
            onFailure: faults => failureResult
        );

        // Assert
        Assert.Equal(failureResult, result);
    }

}
