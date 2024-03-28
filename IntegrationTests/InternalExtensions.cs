using System;
using Microsoft.Extensions.Configuration;

namespace IntegrationTests;

internal static class InternalExtensions
{
    public static string AssertConfigurationValue(this IConfiguration configuration, string key)
    {
        var result = configuration[key];
        if (string.IsNullOrWhiteSpace(result))
        {
            throw new Exception(
                $"Expected configuration value (\"{key}\") not found.  Use \"dotnet user-secrets set {key} <SECRET_VALUE>\" to set before running tests.");
        }

        return result;
    }
}