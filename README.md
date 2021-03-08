# Getty Images API SDK - .NET
[![build status](https://travis-ci.org/gettyimages/gettyimages-api_dotnet.svg?branch=master)](https://travis-ci.org/gettyimages/gettyimages-api_dotnet)
[![NuGet version](https://badge.fury.io/nu/gettyimages.api.svg)](https://badge.fury.io/nu/gettyimages.api)
[![NuGet](https://img.shields.io/nuget/dt/GettyImages.Api.svg?style=flat-square)](https://www.nuget.org/packages/gettyimages.api)
[![Open Hub](https://img.shields.io/badge/Open-Hub-0185CA.svg)](https://www.openhub.net/p/gettyimages-api_dotnet)


## Introduction
This SDK makes using the Getty Images [API](http://developers.gettyimages.com) easy. It handles credential management, makes HTTP requests and is written with a fluent style in mind. For more info about the API, see the [Documentation](https://developers.gettyimages.com/api/).

* Functionality for all endpoints.

## Help & Support

* [Getty Images API](http://developers.gettyimages.com/)
* [Contact API Support](mailto:apisupport@gettyimages.com)
* [Issue Tracker](https://github.com/gettyimages/gettyimages-api_dotnet/issues)

## Getting started
### Obtain an API Key

If you don't already have an API key, fill out and submit the ["Get started with our API" form](http://engage.gettyimages.com/api-contact).

### Using the Nuget Package
The SDK is published to the public [Nuget](https://www.nuget.org/packages/GettyImages.Api/) package repository.

Open the package manager and add the package to your project:
![Add nuget package reference](https://raw.githubusercontent.com/gettyimages/gettyimages-api_dotnet/master/nuget-add-ref.png)

### Examples
The SDK supports async operations.
```csharp
var client = ApiClient.GetApiClientWithClientCredentials("YOUR_API_KEY", "YOUR_API_SECRET");
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

The SDK can also be used synchronously, such as when running in a console application:

```csharp
var client = ApiClient.GetApiClientWithClientCredentials("YOUR_API_KEY", "YOUR_API_SECRET");
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

Results are returned as `dynamic`. Visit the [API Interactive Documentation](https://api.gettyimages.com/swagger) to learn more about available parameters and to see what the response objects look like.

#### ASP.NET Webforms

When using the SDK in a Webforms project, there are a few extra steps needed. For more detailed information, see [Using Asynchronous Methods in ASP.NET 4.5](https://docs.microsoft.com/en-us/aspnet/web-forms/overview/performance-and-caching/using-asynchronous-methods-in-aspnet-45) on Microsoft's documentation website.

First, the Page must be marked as `Async="true"`:

```html
<%@ Page Language="C#" Async="true" AutoEventWireup="true" CodeBehind="Images.aspx.cs" Inherits="WebFormsSdkTest.Images" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Repeater ID="RepeaterImages" runat="server">
                <ItemTemplate>
                    <asp:Image runat="server" ImageUrl='<%#Container.DataItem%>'/>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </form>
</body>
</html>

```

Then register an async task in the `Page_Load` method:

```csharp
public partial class Images : Page
{
    public List<string> ImageList { get; set; }
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterAsyncTask(new PageAsyncTask(GetImages));
    }

    private async Task GetImages()
    {
        var client = ApiClient.GetApiClientWithClientCredentials("YOUR_API_KEY",
            "YOUR_API_SECRET");
        var response = await client.SearchImagesCreative().WithPhrase("tacos").ExecuteAsync();
        ImageList = new List<string>();
        for (int i = 0; i < response.images.Count; i++)
        {
            ImageList.Add((string)response.images[i].display_sizes[0].uri);
        }

        RepeaterImages.DataSource = ImageList;
        RepeaterImages.DataBind();
    }
}

```

### Building From Source Code
_This is only necessary if you would like to contribute to the project. Otherwise, use the [Nuget Package](#using-the-nuget-package)_

#### Assumptions
+ You have [.NET Core 2.0](https://www.microsoft.com/net/learn/get-started/windows) or later installed
+ You have [Git](https://git-scm.com/downloads) installed

#### Clone the repository
Open a console window (Command Prompt, PowerShell or Bash) and issue the following commands to clone the Git repository:
```sh
git clone git@github.com:gettyimages/gettyimages-api_dotnet.git
cd gettyimages-api_dotnet
```

#### Build

```sh
dotnet restore
dotnet build
dotnet test UnitTests/
```

