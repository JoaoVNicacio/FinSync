namespace FinSync.Finances.Domain.Entities;

public class FinancialAccount
{
  #region Constructors

  public FinancialAccount()
  {
  }

  public FinancialAccount(
    string userId,
    string? name,
    decimal balance,
    string? currencyAcronym)
  {
    UserId = userId;
    Name = name;
    Balance = balance;
    CurrencyAcronym = currencyAcronym;
  }

  #endregion

  #region Properties

  #region BasicProperties
  
  public Guid Id { get; private set; }
  public string UserId { get; private set; } = null!;
  public string? Name { get; private set; }
  public decimal Balance { get; private set; }
  public string? CurrencyAcronym { get; private set; }
  public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;
  
  #region Compositions and Relations

  public virtual ICollection<Transaction> Transactions { get; private set; } = [];
  public virtual ICollection<RecurringExpense> RecurringExpenses { get; private set; } = [];
  public virtual ICollection<RecurringIncome> RecurringIncomes { get; private set; } = [];

  #endregion

  #endregion

  #endregion
}