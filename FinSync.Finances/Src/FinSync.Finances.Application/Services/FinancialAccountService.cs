using FinSync.Finances.Application.DTOs;
using FinSync.Finances.Application.Services.Contracts;
using FinSync.Finances.Domain.Entities;

namespace FinSync.Finances.Application.Services;

public class FinancialAccountService : IFinancialAccountService
{
  public Task<FinancialAccount> CreateAsync(FinancialAccountForCreationDTO account)
  {
    throw new NotImplementedException();
  }

  public Task<FinancialAccount?> GetByIdAsync(Guid Id)
  {
    throw new NotImplementedException();
  }

  public Task<FinancialAccount> UpdateAsync(Guid id, FinancialAccountForUpdateDTO updateDTO)
  {
    throw new NotImplementedException();
  }

  public Task<bool> DeleteAsync(Guid id)
  {
    throw new NotImplementedException();
  }

  public Task<Collection<FinancialAccount>> ListByUserAsync(string userId)
  {
    throw new NotImplementedException();
  }
}