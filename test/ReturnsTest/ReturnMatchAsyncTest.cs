
using Returns;

namespace ReturnsTest;

public class ReturnMatchAsyncTest
{
    [Fact]
    public async Task MatchAsync_Success_ExecutesOnSuccess()
    {
        // Arrange
        var returnObject = Return.Success();
        bool onSuccessCalled = false;
        bool onFailureCalled = false;

        // Act
        await returnObject.MatchAsync(
            onSuccess: async () => { onSuccessCalled = true; await Task.CompletedTask; },
            onFailure: async faults => { onFailureCalled = true; await Task.CompletedTask; }
        );

        // Assert
        Assert.True(onSuccessCalled);
        Assert.False(onFailureCalled);
    }

    [Fact]
    public async Task MatchAsync_Failure_ExecutesOnFailure()
    {
        // Arrange
        var fault = Fault.Create("Some error message");
        var returnObject = Return.Failure(fault);
        bool onSuccessCalled = false;
        bool onFailureCalled = false;

        // Act
        await returnObject.MatchAsync(
            onSuccess: async () => { onSuccessCalled = true; await Task.CompletedTask; },
            onFailure: async faults => { onFailureCalled = true; await Task.CompletedTask; }
        );

        // Assert
        Assert.False(onSuccessCalled);
        Assert.True(onFailureCalled);
    }

    [Fact]
    public async Task MatchFirstAsync_Success_ExecutesOnSuccess()
    {
        // Arrange
        var returnObject = Return.Success();
        bool onSuccessCalled = false;
        bool onFailureCalled = false;

        // Act
        await returnObject.MatchFirstAsync(
            onSuccess: async () => { onSuccessCalled = true; await Task.CompletedTask; },
            onFailure: async fault => { onFailureCalled = true; await Task.CompletedTask; }
        );

        // Assert
        Assert.True(onSuccessCalled);
        Assert.False(onFailureCalled);
    }

    [Fact]
    public async Task MatchFirstAsync_Failure_ExecutesOnFailure()
    {
        // Arrange
        var fault = Fault.Create("Some error message");
        var returnObject = Return.Failure(fault);
        bool onSuccessCalled = false;
        bool onFailureCalled = false;

        // Act
        await returnObject.MatchFirstAsync(
            onSuccess: async () => { onSuccessCalled = true; await Task.CompletedTask; },
            onFailure: async fault => { onFailureCalled = true; await Task.CompletedTask; }
        );

        // Assert
        Assert.False(onSuccessCalled);
        Assert.True(onFailureCalled);
    }

    [Fact]
    public async Task MatchFirstAsync_Generic_Success_ReturnsOnSuccessValue()
    {
        // Arrange
        var returnObject = Return.Success();
        var successValue = "Success";
        var failureValue = "Failure";

        // Act
        var result = await returnObject.MatchFirstAsync(
            onSuccess: async () => { await Task.CompletedTask; return successValue; },
            onFailure: async fault => { await Task.CompletedTask; return failureValue; }
        );

        // Assert
        Assert.Equal(successValue, result);
    }

    [Fact]
    public async Task MatchFirstAsync_Generic_Failure_ReturnsOnFailureValue()
    {
        // Arrange
        var fault = Fault.Create("Some error message");
        var returnObject = Return.Failure(fault);
        var successValue = "Success";
        var failureValue = "Failure";

        // Act
        var result = await returnObject.MatchFirstAsync(
            onSuccess: async () => { await Task.CompletedTask; return successValue; },
            onFailure: async fault => { await Task.CompletedTask; return failureValue; }
        );

        // Assert
        Assert.Equal(failureValue, result);
    }

    [Fact]
    public async Task MatchAsync_Generic_Success_ReturnsOnSuccessValue()
    {
        // Arrange
        var returnObject = Return.Success();
        var successValue = "Success";
        var failureValue = "Failure";

        // Act
        var result = await returnObject.MatchAsync(
            onSuccess: async () => { await Task.CompletedTask; return successValue; },
            onFailure: async faults => { await Task.CompletedTask; return failureValue; }
        );

        // Assert
        Assert.Equal(successValue, result);
    }

    [Fact]
    public async Task MatchAsync_Generic_Failure_ReturnsOnFailureValue()
    {
        // Arrange
        var fault = Fault.Create("Some error message");
        var returnObject = Return.Failure(fault);
        var successValue = "Success";
        var failureValue = "Failure";

        // Act
        var result = await returnObject.MatchAsync(
            onSuccess: async () => { await Task.CompletedTask; return successValue; },
            onFailure: async faults => { await Task.CompletedTask; return failureValue; }
        );

        // Assert
        Assert.Equal(failureValue, result);
    }
}
