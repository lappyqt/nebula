using Nebula.Domain.Entities;
using Nebula.Models;

namespace Nebula.Domain.Abstractions;

public interface IPasswordService
{
    List<Password> GetAccountRelatedPasswords(string accountId);
    void CreatePassword(CreatePasswordModel createPasswordModel);
}