using Newtonsoft.Json;

namespace Nebula.Models.Auth;

// Doesn't include all response fields

public class DiscordAccountInformation
{
    [JsonProperty(PropertyName = "id")]
    public string Id { get; init; } = string.Empty;

    [JsonProperty(PropertyName = "username")]
    public string Username { get; init; } = string.Empty;

    [JsonProperty(PropertyName = "avatar")]
    public string Avatar { get; init; } = string.Empty;

    [JsonProperty(PropertyName = "global_name")]
    public string GlobalName { get; init; } = string.Empty;

    [JsonProperty(PropertyName = "mfa_enabled")]
    public string MfaEnabled { get; init; } = string.Empty;

    [JsonProperty(PropertyName = "locale")]
    public string Locale { get; init; } = string.Empty;

    [JsonProperty(PropertyName = "email")]
    public string Email { get; init; } = string.Empty;

    [JsonProperty(PropertyName = "verified")]
    public string Verified { get; init; } = string.Empty;
}