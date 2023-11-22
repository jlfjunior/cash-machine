using CashMachine.Domain;

namespace CashMachine.Infrastructure.Data.Repositories;

public abstract class Repository<T> : IRepository<T>
    where T : IAggregateRoot
{
    public async Task CommitAsync()
    {
        
    }
}