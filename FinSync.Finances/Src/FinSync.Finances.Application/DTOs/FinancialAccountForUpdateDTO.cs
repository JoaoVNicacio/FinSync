namespace FinSync.Finances.Application.DTOs;

public record FinancialAccountForUpdateDTO(
  string UserId,
  string Name,
  double Balance,
  string CurrencyAcronym);