using CashMachine.Domain.Accounts;

namespace CashMachine.Infrastructure.Data.Repositories;

public class AccountRepository : IAccountRepository
{
    public void Add(Account account)
    {
        throw new NotImplementedException();
    }

    public void Update(Account account)
    {
        throw new NotImplementedException();
    }

    public async Task<Account> FindAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}