namespace FinSync.Finances.Domain.Entities;

public class TransactionCategory
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

  public Guid Id { get; private set; }
  public string UserId { get; private set; } = null!;
  public string? Name { get; private set; }
  public ETransactionType Type { get; private set; }

  #endregion
}