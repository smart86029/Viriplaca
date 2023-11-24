namespace Viriplaca.Common.Domain;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
}
