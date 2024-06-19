using Returns;
using Returns.Exceptions;

namespace ReturnsTest;

public class ReturnTResultTest
{

   [Fact]
   public void IsSuccessful_Is_True_And_IsFailure_Is_False_When_Return_Success()
   {
      string message = "Success.Message";
      Return<string> result = Return<string>.Success(message);

      Assert.True(result.IsSuccessful);
      Assert.False(result.IsFailure);
      Assert.Throws<InvalidRequestException>(() => result.Errors);
      Assert.Throws<InvalidRequestException>(() => result.Error);
   }
   [Fact]
   public void IsFailure_Is_True_And_IsSuccessful_Is_False_When_Return_Failure_With_Default_Error()
   {

      var result = Return<string>.Failure();


      Assert.True(result.IsFailure);
      Assert.False(result.IsSuccessful);
      Assert.IsType<DefaultError>(result.Error);
   }
   [Fact]
   public void Errors_Are_Not_Null_When_Returns_Error()
   {
      string message = "Test message";
      var result = Return<string>.Failure(new DefaultError(message));


      Assert.NotNull(result.Error);
      Assert.Equal(result.Error.Message, message);
   }

   [Fact]
   public void Errors_Are_Not_Null_When_Return_Is_List_Of_Errors()
   {
      List<Fault> errors = [Conflict.Create("Conflict.Error"), DefaultError.Create("Default.Error")];
      Return<string> result = Return<string>.Failure(errors);

      Assert.Equal(errors, result.Errors);
      Assert.Equal(errors.First(), result.Error);

   }

}