namespace Deopeia.Common.Domain;

public interface IUnitOfWork
{
    Task<bool> CommitAsync();
}
