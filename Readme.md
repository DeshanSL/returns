### Simplify error handling and improve code readability with the Result Pattern

## Get Started

#### Install nuget package using .Net CLI

or nuget using Nuget package manager GUI by searching DeepCode.Return
```bash
dotnet add package DeepCode.Return --version 1.0.1
```

#### Define method return type with Return struct with TResult type parameter

TResult is type of the return

```csharp
namespace Invoicing.Application.Orders.Commands.CreateOrderCommand;

internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Return<Order>>
{
    public async Task<Return<Order>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        Order order;
        //order creation logic
        return order;
    }
}
```
for non async methods
```csharp
public Return<Order> CreateOrder(CreateOrder request, CancellationToken cancellationToken)
{
    Order order;

    //order creation logic
    return order;
}
```
#### Return struct can be used when there's no return value but to notify if function was success or not

```csharp
public Return SendEmail()
{
    return Return.Success();
}
```
### How to extract if state is success

```csharp
public void Main()
{
    Return<Order> orderCreateResult = CreateOrder(request, cancellationToken);
    if(orderCreateResult.IsFailure)
    {
        // Failure code goes here
    }
    Order order = orderCreateResult.Value;
    // success path here
}
```

### Error Handling

#### Notify caller error with in built error types

Handle Conflicts,

```csharp
 public Return<Order> CreateOrder(double totalAmount)
 {
     // logic to apply the discount if total amount is > 100
     // Inventory says out of stock due to high demand

     if (!inventoryManagement.AreEnoughStokesAvailable())
     {
          return Fault.Conflict("Not enough stockes in inventory.");
          //or
          return Return<Order>.Failure(Conflict.Create("Not enough stockes in inventory."));
     }

 }
```
#### Other in-built error type available

```csharp
// all these take one string message arg and optinal description arg
return Fault.NotFound();
return Fault.InternalError();
return Fault.ReturnError();
```

#### Handle Errors from caller method

```csharp
 public Return Main()
 {
     Return<Order> orderCreateResult = CreateOrder(100);

     if (orderCreateResult.IsFailure)
     {
         // First error or only error of the list.
         Fault error = orderCreateResult.Error;

         // Read all errors returned.
         IReadOnlyList<Fault> errors = orderCreateResult.Errors;

         // Error logic goes here
     }

     if (orderCreateResult.IsFailure)
     {
         // Pass errors to call stack
         return orderCreateResult.Errors.ToList();
     }
 }
```








