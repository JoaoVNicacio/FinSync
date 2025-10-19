using FinSync.Finances.Application.DTOs;
using FinSync.Finances.Application.Services.Contracts;
using FinSync.Finances.Domain.Entities;
using FinSync.Finances.Domain.Repositories;
using FinSync.Mapper;

namespace FinSync.Finances.Application.Services.Impl;

public class FinancialAccountService(
  IFinancialAccountRepository repository,
  IMapper mapper
) : IFinancialAccountService
{
  private readonly IMapper _mapper = mapper;
  private readonly IFinancialAccountRepository _repository = repository;

  public async Task<FinancialAccount> CreateAsync(FinancialAccountForCreationDTO account) => await _repository.Create(
    _mapper.Map<FinancialAccountForCreationDTO, FinancialAccount>(account));

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