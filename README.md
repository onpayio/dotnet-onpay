# dotnet-onpay
OnPay SDK for .NET

A .NET-SDK for developing against the OnPay.io platform.
API documentation at: https://manage.onpay.io/docs/api_v1.html 

## Requirements

.NET Standard 2.0 and later.

## NuGet

You can install the SDK via [NuGet](https://www.nuget.org/). Run the following command:
```bash
Install-Package OnPay.SDK
```

## Getting started



### Creating a payment window V3

A simple example of how to create a payment window v3.

Read more about the fields here: https://manage.onpay.io/docs/paymentwindow_v3.html
```csharp
//Set up the window
var window = new PaymentWindow();
window.SetGatewayId("Yor gateway id")
  .SetWindowSecret("secret")
  .SetCurrency("DKK")
  .SetAmount(123400)
  .SetReference("UniqueReferenceId")
  .SetAcceptUrl("https://example.com/payment?success=1")
  .SetDeclineUrl("https://example.com/payment?success=0")
  .SetType("payment")
  .SetDesign("DesignName")
  .Enable3DSecure()
  .SetMethod("card")
  .EnableTestMode()
  .SetLanguage("en")
  .SetName("Test Person")
  .SetEmail("email@example.com");

// Use these params for your form
var param = window.GenerateParams();
```

### Using the API 

Just init client like:
```csharp
var client = new OnPayClient.OnPayClient("access_token");
```

## Transactions
```csharp
// Get default page
var defaultPage = client.Transactions.Page();

// Get filtered page
var filteredPage = client.Transactions.Page(query: "42", orderBy: OrderBy.Amount, direction: Direction.Desc);

// Get pagination object
var pagination = defaultPage.Meta.Pagination;

// Get transaction details
var transactionDetails = filteredPage.Data[0].Details();
// or via resource identifier:
transactionDetails = client.Transactions.Details("resource_identifier");

// Capture transaction
var capturedTransaction = transactionDetails.Data.Capture(1000);
// or via shortcut:
capturedTransaction = transactionDetails.Data.Capture(1000);

// Refund transaction
var refundedTransaction = capturedTransaction.Data.Refund(500);
// or via shortcut:
refundedTransaction = capturedTransaction.Refund(500);

// Cancel transaction
var cancelledTransaction = transactionDetails.Data.Cancel();
// or via shortcut:
cancelledTransaction = transactionDetails.Cancel();
```

## Subscriptions
```csharp
// Get default page
var defaultPage = client.Subscriptions.Page();

// Get filtered page
var filteredPage = client.Subscriptions.Page(query: "42", orderBy: OrderBy.Status, direction: Direction.Asc);

// Get pagination if you need
var pagination = defaultPage.Meta.Pagination;

// Get subscription details
var subscriptionDetails = filteredPage.Data[0].Details();
// or via resource identifier
subscriptionDetails = client.Subscriptions.Details("resource_identifier");

// Create transaction for a subscription
var transaction = subscriptionDetails.Data.Authorize(1000, "order_id");
// or via shortcut:
transaction = subscriptionDetails.Authorize(1000, "order_id");

// Cancel a subscription
var cancelledSubscription = subscriptionDetails.Data.Cancel();
// or via shortcut
cancelledSubscription = subscriptionDetails.Cancel();
```

## More examples
If you need more examples please check [this](https://github.com/KimPagter/OnPayTester) repository out
