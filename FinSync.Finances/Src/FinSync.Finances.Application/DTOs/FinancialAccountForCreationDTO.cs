namespace FinSync.Finances.Application.DTOs;

public record FinancialAccountForCreationDTO(
  string UserId,
  string Name,
  double Balance,
  string CurrencyAcronym);