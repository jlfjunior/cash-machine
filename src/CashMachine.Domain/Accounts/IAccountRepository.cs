namespace CashMachine.Domain.Accounts;

public interface IAccountRepository
{
    void Add(Account account);
    void Update(Account account);
    Task<Account> FindAsync(Guid id);
}