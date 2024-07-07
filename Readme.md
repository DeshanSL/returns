### Simplify error handling and improve code readability with the Result Pattern

## Get Started

#### Install nuget package using .Net CLI

or nuget using Nuget package manager GUI by searching DeepCode.Return
```bash
dotnet add package DeepCode.Return --version 1.0.1
```
## How To Use
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

#### Define custom error types

Need to be inherited from Fault record
```csharp
public record OrderCreationErrors : Fault
{
    public OrderCreationErrors(string message, string? description = null) : base(message, description) { }

    public static OrderCreationErrors InvalidCustomerIdForOrderCreation =>
        new OrderCreationErrors("Could not find matching customer to the given customerId.");

    public static OrderCreationErrors CustomerBlacklisted =>
        new OrderCreationErrors("Customer with the given customerId has been blacklisted.");
}
```
#### Using Match 

Match method can be used to trigger actions when some return is success or failure.

Trigger actions with no return type.
```csharp
Return<Order> orderCreateResult = CreateOrder(100);

orderCreateResult.Match(
    onSuccess: (value) => _logger.Info($"{value.Id} Order created successfully."),
    onFailure: (errors) => _logger.Error("Failed to create order.")
    );

//Match first error of errors if failure.
orderCreateResult.MatchFirst(
    onSuccess: (value) => _logger.Info($"{value.Id} Order created successfully."),
    onFailure: (error) => _logger.Error("Failed to create order.")
    );

orderCreateResult.MatchAsync(
    onSuccess: async (value) =>
    {
        // Simulating async process
        await Task.Delay(100);
        _logger.Info($"{value.Id} Order created successfully.");
    },
    onFailure: async (errors) =>
    {
        // Simulating async process
        await Task.Delay(100);
        _logger.Error("Failed to create order.");
    });

```

Match using TNextValue type, has return after match

```csharp
 Return<Order> orderCreateResult = Return<Order>.Success(new Order());

 Response<Order> response = orderCreateResult.Match<Response<Order>>(
     onSuccess:(order) => new Response<Order>() { Data = order },
     onFailure:(errors) => new Response<Order>() { Error = new { Error = errors.ToList() } });

//gets first error of the list as the arg when failure.
 Response<Order> response = orderCreateResult.MatchFirst<Response<Order>>(
     onSuccess:(order) => new Response<Order>() { Data = order },
     onFailure:(error) => new Response<Order>() { Error = new { Error = errors.ToList() } });


 Response<Order> response = orderCreateResult.MatchAsync<Response<Order>>(
     onSuccess: async (order) => {},
     onFailure: async (errors) => {});

//gets first error of the list as the arg when failure.
 Response<Order> response = orderCreateResult.MatchFirstAsync<Response<Order>>(
     onSuccess: async (order) => {},
     onFailure: async (error) => {});
```


