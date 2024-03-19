﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using GettyImages.Api.Handlers;
using GettyImages.Api.Models;

namespace GettyImages.Api;

public class Credentials
{
    private const string ClientIdKey = "client_id";
    private const string ClientSecretKey = "client_secret";
    private const string UsernameKey = "username";
    private const string PasswordKey = "password";
    private const string ClientCredentialsValue = "client_credentials";
    private const string GrantTypeKey = "grant_type";
    private const string Oauth2TokenPath = "/oauth2/token";
    private const string Refresh = "refresh_token";
    private readonly string _baseUrl;
    private Token _accessToken;

    private Credentials(string apiKey, string baseUrl)
    {
        _baseUrl = baseUrl;
        CredentialType = CredentialType.ApiKey;
        ApiKey = apiKey;
    }

    private Credentials(string apiKey, string apiSecret, string baseUrl)
    {
        _baseUrl = baseUrl;
        CredentialType = CredentialType.ClientCredentials;
        ApiKey = apiKey;
        ApiSecret = apiSecret;
    }

    private Credentials(string apiKey, string apiSecret, string refreshToken, string baseUrl)
    {
        _baseUrl = baseUrl;
        CredentialType = CredentialType.RefreshToken;
        ApiKey = apiKey;
        ApiSecret = apiSecret;
        RefreshToken = refreshToken;
    }

    private Credentials(string apiKey, string apiSecret, string userName, string userPassword, string baseUrl)
    {
        _baseUrl = baseUrl;
        CredentialType = CredentialType.ResourceOwner;
        ApiKey = apiKey;
        ApiSecret = apiSecret;
        UserName = userName;
        UserPassword = userPassword;
    }

    private string ApiKey { get; }
    private string ApiSecret { get; }
    private CredentialType CredentialType { get; }
    private string RefreshToken { get; }
    private string UserName { get; }
    private string UserPassword { get; }

    private IEnumerable<KeyValuePair<string, string>> GetCredentialsDictionary()
    {
        var dict = new Dictionary<string, string>();
        if (!string.IsNullOrEmpty(ApiKey))
        {
            dict.Add(ClientIdKey, ApiKey);
        }

        if (!string.IsNullOrEmpty(ApiSecret))
        {
            dict.Add(ClientSecretKey, ApiSecret);
        }

        if (!string.IsNullOrEmpty(UserName))
        {
            dict.Add(UsernameKey, UserName);
        }

        if (!string.IsNullOrEmpty(UserPassword))
        {
            dict.Add(PasswordKey, UserPassword);
        }

        if (!string.IsNullOrEmpty(RefreshToken))
        {
            dict.Add(Refresh, RefreshToken);
        }

        switch (CredentialType)
        {
            case CredentialType.ClientCredentials:
                dict.Add(GrantTypeKey, ClientCredentialsValue);
                break;
            case CredentialType.ResourceOwner:
                dict.Add(GrantTypeKey, PasswordKey);
                break;
            case CredentialType.RefreshToken:
                dict.Add(GrantTypeKey, Refresh);
                break;
        }

        return dict;
    }

    internal async Task<DelegatingHandler> GetHandlers()
    {
        DelegatingHandler handler = null;
        switch (CredentialType)
        {
            case CredentialType.None:
                break;
            case CredentialType.ApiKey:
                handler = new ApiKeyHandler(ApiKey);
                handler.InnerHandler = new HttpClientHandler();
                break;
            case CredentialType.ClientCredentials:
            case CredentialType.ResourceOwner:
            case CredentialType.RefreshToken:
                handler = new ApiKeyHandler(ApiKey);
                var bearerTokenHandler = new BearerTokenHandler(await GetAccessToken());
                bearerTokenHandler.InnerHandler = new HttpClientHandler();
                handler.InnerHandler = bearerTokenHandler;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return handler;
    }

    internal async Task<Token> GetAccessToken()
    {
        if ((CredentialType != CredentialType.ClientCredentials &&
             CredentialType != CredentialType.ResourceOwner &&
             CredentialType != CredentialType.RefreshToken)
            ||
            (_accessToken != null &&
             _accessToken.Expiration >= DateTime.UtcNow.AddMinutes(5)))
        {
            return _accessToken;
        }

        var helper = new WebHelper(this, _baseUrl, null);
        var response =
            await helper.PostFormAsync<OAuthResponse>(GetCredentialsDictionary(), Oauth2TokenPath, null, null, false);
        _accessToken = new Token
        {
            AccessToken = response.AccessToken,
            Expiration =
                DateTime.UtcNow.Add(TimeSpan.FromSeconds(response.ExpiresIn)),
            RefreshToken = response.RefreshToken
        };

        return _accessToken;
    }

    internal void ResetAccessToken()
    {
        _accessToken = null;
    }

    public static Credentials GetInstance(string apiKey, string baseUrl)
    {
        return new Credentials(apiKey, baseUrl);
    }

    public static Credentials GetInstance(string apiKey, string apiSecret, string baseUrl)
    {
        return new Credentials(apiKey, apiSecret, baseUrl);
    }

    public static Credentials GetInstance(string apiKey, string apiSecret, string userName, string userPassword,
        string baseUrl)
    {
        return new Credentials(apiKey, apiSecret, userName, userPassword, baseUrl);
    }

    public static Credentials GetInstance(string apiKey, string apiSecret, string refreshToken, string baseUrl)
    {
        return new Credentials(apiKey, apiSecret, refreshToken, baseUrl);
    }
}