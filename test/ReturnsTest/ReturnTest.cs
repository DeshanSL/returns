namespace ReturnsTest;
using Returns;
using Returns.Exceptions;

public class ReturnTest
{
   [Fact]
   public void IsSuccessful_Is_True_And_IsFailure_Is_False_When_Return_Success()
   {
      Return result = Return.Success();

      Assert.True(result.IsSuccessful);
      Assert.False(result.IsFailure);
      Assert.Throws<InvalidRequestException>(() => result.Errors);
      Assert.Throws<InvalidRequestException>(() => result.Error);
   }
   [Fact]
   public void IsFailure_Is_True_And_IsSuccessful_Is_False_When_Return_Failure_With_Default_Error()
   {

      var result = Return.Failure();


      Assert.True(result.IsFailure);
      Assert.False(result.IsSuccessful);
      Assert.IsType<ReturnError>(result.Error);
   }
   [Fact]
   public void Errors_Are_Not_Null_When_Returns_Error()
   {
      string message = "Test message";
      var result = Return.Failure(new ReturnError(message));


      Assert.NotNull(result.Error);
      Assert.Equal(result.Error.Message, message);
   }

   [Fact]
   public void Errors_Are_Not_Null_When_Return_Is_List_Of_Errors()
   {
      List<Fault> errors = [Conflict.Create("Conflict.Error"), ReturnError.Create("Default.Error")];
      var result = Return.Failure(errors);

      Assert.Equal(errors, result.Errors);
      Assert.Equal(errors.First(), result.Error);

   }

}
