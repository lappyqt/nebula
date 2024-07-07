using System.Security.Claims;
using Nebula.Domain.Abstractions.Services;
using Nebula.Models.Auth;

namespace Nebula.Services;

public class UserCredentialsService(IHttpContextAccessor accessor) : IUserCredentialsService
{
    private HttpContext context => accessor.HttpContext!;

    public UserCredentials? GetCredentials()
    {
        return new UserCredentials(
            Id: context.User.FindFirstValue(ClaimTypes.NameIdentifier)!,
            Username: context.User.FindFirstValue(ClaimTypes.Name)!,
            Email: context.User.FindFirstValue(ClaimTypes.Email)!,
            AvatarURI: context.User.FindFirstValue("AvatarURI")!,
            Provider: context.User.FindFirstValue("Provider")!
        );
    }
}