namespace FinSync.Finances.Domain.Entities;

public class TransactionCategory : DomainEntity<Guid>
{
  #region Constructors

  public TransactionCategory(string userId, string? name, ETransactionType type)
  {
    UserId = userId;
    Name = name;
    Type = type;
  }

  public TransactionCategory()
  {
  }

  #endregion

  #region Properties
  
  public string UserId { get; private set; } = null!;
  public string? Name { get; private set; }
  public ETransactionType Type { get; private set; }

  #endregion
}