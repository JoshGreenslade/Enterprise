namespace Chap3.Repositories;

public interface IUnitOfWork
{
    public Task SaveChangesAsync();
}