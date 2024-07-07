using System.Linq.Expressions;
using Nebula.Domain.Entities;
using Nebula.Domain.Abstractions.Repositories;

namespace Nebula.Persistence.Repositories;

public class PasswordRepository : IPasswordRepository
{
    private readonly DatabaseCotnext _context;

    public PasswordRepository(DatabaseCotnext context)
    {
        _context = context;
    }

    public Password? Get(Expression<Func<Password, bool>> filter)
    {
        return _context.Passwords.SingleOrDefault(filter.Compile());
    }

    public IEnumerable<Password> GetAll(Expression<Func<Password, bool>> filter)
    {
        return _context.Passwords.Where(filter).OrderByDescending(x => x.CreatedAt);
    }

    public void Create(Password entity)
    {
        _context.Add(entity);
    }

    public void Update(Password entity)
    {
        _context.Update(entity);
    }

    public void Delete(Password entity)
    {
        _context.Remove(entity);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}