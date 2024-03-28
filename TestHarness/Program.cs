using GettyImages.Api;
using GettyImages.Api.Models;
using Microsoft.Extensions.Configuration;

namespace TestHarness;

class Program
{
    static async Task Main(string[] args)
    {
        // TODO - Polish
        
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddUserSecrets<Program>();
        
        var configuration = configurationBuilder.Build();

        // TODO - Assert configuration values are present
        var apiKey = configuration["ApiKey"];   
        var apiSecret = configuration["ApiSecret"];
        var userName = configuration["UserName"];
        var userPassword = configuration["UserPassword"];
        
        var response = await ApiClient
            .GetApiClientWithResourceOwnerCredentials(apiKey, apiSecret, userName, userPassword)
            .GenerateImages()
            .WithDownloadDetails(new ImageGenerationsRequest
            {
                Prompt = "a prompt",
                Mood = ImageGenerationsMood.Dramatic,
                Notes = "some notes",
                AspectRatio = "9:16",
                MediaType = ImageGenerationsMediaType.Photography,
                NegativePrompt = "something to subtract from the prompt",
                ProductId = 666,
                //ProjectCode = "some project code"
            })
            .ExecuteAsync();

        Console.WriteLine(response.GenerationRequestId);

        foreach (var result in response.Results)
        {
            Console.WriteLine($"\t{result.Url} (Index {result.Index})");
        }
    }
}