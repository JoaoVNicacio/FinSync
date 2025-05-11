namespace FinSync.Core.Entities;

public abstract class DomainEntity<TId>
{
  public TId Id { get; private set; } = default!;
  public DateTime CreatedAt { get; private set; }
  public DateTime UpdatedAt { get; private set; }
}