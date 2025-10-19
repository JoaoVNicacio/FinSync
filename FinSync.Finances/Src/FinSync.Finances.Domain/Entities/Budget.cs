namespace FinSync.Finances.Domain.Entities;

public class Budget : DomainEntity<Guid>
{
  #region Properties
  
  public string? UserId { get; private set; }
  public string Name { get; private set; } = null!;
  public byte NotificationThresholdPercentage { get; private set; }
  public decimal PlannedAmount { get; private set; }
  public decimal ActualAmount { get; private set; }
  public DateTime PlannedDate { get; private set; }
  public DateTime StartDate { get; private set; }

  #endregion
}