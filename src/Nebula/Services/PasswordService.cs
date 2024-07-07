using Microsoft.AspNetCore.DataProtection;
using Nebula.Domain.Abstractions;
using Nebula.Domain.Abstractions.Repositories;
using Nebula.Domain.Entities;
using Nebula.Models;

namespace Nebula.Services;

public class PasswordService : IPasswordService
{
    private readonly IPasswordRepository _repository;
    private readonly IDataProtector _protector;

    public PasswordService(IPasswordRepository repository, IDataProtectionProvider provider)
    {
        _repository = repository;
        _protector = provider.CreateProtector("Nebula.PasswordService.v1");
    }

    public List<Password> GetAccountRelatedPasswords(string accountId)
    {
        return _repository.GetAll(x => x.OwnerId == accountId).ToList();
    }

    public void CreatePassword(CreatePasswordModel createPasswordModel)
    {
        var password = new Password
        {
            Title = createPasswordModel.Title,
            OwnerId = createPasswordModel.OwnerId,
            ServiceURI = createPasswordModel.ServiceURI,
            Value = _protector.Protect(createPasswordModel.UnprotectedValue),
            CreatedAt = DateTime.UtcNow
        };

        _repository.Create(password);
        _repository.Save();
    }
}
