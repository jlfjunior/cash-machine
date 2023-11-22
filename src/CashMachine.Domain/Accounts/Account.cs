using System.Collections.Immutable;

namespace CashMachine.Domain.Accounts;

public class Account : IAggregateRoot
{
    public Account(string branch, string number, AccountType type) 
    {
        Id = Guid.NewGuid();
        Branch = branch;
        Number = number;
        Type = type;
        _transations = new List<Transaction>();
    }

    public Guid Id { get; private set; }
    public string Branch { get; private set; }
    public string Number { get; private set; }
    public AccountType Type { get; private set; }
    public IReadOnlyCollection<Transaction> Transactions => _transations.ToImmutableList();
    private ICollection<Transaction> _transations { get; }

    public decimal GetBalance()
    {
        var balance = decimal.Zero;

        foreach (var transaction in _transations)
        {
            balance += transaction.Type == TransactionType.Debit
                ? transaction.Amount
                : decimal.Negate(transaction.Amount);
        }

        return balance;
    }

    public void AddTransaction(TransactionType type, decimal amount)
    {
        _transations.Add(new Transaction(Id, type, DateTime.Now, amount));
    }
}
