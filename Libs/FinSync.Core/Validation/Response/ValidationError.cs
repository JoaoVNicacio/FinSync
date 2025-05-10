namespace FinSync.Core.Validation.Response;

public record ValidationError(
  object? target,
  string property,
  object? value,
  Dictionary<string, string> constraints,
  IEnumerable<ValidationError>children);