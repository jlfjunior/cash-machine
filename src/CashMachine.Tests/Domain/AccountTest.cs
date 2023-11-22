using CashMachine.Domain.Accounts;

namespace CashMachine.Tests;

public class AccountTest
{
    [Trait("Aggregates", "Account")]
    [Fact(DisplayName = "Should create a personal account")]
    public void CreatePersonalAccount()
    {
        var account = new Account(branch: "1066", number: "01145222-4", type: AccountType.Personal);

        account.Branch.Should().Be("1066");
        account.Number.Should().Be("01145222-4");
        account.Type.Should().Be(AccountType.Personal);
        account.GetBalance().Should().Be(decimal.Zero);
    }

    [Trait("Aggregates", "Account")]
    [Fact(DisplayName = "Should create a legal personal account")]
    public void CreateLegalAccount()
    {
        var account = new Account(branch: "1066", number: "01145222-4", type: AccountType.Legal);

        account.Branch.Should().Be("1066");
        account.Number.Should().Be("01145222-4");
        account.Type.Should().Be(AccountType.Legal);
        account.GetBalance().Should().Be(decimal.Zero);
    }

    [Trait("Aggregates", "Account")]
    [Fact(DisplayName = "Should create a debit transaction")]
    public void CreateDebitTransaction()
    {
        var account = new Account(branch: "1066", number: "01145222-4", type: AccountType.Personal);
        
        account.AddTransaction(TransactionType.Debit, 100m);
        
        account.Transactions.Should().HaveCount(1);
        account.GetBalance().Should().Be(100);
    }
    
    [Trait("Aggregates", "Account")]
    [Fact(DisplayName = "Should create a credit transaction")]
    public void CreateCreditTransaction()
    {
        var account = new Account(branch: "1066", number: "01145222-4", type: AccountType.Personal);
        
        account.AddTransaction(TransactionType.Debit, 100m);
        account.AddTransaction(TransactionType.Credit, 100m);
        
        account.Transactions.Should().HaveCount(2);
        account.GetBalance().Should().Be(decimal.Zero);
    }
}