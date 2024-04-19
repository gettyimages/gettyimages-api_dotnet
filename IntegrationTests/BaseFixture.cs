using Microsoft.Extensions.Configuration;

namespace IntegrationTests;

public abstract class BaseFixture
{
    protected BaseFixture()
    {
        var configurationBuilder = new ConfigurationBuilder();
        configurationBuilder.AddUserSecrets<BaseFixture>();
        var configuration = configurationBuilder.Build();
        ApiKey = configuration.AssertConfigurationValue("ApiKey");
        ApiSecret = configuration.AssertConfigurationValue("ApiSecret");
        UserName = configuration.AssertConfigurationValue("UserName");
        UserPassword = configuration.AssertConfigurationValue("UserPassword");
        ProductId = int.Parse(configuration.AssertConfigurationValue("ProductId"));
    }

    public int ProductId { get; }

    public string UserPassword { get; }

    public string UserName { get; }

    public string ApiSecret { get; }

    public string ApiKey { get; }
}