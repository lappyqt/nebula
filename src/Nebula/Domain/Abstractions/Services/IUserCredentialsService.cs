using Nebula.Models.Auth;

namespace Nebula.Domain.Abstractions.Services;

public interface IUserCredentialsService
{
    UserCredentials? GetCredentials();
}