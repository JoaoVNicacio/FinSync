namespace FinSync.Core.Entities;

public abstract class DomainEntity<TId>
{
  public TId Id { get; private set; } = default!;
  public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
  public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

  /// <summary>
  /// The method SetUpdateStamps sets the UpdatedAt property to the current UTC time.
  /// <br/>
  /// This method is virtual and can be overridden by an specific implementation.
  /// </summary>
  public virtual void SetUpdateStamps() => UpdatedAt = DateTime.UtcNow;
}