namespace CashMachine.Domain;

public class Transaction
{
    public Transaction(Guid accountId, TransactionType type, DateTime date, decimal amount)
    {
        AccountId = accountId;
        Type = type;
        Date = date;
        Amount = amount;
    }

    public Guid AccountId { get; private set; }
    public TransactionType Type { get; private set; }
    public decimal Amount { get; private set; }
    public DateTime Date { get; private set; }
}