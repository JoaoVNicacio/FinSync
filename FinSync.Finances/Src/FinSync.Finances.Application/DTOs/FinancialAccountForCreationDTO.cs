namespace FinSync.Finances.Application.DTOs;

public record FinancialAccountForCreationDTO(
  string UserId,
  string Name,
  decimal Balance,
  string CurrencyAcronym);