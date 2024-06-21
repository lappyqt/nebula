using Nebula.Models.Auth;

namespace Nebula.Domain.Abstractions.Services;

public interface IAuthorizationService
{
    Task AuthorizeThroughDiscord(string code);
}