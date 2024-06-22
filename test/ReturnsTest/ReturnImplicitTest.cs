using Returns;
using Returns.Exceptions;

namespace ReturnsTest;

public class ReturnImplicitTest
{
    private Return ReturnsError()
    {
        return ReturnError.Create("Test");
    }

    [Fact]
    public void Converts_To_Error_When_Return_Fault_Type_Implicit()
    {
        var result = ReturnsError();

        Assert.IsType<ReturnError>(result.Error);
    }
    [Fact]
    public void ImplicitConversion_FromFault_ShouldReturnReturnWithFault()
    {
        // Arrange
        var fault = Fault.Create("Error occurred");

        // Act
        Return returnValue = fault;

        // Assert
        Assert.False(returnValue.IsSuccessful);
        Assert.Equal(fault, returnValue.Error);
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
        Return returnValue = faults;

        // Assert
        Assert.False(returnValue.IsSuccessful);
        Assert.Equal(faults, returnValue.Errors);
        Assert.Equal(faults[0], returnValue.Error);
    }

}