using Moq;
using Returns;

namespace ReturnsTest;

public class ReturnTResultMatchAsyncTest
{
    [Fact]
    public async Task MatchAsync_Success_ExecutesOnSuccess()
    {
        // Arrange
        var value = "Success Value";
        var returnObject = Return<string>.Success(value);
        var onSuccessMock = new Mock<Func<string, Task>>();
        var onFailureMock = new Mock<Func<List<Fault>, Task>>();

        // Act
        await returnObject.MatchAsync(
            onSuccess: onSuccessMock.Object,
            onFailure: onFailureMock.Object
        );

        // Assert
        onSuccessMock.Verify(m => m(It.Is<string>(v => v == value)), Times.Once);
        onFailureMock.Verify(m => m(It.IsAny<List<Fault>>()), Times.Never);
    }

    [Fact]
    public async Task MatchAsync_Failure_ExecutesOnFailure()
    {
        // Arrange
        var fault = Fault.Create("Some error message");
        var returnObject = Return<string>.Failure(fault);
        var onSuccessMock = new Mock<Func<string, Task>>();
        var onFailureMock = new Mock<Func<List<Fault>, Task>>();

        // Act
        await returnObject.MatchAsync(
            onSuccess: onSuccessMock.Object,
            onFailure: onFailureMock.Object
        );

        // Assert
        onSuccessMock.Verify(m => m(It.IsAny<string>()), Times.Never);
        onFailureMock.Verify(m => m(It.Is<List<Fault>>(f => f.Count == 1 && f.First() == fault)), Times.Once);
    }

    [Fact]
    public async Task MatchFirstAsync_Success_ExecutesOnSuccess()
    {
        // Arrange
        var value = "Success Value";
        var returnObject = Return<string>.Success(value);
        var onSuccessMock = new Mock<Func<string, Task>>();
        var onFailureMock = new Mock<Func<Fault, Task>>();

        // Act
        await returnObject.MatchFirstAsync(
            onSuccess: onSuccessMock.Object,
            onFailure: onFailureMock.Object
        );

        // Assert
        onSuccessMock.Verify(m => m(It.Is<string>(v => v == value)), Times.Once);
        onFailureMock.Verify(m => m(It.IsAny<Fault>()), Times.Never);
    }

    [Fact]
    public async Task MatchFirstAsync_Failure_ExecutesOnFailure()
    {
        // Arrange
        var fault = Fault.Create("Some error message");
        var returnObject = Return<string>.Failure(fault);
        var onSuccessMock = new Mock<Func<string, Task>>();
        var onFailureMock = new Mock<Func<Fault, Task>>();

        // Act
        await returnObject.MatchFirstAsync(
            onSuccess: onSuccessMock.Object,
            onFailure: onFailureMock.Object
        );

        // Assert
        onSuccessMock.Verify(m => m(It.IsAny<string>()), Times.Never);
        onFailureMock.Verify(m => m(It.Is<Fault>(f => f == fault)), Times.Once);
    }

    [Fact]
    public async Task MatchFirstAsync_Generic_Success_ReturnsOnSuccessValue()
    {
        // Arrange
        var value = "Success Value";
        var returnObject = Return<string>.Success(value);
        var successResult = "Success Result";
        var failureResult = "Failure Result";

        // Act
        var result = await returnObject.MatchFirstAsync(
            onSuccess: async v => await Task.FromResult(successResult),
            onFailure: async f => await Task.FromResult(failureResult)
        );

        // Assert
        Assert.Equal(successResult, result);
    }

    [Fact]
    public async Task MatchFirstAsync_Generic_Failure_ReturnsOnFailureValue()
    {
        // Arrange
        var fault = Fault.Create("Some error message");
        var returnObject = Return<string>.Failure(fault);
        var successResult = "Success Result";
        var failureResult = "Failure Result";

        // Act
        var result = await returnObject.MatchFirstAsync(
            onSuccess: async v => await Task.FromResult(successResult),
            onFailure: async f => await Task.FromResult(failureResult)
        );

        // Assert
        Assert.Equal(failureResult, result);
    }

    [Fact]
    public async Task MatchAsync_Generic_Success_ReturnsOnSuccessValue()
    {
        // Arrange
        var value = "Success Value";
        var returnObject = Return<string>.Success(value);
        var successResult = "Success Result";
        var failureResult = "Failure Result";

        // Act
        var result = await returnObject.MatchAsync(
            onSuccess: async v => await Task.FromResult(successResult),
            onFailure: async f => await Task.FromResult(failureResult)
        );

        // Assert
        Assert.Equal(successResult, result);
    }

    [Fact]
    public async Task MatchAsync_Generic_Failure_ReturnsOnFailureValue()
    {
        // Arrange
        var fault = Fault.Create("Some error message");
        var returnObject = Return<string>.Failure(fault);
        var successResult = "Success Result";
        var failureResult = "Failure Result";

        // Act
        var result = await returnObject.MatchAsync(
            onSuccess: async v => await Task.FromResult(successResult),
            onFailure: async f => await Task.FromResult(failureResult)
        );

        // Assert
        Assert.Equal(failureResult, result);
    }
}
