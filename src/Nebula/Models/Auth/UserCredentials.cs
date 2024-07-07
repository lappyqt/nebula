namespace Nebula.Models.Auth;

public record UserCredentials(
    string Id,
    string Username,
    string Email,
    string AvatarURI,
    string Provider
);