namespace FinSync.Finances.Domain.Entities;

public class Transaction : DomainEntity<Guid>
{
  #region Properties

  #region BasicProperties

  public string UserId { get; private set; } = null!;
  public decimal Amount { get; private set; }
  public string? Description { get; private set; }
  public string? CurrencyAcronym { get; private set; }
  public DateTime? DateOfOccurrence { get; private set; }

  # endregion

  #region CompositionsAndRelations

  public virtual TransactionCategory? Category { get; private set; }
  public virtual FinancialAccount? FinancialAccount { get; private set; }

  # endregion

  #endregion
}