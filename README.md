# Getty Images API SDK - .NET
[![build status](https://travis-ci.org/gettyimages/gettyimages-api_dotnet.svg?branch=master)](https://travis-ci.org/gettyimages/gettyimages-api_dotnet)

## Introduction
This SDK makes using the Getty Images [API](http://developers.gettyimages.com) easy. It handles credential management, makes HTTP requests and is written with a fluent style in mind. The [API Documentation](https://github.com/gettyimages/gettyimages-api) is located on Github.

## Getting started
### Using the Nuget Package
The SDK is published to the public [Nuget](https://www.nuget.org/packages/GettyImages.Api/) package repository.

Open the package manager and add the package to your project:
![Add nuget package reference](https://raw.githubusercontent.com/gettyimages/gettyimages-api_dotnet/master/nuget-add-ref.png)

## Usage
The SDK currently supports:
+ Artists
+ Asset changes
+ Asset registration
+ Boards
+ Collections
+ Countries
+ Downloads
+ Events
+ Images
+ Products
+ Purchases
+ Search
+ Usage
+ Videos
 

### Code
The SDK supports async operations.
```csharp
var client = ApiClient.GetApiClientWithClientCredentials("my_api_key", "my_api_secret");
var searchResult = await client.SearchImagesEditorial()
    .WithEditorialSegment(EditorialSegment.News)
    .WithPhrase("all vocabulary")
    .WithSortOrder(SortOrder.Newest)
    .ExecuteAsync();

foreach (var image in searchResult.images)
{
    Console.WriteLine("Title: {0} \r\nId: {1}", image.title, image.id);
}
````
The SDK can also be used synchonously, such as when running in a console application:

```csharp
var client = ApiClient.GetApiClientWithClientCredentials("my_api_key", "my_api_secret");
var searchResult = client.SearchImagesEditorial()
    .WithEditorialSegment(EditorialSegment.News)
    .WithPhrase("all vocabulary")
    .WithSortOrder(SortOrder.Newest)
    .ExecuteAsync()
    .Result;

foreach (var image in searchResult.images)
{
    Console.WriteLine("Title: {0} \r\nId: {1}", image.title, image.id);
}
````

Results are returned as `dynamic`. Visit the [API Interactive Documentation](https://api.gettyimages.com/swagger) to learn more about available parameters and to see what the response object look like.

### Building From Source Code
_This is only necessary if you would like to contribute to the project. Otherwise, use the [Nuget Package](#using-the-nuget-package)_

#### Assumptions
+ You have [.NET Core 2.0](https://www.microsoft.com/net/learn/get-started/windows) or later installed
+ You have [Git](https://git-scm.com/downloads) installed

#### Clone the repository
The Git repository contains a submodule which requires some special handling to get setup properly. This is because we share our scenario files across all our SDKs.

Open a console window (Command Prompt, PowerShell or Bash) and issue the following commands to clone the Git repository:

	git clone git@github.com:gettyimages/gettyimages-api_dotnet.git
	cd gettyimages-api_dotnet

#### Build

```sh
dotnet restore
dotnet build
dotnet test UnitTests/
```

