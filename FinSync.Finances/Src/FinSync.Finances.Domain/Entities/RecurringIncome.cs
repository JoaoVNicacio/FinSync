namespace FinSync.Finances.Domain.Entities;

public class RecurringIncome
{
  #region Properties

  #region BasicProperties

  public Guid Id { get; private set; }
  public string UserId { get; private set; } = null!;
  public decimal Amount { get; private set; }
  public string? Description { get; private set; }
  public string? CurrencyAcronym { get; private set; }
  public DateTime? DateOfOccurrence { get; private set; }
  public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

  # endregion

  #region CompositionsAndRelations

  public virtual FinancialAccount? FinancialAccount { get; private set; }

  # endregion

  #endregion
}