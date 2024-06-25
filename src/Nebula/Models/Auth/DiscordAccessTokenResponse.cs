using Newtonsoft.Json;

namespace Nebula.Models.Auth;

public class DiscordAccessTokenResponse
{
    [JsonProperty(PropertyName = "access_token")]
    public string AccessToken { get; init; } = string.Empty;

    [JsonProperty(PropertyName = "token_type")]
    public string TokenType { get; init ;} = string.Empty;

    [JsonProperty(PropertyName = "expires_in")]
    public int ExpiresIn { get; init; }

    [JsonProperty(PropertyName = "refresh_token")]
    public string RefreshToken { get; init ;} = string.Empty;
    
    [JsonProperty(PropertyName = "scope")]
    public string Scope { get; init; } = string.Empty;
}