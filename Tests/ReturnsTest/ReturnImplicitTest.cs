using Returns;

namespace ReturnsTest;

public class ReturnImplicitTest
{
    private Return ReturnsError()
    {
        return DefaultError.Create("Test");
    }

    [Fact]
    public void Converts_To_Error_When_Return_Fault_Type_Implicit()
    {
        var result = ReturnsError();

        Assert.IsType<DefaultError>(result.Error);
    }

}