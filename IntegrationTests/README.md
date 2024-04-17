# Integration Tests

Some API calls need more in-depth testing to assure correctness.  For these we have integration tests which are to be executed locally with secrets provided in configuration, primarily through [`dotnet user-secrets`](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets).  Specifically, you'll need:

``` bash
dotnet user-secrets set ApiKey ****
dotnet user-secrets set ApiSecret ****
dotnet user-secrets set UserName ****
dotnet user-secrets set UserPassword ****
dotnet user-secrets set ProductId ****
```
