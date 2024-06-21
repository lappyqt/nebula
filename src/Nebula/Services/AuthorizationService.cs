using RestSharp;
using Newtonsoft.Json;
using Nebula.Models.Auth;
using Nebula.Domain.Abstractions.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace Nebula.Services;

public class AuthorizationService : IAuthorizationService
{
    private IConfiguration _configuration;
    private IHttpContextAccessor _accessor;
    private RestClient _client;

    public AuthorizationService(IConfiguration configuration, IHttpContextAccessor accessor)
    {
        _configuration = configuration;
        _accessor = accessor;

        _client = new RestClient("https://discord.com/api");
    }

    public async Task AuthorizeThroughDiscord(string code)
    {
        var accessToken = await GetDiscordAccessToken(code);
        var discordAccount = await GetDiscordAccountInformation(accessToken);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, discordAccount.Id),
            new Claim(ClaimTypes.Name, discordAccount.Username),
            new Claim(ClaimTypes.Email, discordAccount.Email),
            new Claim("AvatarURI", $"https://cdn.discordapp.com/avatars/{discordAccount.Id}/{discordAccount.Avatar}"),
            new Claim("Provider", "Discord")
        };

        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var authProperties = new AuthenticationProperties 
        {
            IsPersistent = true
        };

        await _accessor.HttpContext!.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
    }

    private async Task<DiscordAccessTokenResponse> GetDiscordAccessToken(string code)
    {
        var request = new RestRequest("/oauth2/token", Method.Post)
            .AddHeader("Content-Type", "application/x-www-form-urlencoded")
            .AddParameter("client_id", _configuration["Authorization:Discord:ClientId"])
            .AddParameter("client_secret", _configuration["Authorization:Discord:ClientSecret"])
            .AddParameter("code", code)
            .AddParameter("grant_type", "authorization_code")
            .AddParameter("redirect_uri", _configuration["Authorization:Discord:RedirectURI"]);

        var response = await _client.ExecuteAsync(request);

        if (response is { Content: null } || !response.IsSuccessful)
        {
            throw new Exception("Invalid code");
        }

        return JsonConvert.DeserializeObject<DiscordAccessTokenResponse>(response.Content)!;
    }

    private async Task<DiscordAccountInformation> GetDiscordAccountInformation(DiscordAccessTokenResponse accessTokenResponse)
    {
        var request = new RestRequest("/users/@me", Method.Get)
            .AddHeader("Authorization", $"{accessTokenResponse.TokenType} {accessTokenResponse.AccessToken}");
        
        var response = await _client.ExecuteAsync(request);

        if (response is { Content: null } || !response.IsSuccessful)
        {
            throw new Exception("Invalid access token");
        }

        return JsonConvert.DeserializeObject<DiscordAccountInformation>(response.Content)!;
    }
}